using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.YevmiyeFisiRepository.Constants
{
    public class YevmiyeFisiMessages
    {
        public static string Added = "Kayıt işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string CannotFindYevmiyeFisi = "Bu yevmiye fişine ait kayıt bulunamadı!";
    }
}
