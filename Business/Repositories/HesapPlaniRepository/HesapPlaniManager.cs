using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.HesapPlaniRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.HesapPlaniRepository.Validation;
using Business.Repositories.HesapPlaniRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.HesapPlaniRepository;
using Entities.Dtos;
using Core.Utilities.Business;
using Business.Repositories.YevmiyeFisiRepository;

namespace Business.Repositories.HesapPlaniRepository
{
    public class HesapPlaniManager : IHesapPlaniService
    {
        private readonly IHesapPlaniDal _hesapPlaniDal;
        private readonly IYevmiyeFisiService _yevmiyeFisiService;

        public HesapPlaniManager(IHesapPlaniDal hesapPlaniDal, IYevmiyeFisiService yevmiyeFisiService)
        {
            _hesapPlaniDal = hesapPlaniDal;
            _yevmiyeFisiService = yevmiyeFisiService;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(HesapPlaniValidator))]
        [RemoveCacheAspect("IHesapPlaniService.Get")]

        public async Task<IResult> TekDuzenHesapPlaniOlustur()
        {
            await HesapPlaniOlustur("100", "KASALAR");
            await HesapPlaniOlustur("101", "ALINAN �EKLER");
            await HesapPlaniOlustur("102", "BANKALAR");
            await HesapPlaniOlustur("103", "VER�LEN �EKLER VE �DEME EM�RLER� (-)");
            await HesapPlaniOlustur("108", "D��ER HAZIR DE�ERLER");
            await HesapPlaniOlustur("110", "H�SSE SENETLER�");
            await HesapPlaniOlustur("111", "�ZEL KES�M TAHV�L, SENET VE BONOLARI");
            await HesapPlaniOlustur("112", "KAMU KES�M� TAHV�L, SENET VE BONOLARI");
            await HesapPlaniOlustur("118", "D��ER MENKUL KIYMETLER");
            await HesapPlaniOlustur("119", "MENKUL KIYMETLER DE�ER D���KL��� KAR�ILI�I (-)");
            await HesapPlaniOlustur("120", "ALICILAR");
            await HesapPlaniOlustur("121", "ALACAK SENETLER�");
            await HesapPlaniOlustur("122", "ALACAK SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("126", "VER�LEN DEPOZ�TO VE TEM�NATLAR");
            await HesapPlaniOlustur("128", "��PHEL� T�CAR� ALACAKLAR");
            await HesapPlaniOlustur("129", "��PHEL� T�CAR� ALACAKLAR KAR�ILI�I (-)");
            await HesapPlaniOlustur("131", "ORTAKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("132", "��T�RAKLERDEN ALACAKLAR");
            await HesapPlaniOlustur("133", "BA�LI ORTAKLIKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("135", "PERSONELDEN ALACAKLAR");
            await HesapPlaniOlustur("136", "D��ER �E��TL� ALACAKLAR");
            await HesapPlaniOlustur("137", "D��ER ALACAK SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("138", "��PHEL� D��ER ALACAKLAR");
            await HesapPlaniOlustur("139", "��PHEL� D��ER ALACAKLAR KAR�ILI�I (-)");
            await HesapPlaniOlustur("150", "�LK MADDE VE MALZEME");
            await HesapPlaniOlustur("151", "YARI MAMULLER - �RET�M");
            await HesapPlaniOlustur("152", "MAM�LLER");
            await HesapPlaniOlustur("153", "T�CAR� MALLAR");
            await HesapPlaniOlustur("157", "D��ER STOKLAR");
            await HesapPlaniOlustur("158", "STOK DE�ER D���KL��� KAR�ILI�I (-)");
            await HesapPlaniOlustur("159", "VER�LEN S�PAR�� AVANSLARI");
            await HesapPlaniOlustur("180", "GELECEK AYLARA A�T G�DERLER");
            await HesapPlaniOlustur("181", "GEL�R TAHAKKUKLARI");
            await HesapPlaniOlustur("191", "�ND�R�LECEK KATMA DE�ER VERG�S�");
            await HesapPlaniOlustur("192", "D��ER KATMA DE�ER VERG�S�");
            await HesapPlaniOlustur("193", "PE��N �DENEN VERG�LER VE FONLAR");
            await HesapPlaniOlustur("196", "PERSONEL AVANSLARI");
            await HesapPlaniOlustur("197", "SAYIM VE TESELL�M NOKSANLARI");
            await HesapPlaniOlustur("198", "D��ER �E��TL� D�NEN VARLIKLAR");
            await HesapPlaniOlustur("199", "D��ER D�NEN VARLIKLAR KAR�ILI�I (-)");
            await HesapPlaniOlustur("220", "ALICILAR");
            await HesapPlaniOlustur("221", "ALACAK SENETLER�");
            await HesapPlaniOlustur("222", "ALACAK SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("226", "VER�LEN DEPOZ�TO VE TEM�NATLAR");
            await HesapPlaniOlustur("229", "��PHEL� ALACAKLAR KAR�ILI�I (-)");
            await HesapPlaniOlustur("230", "ORTAKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("231", "��T�RAKLERDEN ALACAKLAR");
            await HesapPlaniOlustur("232", "BA�LI ORTAKLIKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("235", "PERSONELDEN ALACAKLAR");
            await HesapPlaniOlustur("236", "D��ER �E��TL� ALACAKLAR");
            await HesapPlaniOlustur("237", "D��ER ALACAK SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("239", "��PHEL� D��ER ALACAKLAR KAR�ILI�I (-)");
            await HesapPlaniOlustur("240", "BA�LI MENKUL KIYMETLER");
            await HesapPlaniOlustur("241", "BA�LI MENKUL KIYMETLER DE�ER D���KL��� KAR�ILI�I (-)");
            await HesapPlaniOlustur("242", "��T�RAKLER");
            await HesapPlaniOlustur("243", "��T�RAKLERE SERMAYE TAAHH�TLER� (-)");
            await HesapPlaniOlustur("244", "��T�RAKLER SERMAYE PAYLARI DE�ER D���KL��� KAR�ILI�I (-)");
            await HesapPlaniOlustur("245", "BA�LI ORTAKLIKLAR");
            await HesapPlaniOlustur("246", "BA�LI ORTAKLIKLARA SERMAYE TAAHH�TLER� (-)");
            await HesapPlaniOlustur("247", "BA�LI ORTAKLIKLAR SERMAYE PAYLARI DE�ER D���KL�G� KAR�ILI�I (-)");
            await HesapPlaniOlustur("248", "D��ER MAL� DURAN VARLIKLAR");
            await HesapPlaniOlustur("249", "D��ER MAL� DURAN VARLIKLAR KAR�ILI�I (-)");
            await HesapPlaniOlustur("250", "ARAZ� VE ARSALAR");
            await HesapPlaniOlustur("251", "YER ALTI VE YER �ST� D�ZENLER�");
            await HesapPlaniOlustur("252", "B�NALAR");
            await HesapPlaniOlustur("253", "TES�S, MAK�NE VE C�HAZLAR");
            await HesapPlaniOlustur("254", "TA�ITLAR");
            await HesapPlaniOlustur("255", "DEM�RBA�LAR");
            await HesapPlaniOlustur("256", "D��ER MADD� DURAN VARLIKLAR");
            await HesapPlaniOlustur("257", "B�R�KM�� AMORT�SMANLAR (-)");
            await HesapPlaniOlustur("258", "YAPILMAKTA OLAN YATIRIMLAR");
            await HesapPlaniOlustur("259", "VER�LEN AVANSLAR");
            await HesapPlaniOlustur("260", "HAKLAR");
            await HesapPlaniOlustur("261", "�EREF�YE");
            await HesapPlaniOlustur("262", "KURULU� VE �RG�TLENME G�DERLER�");
            await HesapPlaniOlustur("263", "ARA�TIRMA VE GEL��T�RME G�DERLER�");
            await HesapPlaniOlustur("264", "�ZEL MAL�YETLER");
            await HesapPlaniOlustur("267", "D��ER MADD� OLMAYAN DURAN VARLIKLAR");
            await HesapPlaniOlustur("268", "B�R�KM�� AMORT�SMANLAR (-)");
            await HesapPlaniOlustur("269", "VER�LEN AVANSLAR");
            await HesapPlaniOlustur("271", "ARAMA G�DERLER�");
            await HesapPlaniOlustur("272", "HAZIRLIK VE GEL��T�RME G�DERLER�");
            await HesapPlaniOlustur("277", "D��ER �ZEL T�KENMEYE TAB� VARLIKLAR");
            await HesapPlaniOlustur("278", "B�R�KM�� T�KENME PAYLARI (-)");
            await HesapPlaniOlustur("279", "VER�LEN AVANSLAR");
            await HesapPlaniOlustur("280", "GELECEK YILLARA A�T G�DERLER");
            await HesapPlaniOlustur("281", "GEL�R TAHAKKUKLARI");
            await HesapPlaniOlustur("291", "GELECEK YILLARDA �ND�R�LECEK KATMA DE�ER VERG�S�");
            await HesapPlaniOlustur("292", "D��ER KATMA DE�ER VERG�S�");
            await HesapPlaniOlustur("293", "GELECEK YILLAR �HT�YACI STOKLAR");
            await HesapPlaniOlustur("294", "ELDEN �IKARILACAK STOKLAR VE MADD� DURAN VARLIKLAR");
            await HesapPlaniOlustur("297", "D��ER �E��TL� DURAN VARLIKLAR");
            await HesapPlaniOlustur("298", "STOK DE�ER D���KL��� KAR�ILI�I (-)");
            await HesapPlaniOlustur("299", "B�R�KM�� AMORT�SMANLAR (-)");
            await HesapPlaniOlustur("300", "BANKA KRED�LER�");
            await HesapPlaniOlustur("303", "UZUN VADEL� KRED�LER�N ANAPARA TAKS�TLER� VE FA�ZLER�");
            await HesapPlaniOlustur("304", "TAHV�L ANAPARA BOR�, TAKS�T VE FA�ZLER�");
            await HesapPlaniOlustur("305", "�IKARILMI� BONOLAR VE SENETLER");
            await HesapPlaniOlustur("306", "�IKARILMI� D��ER MENKUL KIYMETLER");
            await HesapPlaniOlustur("308", "MENKUL KIYMETLER �HRA� FARKI (-)");
            await HesapPlaniOlustur("309", "D��ER MAL� BOR�LAR");
            await HesapPlaniOlustur("320", "SATICILAR");
            await HesapPlaniOlustur("321", "BOR� SENETLER�");
            await HesapPlaniOlustur("322", "BOR� SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("326", "ALINAN DEPOZ�TO VE TEM�NATLAR");
            await HesapPlaniOlustur("329", "D��ER T�CAR� BOR�LAR");
            await HesapPlaniOlustur("331", "ORTAKLARA BOR�LAR");
            await HesapPlaniOlustur("332", "��T�RAKLERE BOR�LAR");
            await HesapPlaniOlustur("333", "BA�LI ORTAKLIKLARA BOR�LAR");
            await HesapPlaniOlustur("335", "PERSONELE BOR�LAR");
            await HesapPlaniOlustur("337", "D��ER BOR� SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("339", "D��ER �E��TL� BOR�LAR(1)");
            await HesapPlaniOlustur("340", "ALINAN S�PAR�� AVANSLARI");
            await HesapPlaniOlustur("349", "ALINAN D��ER AVANSLAR");
            await HesapPlaniOlustur("360", "�DENECEK VERG� VE FONLAR");
            await HesapPlaniOlustur("361", "�DENECEK SOSYAL G�VENL�K KES�NT�LER�");
            await HesapPlaniOlustur("368", "VADES� GE�M�� ERTELENM�� VEYA TAKS�TLEND�R�LM�� VERG� VE D��ER Y�K�ML�L�KLER");
            await HesapPlaniOlustur("369", "�DENECEK D��ER Y�K�ML�L�KLER");
            await HesapPlaniOlustur("370", "D�NEM K�RI VERG� VE D��ER YASAL Y�K�ML�L�K KAR�ILIKLARI");
            await HesapPlaniOlustur("371", "D�NEM K�RININ PE��N �DENEN VERG� VE D��ER Y�K�ML�L�KLER� (-)");
            await HesapPlaniOlustur("372", "KIDEM TAZM�NATI KAR�ILI�I");
            await HesapPlaniOlustur("373", "MAL�YET G�DERLER� KAR�ILI�I");
            await HesapPlaniOlustur("379", "D��ER BOR� VE G�DER KAR�ILIKLARI");
            await HesapPlaniOlustur("380", "GELECEK AYLARA A�T GEL�RLER");
            await HesapPlaniOlustur("381", "G�DER TAHAKKUKLARI");
            await HesapPlaniOlustur("391", "HESAPLANAN KDV");
            await HesapPlaniOlustur("392", "D��ER KDV");
            await HesapPlaniOlustur("398", "SAYIM VE TESELL�M FAZLALARI(1)");
            await HesapPlaniOlustur("399", "D��ER �E��TL� YABANCI KAYNAKLAR");
            await HesapPlaniOlustur("400", "BANKA KRED�LER�");
            await HesapPlaniOlustur("405", "�IKARILMI� TAHV�LLER");
            await HesapPlaniOlustur("407", "�IKARILMI� D��ER MENKUL KIYMETLER");
            await HesapPlaniOlustur("408", "MENKUL KIYMETLER �HRA� FARKI (-)");
            await HesapPlaniOlustur("409", "D��ER MAL� BOR�LAR");
            await HesapPlaniOlustur("420", "SATICILAR");
            await HesapPlaniOlustur("421", "BOR� SENETLER�");
            await HesapPlaniOlustur("422", "BOR� SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("426", "ALINAN DEPOZ�TO VE TEM�NATLAR");
            await HesapPlaniOlustur("429", "D��ER T�CAR� BOR�LAR");
            await HesapPlaniOlustur("431", "ORTAKLARA BOR�LAR");
            await HesapPlaniOlustur("432", "��T�RAKLERE BOR�LAR");
            await HesapPlaniOlustur("433", "BA�LI ORTAKLIKLARA BOR�LAR");
            await HesapPlaniOlustur("437", "D��ER BOR� SENETLER� REESKONTU (-)");
            await HesapPlaniOlustur("438", "KAMUYA OLAN ERTELENM�� VEYA TAKS�TLEND�R�LM�� BOR�LAR");
            await HesapPlaniOlustur("439", "D��ER �E��TL� BOR�LAR(1)");
            await HesapPlaniOlustur("440", "ALINAN S�PAR�� AVANSLARI");
            await HesapPlaniOlustur("449", "ALINAN D��ER AVANSLAR");
            await HesapPlaniOlustur("472", "KIDEM TAZM�NATI KAR�ILI�I");
            await HesapPlaniOlustur("479", "D��ER BOR� VE G�DER KAR�ILIKLARI");
            await HesapPlaniOlustur("480", "GELECEK YILLARA A�T GEL�RLER");
            await HesapPlaniOlustur("481", "G�DER TAHAKKUKLARI");
            await HesapPlaniOlustur("492", "GELECEK YILLARA ERTELENEN VEYA TERK�N ED�LEN KATMA DE�ER VERG�S�(1)");
            await HesapPlaniOlustur("493", "TES�SE KATILMA PAYLARI");
            await HesapPlaniOlustur("499", "D��ER �E��TL� UZUN VADEL� YABANCI KAYNAKLAR");
            await HesapPlaniOlustur("500", "SERMAYE");
            await HesapPlaniOlustur("501", "�DENMEM�� SERMAYE (-)");
            await HesapPlaniOlustur("520", "H�SSE SENETLER� �HRA� PR�MLER�");
            await HesapPlaniOlustur("521", "H�SSE SENED� �PTAL K�RLARI");
            await HesapPlaniOlustur("522", "M.D.V. YEN�DEN DE�ERLEME ARTI�LARI");
            await HesapPlaniOlustur("523", "��T�RAKLER YEN�DEN DE�ERLEME ARTI�LARI");
            await HesapPlaniOlustur("529", "D��ER SERMAYE YEDEKLER�");
            await HesapPlaniOlustur("540", "YASAL YEDEKLER");
            await HesapPlaniOlustur("541", "STAT� YEDEKLER�");
            await HesapPlaniOlustur("542", "OLA�AN�ST� YEDEKLER");
            await HesapPlaniOlustur("548", "D��ER K�R YEDEKLER�");
            await HesapPlaniOlustur("549", "�ZEL FONLAR");
            await HesapPlaniOlustur("570", "GE�M�� YILLAR K�RLARI");
            await HesapPlaniOlustur("580", "GE�M�� YILLAR ZARARLARI");
            await HesapPlaniOlustur("590", "D�NEM NET K�RI");
            await HesapPlaniOlustur("591", "D�NEM NET ZARARI (-)");
            await HesapPlaniOlustur("600", "YURT��� SATI�LAR");
            await HesapPlaniOlustur("601", "YURTDI�I SATI�LAR");
            await HesapPlaniOlustur("602", "D��ER GEL�RLER");
            await HesapPlaniOlustur("610", "SATI�TAN �ADELER (-)");
            await HesapPlaniOlustur("611", "SATI� �SKONTOLARI (-)");
            await HesapPlaniOlustur("612", "D��ER �ND�R�MLER (-)");
            await HesapPlaniOlustur("620", "SATILAN MAM�LLER MAL�YET� (-)");
            await HesapPlaniOlustur("621", "SATILAN T�CAR� MALLAR MAL�YET� (-)");
            await HesapPlaniOlustur("622", "SATILAN H�ZMET MAL�YET� (-)");
            await HesapPlaniOlustur("623", "D��ER SATI�LARIN MAL�YET� (-)");
            await HesapPlaniOlustur("630", "ARA�TIRMA VE GEL��T�RME G�DERLER� (-)");
            await HesapPlaniOlustur("631", "PAZARLAMA SATI� VE DA�ITIM G�DERLER�");
            await HesapPlaniOlustur("632", "GENEL Y�NET�M G�DERLER� (-)");
            await HesapPlaniOlustur("640", "��T�RAKLERDEN TEMETT� GEL�RLER�");
            await HesapPlaniOlustur("641", "BA�LI ORTAKLIKLARDAN TEMETT� GEL�RLER�");
            await HesapPlaniOlustur("642", "FA�Z GEL�RLER�");
            await HesapPlaniOlustur("643", "KOM�SYON GEL�RLER�");
            await HesapPlaniOlustur("644", "KONUSU KALMAYAN KAR�ILIKLAR");
            await HesapPlaniOlustur("649", "FAAL�YETLE �LG�L� D��ER GEL�R VE K�RLAR");
            await HesapPlaniOlustur("652", "REESKONT FA�Z G�DERLER� (-)(1)");
            await HesapPlaniOlustur("653", "KOM�SYON G�DERLER� (-)");
            await HesapPlaniOlustur("654", "KAR�ILIK G�DERLER� (-)");
            await HesapPlaniOlustur("659", "D��ER G�DER VE ZARARLAR (-)");
            await HesapPlaniOlustur("660", "KISA VADEL� BOR�LANMA G�DERLER� (-)");
            await HesapPlaniOlustur("661", "UZUN VADEL� BOR�LANMA G�DERLER� (-)");
            await HesapPlaniOlustur("671", "�NCEK� D�NEM GEL�R VE K�RLARI");
            await HesapPlaniOlustur("679", "D��ER OLA�ANDI�I GEL�R VE K�RLAR");
            await HesapPlaniOlustur("680", "�ALI�MAYAN KISIM G�DER VE ZARARLARI (-)");
            await HesapPlaniOlustur("681", "�NCEK� D�NEM G�DER VE ZARARLARI (-)");
            await HesapPlaniOlustur("689", "D��ER OLA�ANDI�I G�DER VE ZARARLAR (-)");
            await HesapPlaniOlustur("690", "D�NEM K�RI VEYA ZARARI");
            await HesapPlaniOlustur("691", "D�NEM K�RI VERG� VE D��ER YASAL Y�K�ML�L�K KAR�ILIKLARI (-)");
            await HesapPlaniOlustur("692", "D�NEM NET K�RI VEYA ZARARI");
            await HesapPlaniOlustur("700", "MAL�YET MUHASEBES� BA�LANTI HESABI");
            await HesapPlaniOlustur("701", "MAL�YET MUHASEBES� YANSITMA HESABI");
            await HesapPlaniOlustur("710", "D�REKT �LKMADDE VE MALZEME G�DERLER�");
            await HesapPlaniOlustur("711", "D�REKT �LKMADDE VE MALZEME YANSITMA HESABI");
            await HesapPlaniOlustur("712", "D�REKT �LKMADDE VE MALZEME F�YAT FARKI");
            await HesapPlaniOlustur("713", "D�REKT �LKMADDE VE MALZEME M�KTAR FARKI");
            await HesapPlaniOlustur("720", "D�REKT ����L�K G�DERLER�");
            await HesapPlaniOlustur("721", "D�REKT ��C�L�K G�DERLER� YANSITMA HESABI");
            await HesapPlaniOlustur("722", "D�REKT ����L�K �CRET FARKLARI");
            await HesapPlaniOlustur("723", "D�REKT ����L�K S�RE (ZAMAN) FARKLARI");
            await HesapPlaniOlustur("730", "GENEL �RET�M G�DERLER�");
            await HesapPlaniOlustur("731", "GENEL �RET�M G�DERLER� YANSITMA HESABI");
            await HesapPlaniOlustur("732", "GENEL �RET�M G�DERLER� B�T�E FARKLARI");
            await HesapPlaniOlustur("733", "GENEL �RET�M G�DERLER� VER�ML�L�K FARKLARI");
            await HesapPlaniOlustur("734", "GENEL �RET�M G�DERLER� KAPAS�TE FARKLARI");
            await HesapPlaniOlustur("740", "H�ZMET �RET�M MAL�YET�");
            await HesapPlaniOlustur("741", "H�ZMET �RET�M MAL�YET� YANSITMA HESABI");
            await HesapPlaniOlustur("742", "H�ZMET �RET�M MAL�YET� FARK HESAPLARI");
            await HesapPlaniOlustur("750", "ARA�TIRMA VE GEL��T�RME G�DERLER�");
            await HesapPlaniOlustur("751", "ARA�TIRMA VE GEL��T�RME G�DERLER� YANSITMA HESABI");
            await HesapPlaniOlustur("752", "ARA�TIRMA VE GEL��T�RME G�DER FARKLARI");
            await HesapPlaniOlustur("760", "PAZARLAMA SATI� VE DA�ITIM G�DERLER�");
            await HesapPlaniOlustur("761", "PAZARLAMA SATI� VE DA�ITIM G�DERLER� YANSITMA HESABI");
            await HesapPlaniOlustur("762", "PAZARLAMA SATI� VE DA�ITIM G�DERLER� FARK HESABI");
            await HesapPlaniOlustur("770", "GENEL Y�NET�M G�DERLER�");
            await HesapPlaniOlustur("771", "GENEL Y�NET�M G�DERLER� YANSITMA HESABI");
            await HesapPlaniOlustur("772", "GENEL Y�NET�M G�DER FARKLARI HESABI");
            await HesapPlaniOlustur("780", "F�NANSMAN G�DERLER�");
            await HesapPlaniOlustur("781", "F�NANSMAN G�DERLER� YANSITMA HESABI");
            await HesapPlaniOlustur("782", "F�NANSMAN G�DERLER� FARK HESABI");
            await HesapPlaniOlustur("790", "�LKMADDE VE MALZEME G�DERLER�");
            await HesapPlaniOlustur("791", "���� �CRET VE G�DERLER�");
            await HesapPlaniOlustur("792", "MEMUR �CRET VE G�DERLER�");
            await HesapPlaniOlustur("793", "DI�ARIDAN SA�LANAN FAYDA VE H�ZMETLER");
            await HesapPlaniOlustur("794", "�E��TL� G�DERLER");
            await HesapPlaniOlustur("795", "VERG�, RES�M VE HAR�LAR");
            await HesapPlaniOlustur("796", "AMORT�SMANLAR VE T�KENME PAYLARI");
            await HesapPlaniOlustur("797", "F�NANSMAN G�DERLER�");
            await HesapPlaniOlustur("798", "G�DER �E��TLER� YANSITMA HESABI");
            await HesapPlaniOlustur("799", "�RET�M MAL�YET HESABI");
            await HesapPlaniOlustur("900", "NAZIM HESAPLAR");

            return new SuccessResult(HesapPlaniMessages.Added);
        }

        public async Task HesapPlaniOlustur(string hesapKodu, string hesapAdi)
        {
            HesapPlani hesapPlani = new HesapPlani()
            {
                HesapKodu = hesapKodu,
                HesapAdi = hesapAdi,
                HesapTuru = "A"
            };

            var result = await _hesapPlaniDal.Get(p => p.HesapKodu == hesapKodu);
            if (result == null)
            {
                await _hesapPlaniDal.Add(hesapPlani);
            }

        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(HesapPlaniValidator))]
        [RemoveCacheAspect("IHesapPlaniService.Get")]

        public async Task<IResult> Add(HesapPlani hesapPlani)
        {
            var result = BusinessRules.Run(await HesapPlaniKoduVarMiKontrolEt(hesapPlani.HesapKodu));
            if (result != null)
            {
                return result;
            }

            await _hesapPlaniDal.Add(hesapPlani);
            return new SuccessResult(HesapPlaniMessages.Added);
        }

        public async Task<IResult> HesapPlaniKoduVarMiKontrolEt(string hesapPlaniKodu)
        {
            var result = await _hesapPlaniDal.Get(p => p.HesapKodu == hesapPlaniKodu);
            if (result != null)
            {
                return new ErrorResult("Hesap plan� kodu daha �nce a��lm��!");
            }
            return new SuccessResult();
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(HesapPlaniValidator))]
        [RemoveCacheAspect("IHesapPlaniService.Get")]

        public async Task<IResult> Update(HesapPlani hesapPlani)
        {
            await _hesapPlaniDal.Update(hesapPlani);
            return new SuccessResult(HesapPlaniMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IHesapPlaniService.Get")]

        public async Task<IResult> Delete(int hesapPlaniId)
        {
            var hesapPlani = await _hesapPlaniDal.Get(p => p.Id == hesapPlaniId);

            await _hesapPlaniDal.Delete(hesapPlani);
            return new SuccessResult(HesapPlaniMessages.Deleted);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IHesapPlaniService.Get")]

        public async Task<IResult> DeleteByHesapPlaniModule(int hesapPlaniId)
        {
            var hesapPlani = await _hesapPlaniDal.Get(p => p.Id == hesapPlaniId);

            if (hesapPlani == null)
            {
                return new ErrorResult("Yazd���n�z hesap plan� kodu kay�tlarda yok!");
            }

            var result = BusinessRules.Run(                
                AnaHesapKoduMu(hesapPlani.HesapTuru),
                await GrupHesapKoduMu(hesapPlani.HesapTuru, hesapPlani.HesapKodu),
                ModuleHesapKoduMu(hesapPlani.HesapTuru, hesapPlani.HesapKodu),
                BankaYevmiyeKayitiniKontrolEt(hesapPlaniId));

            if (result != null)
            {
                return result;
            }

            await _hesapPlaniDal.Delete(hesapPlani);
            return new SuccessResult(HesapPlaniMessages.Deleted);
        }       
        
        public IResult AnaHesapKoduMu(string hesapTuru)
        {
            if (hesapTuru == "A")
            {
                return new ErrorResult("Ana hesap kodlar� silinemez!");
            }
            return new SuccessResult();
        }

        public async Task<IResult> GrupHesapKoduMu(string hesapTuru, string hesapKodu)
        {
            if (hesapTuru == "G")
            {
                var result = await _hesapPlaniDal.GetAll(p => p.HesapKodu.StartsWith(hesapKodu) && p.HesapTuru == "M");
                if (result.Count > 0)
                {
                    return new ErrorResult("Muavin hesap kodu bulunan grup hesap kodu silinemez!");
                }
            }
            return new SuccessResult();
        }

        public IResult ModuleHesapKoduMu(string hesapTuru, string hesapKodu)
        {
            if (hesapTuru == "M")
            {
                List<string> silinmeyecekHesapKodlar� = new()
                {
                    "102",
                    "120",
                    "127",
                    "128",
                    "131",
                    "320",
                    "335"
                };


                foreach (var item in silinmeyecekHesapKodlar�)
                {
                    if (hesapKodu.StartsWith(item))
                    {
                        return new ErrorResult("Module'da kayd� bulunan hesap plan� kodu silinemez!");
                    }
                }                
            }
            return new SuccessResult();
        }

        public IResult BankaYevmiyeKayitiniKontrolEt(int hesapPlaniId)
        {
            string tarih1 = "01.01." + DateTime.Now.Year.ToString();
            string tarih2 = "31.12." + DateTime.Now.Year.ToString();

            var result = _yevmiyeFisiService.GetYevmiyeFisiWithHesapPlaniId(hesapPlaniId, tarih1, tarih2);
            if (result.Data.Count > 0)
            {
                return new ErrorResult("Hareket kayd� olan hesap plan� kodu silinemez!");
            }
            return new SuccessResult();
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<HesapPlani>>> GetList()
        {
            var result = await _hesapPlaniDal.GetAll();
            return new SuccessDataResult<List<HesapPlani>>(result.OrderBy(p=> p.HesapKodu).ToList());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<HesapPlani>> GetById(int id)
        {
            return new SuccessDataResult<HesapPlani>(await _hesapPlaniDal.Get(p => p.Id == id));
        }

        public IDataResult<List<MizanDto>> GetTarihAralikliMizan(string tarih1, string tarih2)
        {
            if (tarih1 == null || tarih1 == "")
            {
                tarih1 = "01.01." + DateTime.Now.Year.ToString();
            }

            if (tarih2 == null || tarih2 == "")
            {
                tarih2 = "31.12." + DateTime.Now.Year.ToString();
            }

            var result = _hesapPlaniDal.GetTarihAralikliMizan(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2));
            return new SuccessDataResult<List<MizanDto>>(result);
        }

        public IDataResult<List<MizanDto>> GetKasaList()
        {
            var result = _hesapPlaniDal.GetKasaList();
            return new SuccessDataResult<List<MizanDto>>(result);
        }
    }
}
