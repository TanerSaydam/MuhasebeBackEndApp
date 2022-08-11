using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.FaturaRepository.Validation
{
    public class FaturaValidator : AbstractValidator<Fatura>
    {
        public FaturaValidator()
        {
        }
    }
}
