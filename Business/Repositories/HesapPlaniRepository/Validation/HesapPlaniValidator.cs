using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.HesapPlaniRepository.Validation
{
    public class HesapPlaniValidator : AbstractValidator<HesapPlani>
    {
        public HesapPlaniValidator()
        {
            RuleFor(p => p.HesapKodu).NotNull().WithMessage("Hesap Kodu bo� olamaz");
            RuleFor(p => p.HesapKodu).NotEmpty().WithMessage("Hesap Kodu bo� olamaz");
            //RuleFor(p => p.HesapKodu).MinimumLength(4).WithMessage("Hesap Kodu en az 4 karakter olmal�d�r");
            RuleFor(p => p.HesapTuru).NotNull().WithMessage("Hesap T�r� bo� olamaz ve 1 karakter olmal�d�r");
            RuleFor(p => p.HesapTuru).NotEmpty().WithMessage("Hesap T�r� bo� olamaz ve 1 karakter olmal�d�r");
            RuleFor(p => p.HesapTuru).MaximumLength(1).WithMessage("Hesap T�r� bo� olamaz ve 1 karakter olmal�d�r");
            RuleFor(p => p.HesapTuru).MinimumLength(1).WithMessage("Hesap T�r� bo� olamaz ve 1 karakter olmal�d�r");
            RuleFor(p => p.HesapAdi).NotNull().WithMessage("Hesap Ad� bo� olamaz");
            RuleFor(p => p.HesapAdi).NotEmpty().WithMessage("Hesap Ad� bo� olamaz");
        }
    }
}
