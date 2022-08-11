using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StokRepository.Validation
{
    public class StokValidator : AbstractValidator<Stok>
    {
        public StokValidator()
        {
        }
    }
}
