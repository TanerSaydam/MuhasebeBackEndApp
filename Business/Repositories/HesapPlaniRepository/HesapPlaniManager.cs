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
            await HesapPlaniOlustur("101", "ALINAN ÇEKLER");
            await HesapPlaniOlustur("102", "BANKALAR");
            await HesapPlaniOlustur("103", "VERÝLEN ÇEKLER VE ÖDEME EMÝRLERÝ (-)");
            await HesapPlaniOlustur("108", "DÝÐER HAZIR DEÐERLER");
            await HesapPlaniOlustur("110", "HÝSSE SENETLERÝ");
            await HesapPlaniOlustur("111", "ÖZEL KESÝM TAHVÝL, SENET VE BONOLARI");
            await HesapPlaniOlustur("112", "KAMU KESÝMÝ TAHVÝL, SENET VE BONOLARI");
            await HesapPlaniOlustur("118", "DÝÐER MENKUL KIYMETLER");
            await HesapPlaniOlustur("119", "MENKUL KIYMETLER DEÐER DÜÞÜKLÜÐÜ KARÞILIÐI (-)");
            await HesapPlaniOlustur("120", "ALICILAR");
            await HesapPlaniOlustur("121", "ALACAK SENETLERÝ");
            await HesapPlaniOlustur("122", "ALACAK SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("126", "VERÝLEN DEPOZÝTO VE TEMÝNATLAR");
            await HesapPlaniOlustur("128", "ÞÜPHELÝ TÝCARÝ ALACAKLAR");
            await HesapPlaniOlustur("129", "ÞÜPHELÝ TÝCARÝ ALACAKLAR KARÞILIÐI (-)");
            await HesapPlaniOlustur("131", "ORTAKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("132", "ÝÞTÝRAKLERDEN ALACAKLAR");
            await HesapPlaniOlustur("133", "BAÐLI ORTAKLIKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("135", "PERSONELDEN ALACAKLAR");
            await HesapPlaniOlustur("136", "DÝÐER ÇEÞÝTLÝ ALACAKLAR");
            await HesapPlaniOlustur("137", "DÝÐER ALACAK SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("138", "ÞÜPHELÝ DÝÐER ALACAKLAR");
            await HesapPlaniOlustur("139", "ÞÜPHELÝ DÝÐER ALACAKLAR KARÞILIÐI (-)");
            await HesapPlaniOlustur("150", "ÝLK MADDE VE MALZEME");
            await HesapPlaniOlustur("151", "YARI MAMULLER - ÜRETÝM");
            await HesapPlaniOlustur("152", "MAMÜLLER");
            await HesapPlaniOlustur("153", "TÝCARÝ MALLAR");
            await HesapPlaniOlustur("157", "DÝÐER STOKLAR");
            await HesapPlaniOlustur("158", "STOK DEÐER DÜÞÜKLÜÐÜ KARÞILIÐI (-)");
            await HesapPlaniOlustur("159", "VERÝLEN SÝPARÝÞ AVANSLARI");
            await HesapPlaniOlustur("180", "GELECEK AYLARA AÝT GÝDERLER");
            await HesapPlaniOlustur("181", "GELÝR TAHAKKUKLARI");
            await HesapPlaniOlustur("191", "ÝNDÝRÝLECEK KATMA DEÐER VERGÝSÝ");
            await HesapPlaniOlustur("192", "DÝÐER KATMA DEÐER VERGÝSÝ");
            await HesapPlaniOlustur("193", "PEÞÝN ÖDENEN VERGÝLER VE FONLAR");
            await HesapPlaniOlustur("196", "PERSONEL AVANSLARI");
            await HesapPlaniOlustur("197", "SAYIM VE TESELLÜM NOKSANLARI");
            await HesapPlaniOlustur("198", "DÝÐER ÇEÞÝTLÝ DÖNEN VARLIKLAR");
            await HesapPlaniOlustur("199", "DÝÐER DÖNEN VARLIKLAR KARÞILIÐI (-)");
            await HesapPlaniOlustur("220", "ALICILAR");
            await HesapPlaniOlustur("221", "ALACAK SENETLERÝ");
            await HesapPlaniOlustur("222", "ALACAK SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("226", "VERÝLEN DEPOZÝTO VE TEMÝNATLAR");
            await HesapPlaniOlustur("229", "ÞÜPHELÝ ALACAKLAR KARÞILIÐI (-)");
            await HesapPlaniOlustur("230", "ORTAKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("231", "ÝÞTÝRAKLERDEN ALACAKLAR");
            await HesapPlaniOlustur("232", "BAÐLI ORTAKLIKLARDAN ALACAKLAR");
            await HesapPlaniOlustur("235", "PERSONELDEN ALACAKLAR");
            await HesapPlaniOlustur("236", "DÝÐER ÇEÞÝTLÝ ALACAKLAR");
            await HesapPlaniOlustur("237", "DÝÐER ALACAK SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("239", "ÞÜPHELÝ DÝÐER ALACAKLAR KARÞILIÐI (-)");
            await HesapPlaniOlustur("240", "BAÐLI MENKUL KIYMETLER");
            await HesapPlaniOlustur("241", "BAÐLI MENKUL KIYMETLER DEÐER DÜÞÜKLÜÐÜ KARÞILIÐI (-)");
            await HesapPlaniOlustur("242", "ÝÞTÝRAKLER");
            await HesapPlaniOlustur("243", "ÝÞTÝRAKLERE SERMAYE TAAHHÜTLERÝ (-)");
            await HesapPlaniOlustur("244", "ÝÞTÝRAKLER SERMAYE PAYLARI DEÐER DÜÞÜKLÜÐÜ KARÞILIÐI (-)");
            await HesapPlaniOlustur("245", "BAÐLI ORTAKLIKLAR");
            await HesapPlaniOlustur("246", "BAÐLI ORTAKLIKLARA SERMAYE TAAHHÜTLERÝ (-)");
            await HesapPlaniOlustur("247", "BAÐLI ORTAKLIKLAR SERMAYE PAYLARI DEÐER DÜÞÜKLÜGÜ KARÞILIÐI (-)");
            await HesapPlaniOlustur("248", "DÝÐER MALÝ DURAN VARLIKLAR");
            await HesapPlaniOlustur("249", "DÝÐER MALÝ DURAN VARLIKLAR KARÞILIÐI (-)");
            await HesapPlaniOlustur("250", "ARAZÝ VE ARSALAR");
            await HesapPlaniOlustur("251", "YER ALTI VE YER ÜSTÜ DÜZENLERÝ");
            await HesapPlaniOlustur("252", "BÝNALAR");
            await HesapPlaniOlustur("253", "TESÝS, MAKÝNE VE CÝHAZLAR");
            await HesapPlaniOlustur("254", "TAÞITLAR");
            await HesapPlaniOlustur("255", "DEMÝRBAÞLAR");
            await HesapPlaniOlustur("256", "DÝÐER MADDÝ DURAN VARLIKLAR");
            await HesapPlaniOlustur("257", "BÝRÝKMÝÞ AMORTÝSMANLAR (-)");
            await HesapPlaniOlustur("258", "YAPILMAKTA OLAN YATIRIMLAR");
            await HesapPlaniOlustur("259", "VERÝLEN AVANSLAR");
            await HesapPlaniOlustur("260", "HAKLAR");
            await HesapPlaniOlustur("261", "ÞEREFÝYE");
            await HesapPlaniOlustur("262", "KURULUÞ VE ÖRGÜTLENME GÝDERLERÝ");
            await HesapPlaniOlustur("263", "ARAÞTIRMA VE GELÝÞTÝRME GÝDERLERÝ");
            await HesapPlaniOlustur("264", "ÖZEL MALÝYETLER");
            await HesapPlaniOlustur("267", "DÝÐER MADDÝ OLMAYAN DURAN VARLIKLAR");
            await HesapPlaniOlustur("268", "BÝRÝKMÝÞ AMORTÝSMANLAR (-)");
            await HesapPlaniOlustur("269", "VERÝLEN AVANSLAR");
            await HesapPlaniOlustur("271", "ARAMA GÝDERLERÝ");
            await HesapPlaniOlustur("272", "HAZIRLIK VE GELÝÞTÝRME GÝDERLERÝ");
            await HesapPlaniOlustur("277", "DÝÐER ÖZEL TÜKENMEYE TABÝ VARLIKLAR");
            await HesapPlaniOlustur("278", "BÝRÝKMÝÞ TÜKENME PAYLARI (-)");
            await HesapPlaniOlustur("279", "VERÝLEN AVANSLAR");
            await HesapPlaniOlustur("280", "GELECEK YILLARA AÝT GÝDERLER");
            await HesapPlaniOlustur("281", "GELÝR TAHAKKUKLARI");
            await HesapPlaniOlustur("291", "GELECEK YILLARDA ÝNDÝRÝLECEK KATMA DEÐER VERGÝSÝ");
            await HesapPlaniOlustur("292", "DÝÐER KATMA DEÐER VERGÝSÝ");
            await HesapPlaniOlustur("293", "GELECEK YILLAR ÝHTÝYACI STOKLAR");
            await HesapPlaniOlustur("294", "ELDEN ÇIKARILACAK STOKLAR VE MADDÝ DURAN VARLIKLAR");
            await HesapPlaniOlustur("297", "DÝÐER ÇEÞÝTLÝ DURAN VARLIKLAR");
            await HesapPlaniOlustur("298", "STOK DEÐER DÜÞÜKLÜÐÜ KARÞILIÐI (-)");
            await HesapPlaniOlustur("299", "BÝRÝKMÝÞ AMORTÝSMANLAR (-)");
            await HesapPlaniOlustur("300", "BANKA KREDÝLERÝ");
            await HesapPlaniOlustur("303", "UZUN VADELÝ KREDÝLERÝN ANAPARA TAKSÝTLERÝ VE FAÝZLERÝ");
            await HesapPlaniOlustur("304", "TAHVÝL ANAPARA BORÇ, TAKSÝT VE FAÝZLERÝ");
            await HesapPlaniOlustur("305", "ÇIKARILMIÞ BONOLAR VE SENETLER");
            await HesapPlaniOlustur("306", "ÇIKARILMIÞ DÝÐER MENKUL KIYMETLER");
            await HesapPlaniOlustur("308", "MENKUL KIYMETLER ÝHRAÇ FARKI (-)");
            await HesapPlaniOlustur("309", "DÝÐER MALÝ BORÇLAR");
            await HesapPlaniOlustur("320", "SATICILAR");
            await HesapPlaniOlustur("321", "BORÇ SENETLERÝ");
            await HesapPlaniOlustur("322", "BORÇ SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("326", "ALINAN DEPOZÝTO VE TEMÝNATLAR");
            await HesapPlaniOlustur("329", "DÝÐER TÝCARÝ BORÇLAR");
            await HesapPlaniOlustur("331", "ORTAKLARA BORÇLAR");
            await HesapPlaniOlustur("332", "ÝÞTÝRAKLERE BORÇLAR");
            await HesapPlaniOlustur("333", "BAÐLI ORTAKLIKLARA BORÇLAR");
            await HesapPlaniOlustur("335", "PERSONELE BORÇLAR");
            await HesapPlaniOlustur("337", "DÝÐER BORÇ SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("339", "DÝÐER ÇEÞÝTLÝ BORÇLAR(1)");
            await HesapPlaniOlustur("340", "ALINAN SÝPARÝÞ AVANSLARI");
            await HesapPlaniOlustur("349", "ALINAN DÝÐER AVANSLAR");
            await HesapPlaniOlustur("360", "ÖDENECEK VERGÝ VE FONLAR");
            await HesapPlaniOlustur("361", "ÖDENECEK SOSYAL GÜVENLÝK KESÝNTÝLERÝ");
            await HesapPlaniOlustur("368", "VADESÝ GEÇMÝÞ ERTELENMÝÞ VEYA TAKSÝTLENDÝRÝLMÝÞ VERGÝ VE DÝÐER YÜKÜMLÜLÜKLER");
            await HesapPlaniOlustur("369", "ÖDENECEK DÝÐER YÜKÜMLÜLÜKLER");
            await HesapPlaniOlustur("370", "DÖNEM KÂRI VERGÝ VE DÝÐER YASAL YÜKÜMLÜLÜK KARÞILIKLARI");
            await HesapPlaniOlustur("371", "DÖNEM KÂRININ PEÞÝN ÖDENEN VERGÝ VE DÝÐER YÜKÜMLÜLÜKLERÝ (-)");
            await HesapPlaniOlustur("372", "KIDEM TAZMÝNATI KARÞILIÐI");
            await HesapPlaniOlustur("373", "MALÝYET GÝDERLERÝ KARÞILIÐI");
            await HesapPlaniOlustur("379", "DÝÐER BORÇ VE GÝDER KARÞILIKLARI");
            await HesapPlaniOlustur("380", "GELECEK AYLARA AÝT GELÝRLER");
            await HesapPlaniOlustur("381", "GÝDER TAHAKKUKLARI");
            await HesapPlaniOlustur("391", "HESAPLANAN KDV");
            await HesapPlaniOlustur("392", "DÝÐER KDV");
            await HesapPlaniOlustur("398", "SAYIM VE TESELLÜM FAZLALARI(1)");
            await HesapPlaniOlustur("399", "DÝÐER ÇEÞÝTLÝ YABANCI KAYNAKLAR");
            await HesapPlaniOlustur("400", "BANKA KREDÝLERÝ");
            await HesapPlaniOlustur("405", "ÇIKARILMIÞ TAHVÝLLER");
            await HesapPlaniOlustur("407", "ÇIKARILMIÞ DÝÐER MENKUL KIYMETLER");
            await HesapPlaniOlustur("408", "MENKUL KIYMETLER ÝHRAÇ FARKI (-)");
            await HesapPlaniOlustur("409", "DÝÐER MALÝ BORÇLAR");
            await HesapPlaniOlustur("420", "SATICILAR");
            await HesapPlaniOlustur("421", "BORÇ SENETLERÝ");
            await HesapPlaniOlustur("422", "BORÇ SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("426", "ALINAN DEPOZÝTO VE TEMÝNATLAR");
            await HesapPlaniOlustur("429", "DÝÐER TÝCARÝ BORÇLAR");
            await HesapPlaniOlustur("431", "ORTAKLARA BORÇLAR");
            await HesapPlaniOlustur("432", "ÝÞTÝRAKLERE BORÇLAR");
            await HesapPlaniOlustur("433", "BAÐLI ORTAKLIKLARA BORÇLAR");
            await HesapPlaniOlustur("437", "DÝÐER BORÇ SENETLERÝ REESKONTU (-)");
            await HesapPlaniOlustur("438", "KAMUYA OLAN ERTELENMÝÞ VEYA TAKSÝTLENDÝRÝLMÝÞ BORÇLAR");
            await HesapPlaniOlustur("439", "DÝÐER ÇEÞÝTLÝ BORÇLAR(1)");
            await HesapPlaniOlustur("440", "ALINAN SÝPARÝÞ AVANSLARI");
            await HesapPlaniOlustur("449", "ALINAN DÝÐER AVANSLAR");
            await HesapPlaniOlustur("472", "KIDEM TAZMÝNATI KARÞILIÐI");
            await HesapPlaniOlustur("479", "DÝÐER BORÇ VE GÝDER KARÞILIKLARI");
            await HesapPlaniOlustur("480", "GELECEK YILLARA AÝT GELÝRLER");
            await HesapPlaniOlustur("481", "GÝDER TAHAKKUKLARI");
            await HesapPlaniOlustur("492", "GELECEK YILLARA ERTELENEN VEYA TERKÝN EDÝLEN KATMA DEÐER VERGÝSÝ(1)");
            await HesapPlaniOlustur("493", "TESÝSE KATILMA PAYLARI");
            await HesapPlaniOlustur("499", "DÝÐER ÇEÞÝTLÝ UZUN VADELÝ YABANCI KAYNAKLAR");
            await HesapPlaniOlustur("500", "SERMAYE");
            await HesapPlaniOlustur("501", "ÖDENMEMÝÞ SERMAYE (-)");
            await HesapPlaniOlustur("520", "HÝSSE SENETLERÝ ÝHRAÇ PRÝMLERÝ");
            await HesapPlaniOlustur("521", "HÝSSE SENEDÝ ÝPTAL KÂRLARI");
            await HesapPlaniOlustur("522", "M.D.V. YENÝDEN DEÐERLEME ARTIÞLARI");
            await HesapPlaniOlustur("523", "ÝÞTÝRAKLER YENÝDEN DEÐERLEME ARTIÞLARI");
            await HesapPlaniOlustur("529", "DÝÐER SERMAYE YEDEKLERÝ");
            await HesapPlaniOlustur("540", "YASAL YEDEKLER");
            await HesapPlaniOlustur("541", "STATÜ YEDEKLERÝ");
            await HesapPlaniOlustur("542", "OLAÐANÜSTÜ YEDEKLER");
            await HesapPlaniOlustur("548", "DÝÐER KÂR YEDEKLERÝ");
            await HesapPlaniOlustur("549", "ÖZEL FONLAR");
            await HesapPlaniOlustur("570", "GEÇMÝÞ YILLAR KÂRLARI");
            await HesapPlaniOlustur("580", "GEÇMÝÞ YILLAR ZARARLARI");
            await HesapPlaniOlustur("590", "DÖNEM NET KÂRI");
            await HesapPlaniOlustur("591", "DÖNEM NET ZARARI (-)");
            await HesapPlaniOlustur("600", "YURTÝÇÝ SATIÞLAR");
            await HesapPlaniOlustur("601", "YURTDIÞI SATIÞLAR");
            await HesapPlaniOlustur("602", "DÝÐER GELÝRLER");
            await HesapPlaniOlustur("610", "SATIÞTAN ÝADELER (-)");
            await HesapPlaniOlustur("611", "SATIÞ ÝSKONTOLARI (-)");
            await HesapPlaniOlustur("612", "DÝÐER ÝNDÝRÝMLER (-)");
            await HesapPlaniOlustur("620", "SATILAN MAMÜLLER MALÝYETÝ (-)");
            await HesapPlaniOlustur("621", "SATILAN TÝCARÝ MALLAR MALÝYETÝ (-)");
            await HesapPlaniOlustur("622", "SATILAN HÝZMET MALÝYETÝ (-)");
            await HesapPlaniOlustur("623", "DÝÐER SATIÞLARIN MALÝYETÝ (-)");
            await HesapPlaniOlustur("630", "ARAÞTIRMA VE GELÝÞTÝRME GÝDERLERÝ (-)");
            await HesapPlaniOlustur("631", "PAZARLAMA SATIÞ VE DAÐITIM GÝDERLERÝ");
            await HesapPlaniOlustur("632", "GENEL YÖNETÝM GÝDERLERÝ (-)");
            await HesapPlaniOlustur("640", "ÝÞTÝRAKLERDEN TEMETTÜ GELÝRLERÝ");
            await HesapPlaniOlustur("641", "BAÐLI ORTAKLIKLARDAN TEMETTÜ GELÝRLERÝ");
            await HesapPlaniOlustur("642", "FAÝZ GELÝRLERÝ");
            await HesapPlaniOlustur("643", "KOMÝSYON GELÝRLERÝ");
            await HesapPlaniOlustur("644", "KONUSU KALMAYAN KARÞILIKLAR");
            await HesapPlaniOlustur("649", "FAALÝYETLE ÝLGÝLÝ DÝÐER GELÝR VE KÂRLAR");
            await HesapPlaniOlustur("652", "REESKONT FAÝZ GÝDERLERÝ (-)(1)");
            await HesapPlaniOlustur("653", "KOMÝSYON GÝDERLERÝ (-)");
            await HesapPlaniOlustur("654", "KARÞILIK GÝDERLERÝ (-)");
            await HesapPlaniOlustur("659", "DÝÐER GÝDER VE ZARARLAR (-)");
            await HesapPlaniOlustur("660", "KISA VADELÝ BORÇLANMA GÝDERLERÝ (-)");
            await HesapPlaniOlustur("661", "UZUN VADELÝ BORÇLANMA GÝDERLERÝ (-)");
            await HesapPlaniOlustur("671", "ÖNCEKÝ DÖNEM GELÝR VE KÂRLARI");
            await HesapPlaniOlustur("679", "DÝÐER OLAÐANDIÞI GELÝR VE KÂRLAR");
            await HesapPlaniOlustur("680", "ÇALIÞMAYAN KISIM GÝDER VE ZARARLARI (-)");
            await HesapPlaniOlustur("681", "ÖNCEKÝ DÖNEM GÝDER VE ZARARLARI (-)");
            await HesapPlaniOlustur("689", "DÝÐER OLAÐANDIÞI GÝDER VE ZARARLAR (-)");
            await HesapPlaniOlustur("690", "DÖNEM KÂRI VEYA ZARARI");
            await HesapPlaniOlustur("691", "DÖNEM KÂRI VERGÝ VE DÝÐER YASAL YÜKÜMLÜLÜK KARÞILIKLARI (-)");
            await HesapPlaniOlustur("692", "DÖNEM NET KÂRI VEYA ZARARI");
            await HesapPlaniOlustur("700", "MALÝYET MUHASEBESÝ BAÐLANTI HESABI");
            await HesapPlaniOlustur("701", "MALÝYET MUHASEBESÝ YANSITMA HESABI");
            await HesapPlaniOlustur("710", "DÝREKT ÝLKMADDE VE MALZEME GÝDERLERÝ");
            await HesapPlaniOlustur("711", "DÝREKT ÝLKMADDE VE MALZEME YANSITMA HESABI");
            await HesapPlaniOlustur("712", "DÝREKT ÝLKMADDE VE MALZEME FÝYAT FARKI");
            await HesapPlaniOlustur("713", "DÝREKT ÝLKMADDE VE MALZEME MÝKTAR FARKI");
            await HesapPlaniOlustur("720", "DÝREKT ÝÞÇÝLÝK GÝDERLERÝ");
            await HesapPlaniOlustur("721", "DÝREKT ÝÞCÝLÝK GÝDERLERÝ YANSITMA HESABI");
            await HesapPlaniOlustur("722", "DÝREKT ÝÞÇÝLÝK ÜCRET FARKLARI");
            await HesapPlaniOlustur("723", "DÝREKT ÝÞÇÝLÝK SÜRE (ZAMAN) FARKLARI");
            await HesapPlaniOlustur("730", "GENEL ÜRETÝM GÝDERLERÝ");
            await HesapPlaniOlustur("731", "GENEL ÜRETÝM GÝDERLERÝ YANSITMA HESABI");
            await HesapPlaniOlustur("732", "GENEL ÜRETÝM GÝDERLERÝ BÜTÇE FARKLARI");
            await HesapPlaniOlustur("733", "GENEL ÜRETÝM GÝDERLERÝ VERÝMLÝLÝK FARKLARI");
            await HesapPlaniOlustur("734", "GENEL ÜRETÝM GÝDERLERÝ KAPASÝTE FARKLARI");
            await HesapPlaniOlustur("740", "HÝZMET ÜRETÝM MALÝYETÝ");
            await HesapPlaniOlustur("741", "HÝZMET ÜRETÝM MALÝYETÝ YANSITMA HESABI");
            await HesapPlaniOlustur("742", "HÝZMET ÜRETÝM MALÝYETÝ FARK HESAPLARI");
            await HesapPlaniOlustur("750", "ARAÞTIRMA VE GELÝÞTÝRME GÝDERLERÝ");
            await HesapPlaniOlustur("751", "ARAÞTIRMA VE GELÝÞTÝRME GÝDERLERÝ YANSITMA HESABI");
            await HesapPlaniOlustur("752", "ARAÞTIRMA VE GELÝÞTÝRME GÝDER FARKLARI");
            await HesapPlaniOlustur("760", "PAZARLAMA SATIÞ VE DAÐITIM GÝDERLERÝ");
            await HesapPlaniOlustur("761", "PAZARLAMA SATIÞ VE DAÐITIM GÝDERLERÝ YANSITMA HESABI");
            await HesapPlaniOlustur("762", "PAZARLAMA SATIÞ VE DAÐITIM GÝDERLERÝ FARK HESABI");
            await HesapPlaniOlustur("770", "GENEL YÖNETÝM GÝDERLERÝ");
            await HesapPlaniOlustur("771", "GENEL YÖNETÝM GÝDERLERÝ YANSITMA HESABI");
            await HesapPlaniOlustur("772", "GENEL YÖNETÝM GÝDER FARKLARI HESABI");
            await HesapPlaniOlustur("780", "FÝNANSMAN GÝDERLERÝ");
            await HesapPlaniOlustur("781", "FÝNANSMAN GÝDERLERÝ YANSITMA HESABI");
            await HesapPlaniOlustur("782", "FÝNANSMAN GÝDERLERÝ FARK HESABI");
            await HesapPlaniOlustur("790", "ÝLKMADDE VE MALZEME GÝDERLERÝ");
            await HesapPlaniOlustur("791", "ÝÞÇÝ ÜCRET VE GÝDERLERÝ");
            await HesapPlaniOlustur("792", "MEMUR ÜCRET VE GÝDERLERÝ");
            await HesapPlaniOlustur("793", "DIÞARIDAN SAÐLANAN FAYDA VE HÝZMETLER");
            await HesapPlaniOlustur("794", "ÇEÞÝTLÝ GÝDERLER");
            await HesapPlaniOlustur("795", "VERGÝ, RESÝM VE HARÇLAR");
            await HesapPlaniOlustur("796", "AMORTÝSMANLAR VE TÜKENME PAYLARI");
            await HesapPlaniOlustur("797", "FÝNANSMAN GÝDERLERÝ");
            await HesapPlaniOlustur("798", "GÝDER ÇEÞÝTLERÝ YANSITMA HESABI");
            await HesapPlaniOlustur("799", "ÜRETÝM MALÝYET HESABI");
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
                return new ErrorResult("Hesap planý kodu daha önce açýlmýþ!");
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
                return new ErrorResult("Yazdýðýnýz hesap planý kodu kayýtlarda yok!");
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
                return new ErrorResult("Ana hesap kodlarý silinemez!");
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
                List<string> silinmeyecekHesapKodlarý = new()
                {
                    "102",
                    "120",
                    "127",
                    "128",
                    "131",
                    "320",
                    "335"
                };


                foreach (var item in silinmeyecekHesapKodlarý)
                {
                    if (hesapKodu.StartsWith(item))
                    {
                        return new ErrorResult("Module'da kaydý bulunan hesap planý kodu silinemez!");
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
                return new ErrorResult("Hareket kaydý olan hesap planý kodu silinemez!");
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
