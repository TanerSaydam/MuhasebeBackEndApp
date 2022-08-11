using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.FaturaDetayiRepository.Validation
{
    public class FaturaDetayiValidator : AbstractValidator<FaturaDetayi>
    {
        public FaturaDetayiValidator()
        {
        }
    }
}
