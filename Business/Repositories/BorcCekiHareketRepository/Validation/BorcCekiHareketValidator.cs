using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.BorcCekiHareketRepository.Validation
{
    public class BorcCekiHareketValidator : AbstractValidator<BorcCekiHareket>
    {
        public BorcCekiHareketValidator()
        {
        }
    }
}
