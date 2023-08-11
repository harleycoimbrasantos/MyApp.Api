using MediatR;
using MyApp.Data.Interface;
using MyApp.Domain.Entities;
using MyApp.Services.Interfaces;

namespace MyApp.Application.CNAB
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IFileManagementService _fileManagementService;
        private readonly ICustomerMovementService _customerMovementService;
        private readonly ICustomerMovementRepository _customerMovementRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        public Handler(IFileManagementService fileManagementService, ICustomerMovementService customerMovementService, ICustomerMovementRepository customerMovementRepository, ITransactionTypeRepository transactionTypeRepository)
        {
            _fileManagementService = fileManagementService;
            _customerMovementService = customerMovementService;
            _customerMovementRepository = customerMovementRepository;
            _transactionTypeRepository = transactionTypeRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            byte[]? data = 
                Convert.FromBase64String(request.Base64.Replace("data:text/plain;base64,", string.Empty));

            string filePath = 
                $@"C:\Files\CNAB_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.txt";

            var fileSaveSucess =
                await _fileManagementService.WriteFileAsync(filePath, data);

            if (fileSaveSucess)
            {
                List<CustomerMovement> customerMovements = new();

                using var file = new StreamReader(filePath);
                string? line;

                while ((line = file.ReadLine()) != null)
                    customerMovements.Add(await _customerMovementService.LineToCustomerMovement(line));

                file?.Close();

                try
                {
                    foreach (CustomerMovement customerMovement in customerMovements)
                        _customerMovementRepository.Create(customerMovement);

                    _customerMovementRepository.Save();
                }
                catch
                {
                    throw;
                }

                var resultGroup = customerMovements.GroupBy(x => x.StoreName).Select( g => new { Description = g?.Key, Total = g.Sum(x => x?.Value) });

                List<SummaryResponse> summaries = new();
                List<MovementResponse> movements = new();

                foreach (var g in resultGroup)
                {
                    movements.Clear();
                    foreach (CustomerMovement customerMovement in customerMovements)
                    {
                        movements.Add(new MovementResponse
                        {
                            CardNumber = customerMovement.CardNumber,
                            Document = customerMovement.Document,
                            MovementDate = customerMovement.MovementDate,
                            MovementTime = customerMovement.MovementTime,   
                            StoreName = customerMovement.StoreName,
                            TransactionTypeId = customerMovement?.TransactionTypeId,
                            Value = customerMovement?.Value,
                            TransactionTypeDescription = _transactionTypeRepository.Find(t => t.Id.Equals(customerMovement.TransactionTypeId)).Description
                        });
                    }

                    summaries.Add(new SummaryResponse { Store = g.Description, Total = g.Total, Movements = movements.Where(x=> x.StoreName == g.Description) });
                }

                return new Response() { Success = true, Summaries = summaries };
            }

            return new Response() { Success = false }; 
        }
    }
}
