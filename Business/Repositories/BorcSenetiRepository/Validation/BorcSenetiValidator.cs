using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.BorcSenetiRepository.Validation
{
    public class BorcSenetiValidator : AbstractValidator<BorcSeneti>
    {
        public BorcSenetiValidator()
        {
        }
    }
}
