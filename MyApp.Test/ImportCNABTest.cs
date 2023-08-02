using Moq;
using MyApp.Data.Interface;
using MyApp.Services.Interfaces;
using Xunit;

namespace MyApp.Test
{
    public class ImportCNABTest : IDisposable
    {
        IFileManagementService _fileManagementService { get; }
        ICustomerMovementService _customerMovementService { get; }
        ICustomerMovementRepository _mockCustomerMovementRepository { get; }
        ITransactionTypeRepository _mockTransactionTypeRepository { get; }

        MyApp.Application.CNAB.Handler handler;

        private void Setup()
        {
            handler = new MyApp.Application.CNAB.Handler(
                _fileManagementService,
                _customerMovementService,
                _mockCustomerMovementRepository,
                _mockTransactionTypeRepository
            );
        }


        public ImportCNABTest()
        {
            _fileManagementService = Mock.Of<IFileManagementService>();
            _customerMovementService = Mock.Of<ICustomerMovementService>();
            _mockCustomerMovementRepository = Mock.Of<ICustomerMovementRepository>();
            _mockTransactionTypeRepository = Mock.Of<ITransactionTypeRepository>();

            Setup();
        }  

        [Fact]
        public async void CustomerMovimentTest()
        {
            MyApp.Application.CNAB.Request request = new() { Base64 = GetBase64() };

            var responseMovement = await handler.Handle(request, default(CancellationToken));

            Assert.False(responseMovement.Success);
        }


        public string GetBase64()
        {
            return
                "MzIwMTkwMzAxMDAwMDAxNDIwMDA5NjIwNjc2MDE3NDc1MyoqKiozMTUzMTUzNDUzSk/Dg08gTUFDRURPICAgQkFSIERPIEpPw4NPICAgICAgIA0KNTIwMTkwMzAxMDAwMDAxMzIwMDU1NjQxODE1MDYzMzEyMyoqKio3Njg3MTQ1NjA3TUFSSUEgSk9TRUZJTkFMT0pBIERPIMOTIC0gTUFUUklaDQozMjAxOTAzMDEwMDAwMDEyMjAwODQ1MTUyNTQwNzM2Nzc3KioqKjEzMTMxNzI3MTJNQVJDT1MgUEVSRUlSQU1FUkNBRE8gREEgQVZFTklEQQ0KMjIwMTkwMzAxMDAwMDAxMTIwMDA5NjIwNjc2MDE3MzY0OCoqKiowMDk5MjM0MjM0Sk/Dg08gTUFDRURPICAgQkFSIERPIEpPw4NPICAgICAgIA0KMTIwMTkwMzAxMDAwMDAxNTIwMDA5NjIwNjc2MDE3MTIzNCoqKio3ODkwMjMzMDAwSk/Dg08gTUFDRURPICAgQkFSIERPIEpPw4NPICAgICAgIA0KMjIwMTkwMzAxMDAwMDAxMDcwMDg0NTE1MjU0MDczODcyMyoqKio5OTg3MTIzMzMzTUFSQ09TIFBFUkVJUkFNRVJDQURPIERBIEFWRU5JREENCjIyMDE5MDMwMTAwMDAwNTAyMDA4NDUxNTI1NDA3Mzg0NzMqKioqMTIzMTIzMTIzM01BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBDQozMjAxOTAzMDEwMDAwMDYwMjAwMjMyNzAyOTgwNTY2Nzc3KioqKjEzMTMxNzI3MTJKT1PDiSBDT1NUQSAgICBNRVJDRUFSSUEgMyBJUk3Dg09TDQoxMjAxOTAzMDEwMDAwMDIwMDAwNTU2NDE4MTUwNjMxMjM0KioqKjMzMjQwOTAwMDJNQVJJQSBKT1NFRklOQUxPSkEgRE8gw5MgLSBNQVRSSVoNCjUyMDE5MDMwMTAwMDAwODAyMDA4NDUxNTI1NDA3MzMxMjMqKioqNzY4NzE0NTYwN01BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBDQoyMjAxOTAzMDEwMDAwMDEwMjAwMjMyNzAyOTgwNTY4NDczKioqKjEyMzEyMzEyMzNKT1PDiSBDT1NUQSAgICBNRVJDRUFSSUEgMyBJUk3Dg09TDQozMjAxOTAzMDEwMDAwNjEwMjAwMjMyNzAyOTgwNTY2Nzc3KioqKjEzMTMxNzI3MTJKT1PDiSBDT1NUQSAgICBNRVJDRUFSSUEgMyBJUk3Dg09TDQo0MjAxOTAzMDEwMDAwMDE1MjMyNTU2NDE4MTUwNjMxMjM0KioqKjY2NzgxMDAwMDBNQVJJQSBKT1NFRklOQUxPSkEgRE8gw5MgLSBGSUxJQUwNCjgyMDE5MDMwMTAwMDAwMTAyMDM4NDUxNTI1NDA3MzIzNDQqKioqMTIyMjEyMzIyMk1BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBDQozMjAxOTAzMDEwMDAwMDEwMzAwMjMyNzAyOTgwNTY2Nzc3KioqKjEzMTMxNzI3MTJKT1PDiSBDT1NUQSAgICBNRVJDRUFSSUEgMyBJUk3Dg09TDQo5MjAxOTAzMDEwMDAwMDEwMjAwNTU2NDE4MTUwNjM2MjI4KioqKjkwOTAwMDAwMDBNQVJJQSBKT1NFRklOQUxPSkEgRE8gw5MgLSBNQVRSSVoNCjQyMDE5MDYwMTAwMDAwNTA2MTc4NDUxNTI1NDA3MzEyMzQqKioqMjIzMTEwMDAwME1BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBDQoyMjAxOTAzMDEwMDAwMDEwOTAwMjMyNzAyOTgwNTY4NzIzKioqKjk5ODcxMjMzMzNKT1PDiSBDT1NUQSAgICBNRVJDRUFSSUEgMyBJUk3Dg09TDQo4MjAxOTAzMDEwMDAwMDAwMjAwODQ1MTUyNTQwNzMyMzQ0KioqKjEyMjIxMjMyMjJNQVJDT1MgUEVSRUlSQU1FUkNBRE8gREEgQVZFTklEQQ0KMjIwMTkwMzAxMDAwMDAwMDUwMDIzMjcwMjk4MDU2NzY3NyoqKio4Nzc4MTQxODA4Sk9Tw4kgQ09TVEEgICAgTUVSQ0VBUklBIDMgSVJNw4NPUw0KMzIwMTkwMzAxMDAwMDAxOTIwMDg0NTE1MjU0MDczNjc3NyoqKioxMzEzMTcyNzEyTUFSQ09TIFBFUkVJUkFNRVJDQURPIERBIEFWRU5JREE=";
        }

        public void Dispose()
        {

        }
    }
}
