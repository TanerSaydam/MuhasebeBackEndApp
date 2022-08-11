using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.BankaHesabiRepository.Validation
{
    public class BankaHesabiValidator : AbstractValidator<BankaHesabi>
    {
        public BankaHesabiValidator()
        {
        }
    }
}
