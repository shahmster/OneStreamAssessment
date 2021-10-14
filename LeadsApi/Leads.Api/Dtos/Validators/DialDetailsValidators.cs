using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Dtos.Validators
{
    public class DialDetailsValidators:AbstractValidator<DialDetails>
    {
        public DialDetailsValidators()
        {
            RuleFor(prop => prop.AgentSessionId)
                .NotEmpty()
                .WithMessage("Please provide a session id")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Invalid AgentSessionId");

            RuleFor(prop => prop.PhoneNumber)
                .NotEmpty()
                .WithMessage("Please provide a phonenumber")
                .Must(pho=>pho.Length ==10)
                .WithMessage("Incorrect Length");
        }
    }
}
