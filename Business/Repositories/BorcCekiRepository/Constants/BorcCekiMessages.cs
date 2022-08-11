using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.BorcCekiRepository.Constants
{
    public class BorcCekiMessages
    {
        public static string Added = "Kayıt işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string CannotFindMuhasebeKodu = "Borç çeki muhasebe kodu bulunamadı!";
    }
}
