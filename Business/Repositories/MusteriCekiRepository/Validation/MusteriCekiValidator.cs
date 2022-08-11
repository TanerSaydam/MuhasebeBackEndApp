using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.MusteriCekiRepository.Validation
{
    public class MusteriCekiValidator : AbstractValidator<MusteriCeki>
    {
        public MusteriCekiValidator()
        {
        }
    }
}
