﻿using FluentValidation;

namespace MyApp.Application.CNAB
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator() 
        {
            RuleFor(r => r)
               .Must(x => !string.IsNullOrWhiteSpace(x.Base64))
               .WithName("Arquivo Obrigatorio")
               .WithMessage("Obrigatório");
        }
    }
}
