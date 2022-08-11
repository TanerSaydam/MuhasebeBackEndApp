using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.CariRepository.Validation
{
    public class CariValidator : AbstractValidator<Cari>
    {
        public CariValidator()
        {
        }
    }
}
