using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StokHareketiRepository.Validation
{
    public class StokHareketiValidator : AbstractValidator<StokHareketi>
    {
        public StokHareketiValidator()
        {
        }
    }
}
