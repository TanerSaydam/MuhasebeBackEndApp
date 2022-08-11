using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.BorcCekiRepository.Validation
{
    public class BorcCekiValidator : AbstractValidator<BorcCeki>
    {
        public BorcCekiValidator()
        {
        }
    }
}
