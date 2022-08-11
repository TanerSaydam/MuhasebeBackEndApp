using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using Business.Repositories.HesapPlaniRepository;
using DataAccess.Repositories.HesapPlaniRepository;
using Business.Repositories.YevmiyeFisiRepository;
using DataAccess.Repositories.YevmiyeFisiRepository;
using Business.Repositories.CariRepository;
using DataAccess.Repositories.CariRepository;
using Business.Repositories.BankaHesabiRepository;
using DataAccess.Repositories.BankaHesabiRepository;
using Business.Repositories.BorcCekiRepository;
using DataAccess.Repositories.BorcCekiRepository;
using Business.Repositories.MusteriCekiRepository;
using DataAccess.Repositories.MusteriCekiRepository;
using Business.Repositories.BorcSenetiRepository;
using DataAccess.Repositories.BorcSenetiRepository;
using Business.Repositories.MusteriSenetiRepository;
using DataAccess.Repositories.MusteriSenetiRepository;
using Business.Repositories.CekSenetMuhasebeKoduRepository;
using DataAccess.Repositories.CekSenetMuhasebeKoduRepository;
using Business.Repositories.StokRepository;
using DataAccess.Repositories.StokRepository;
using Business.Repositories.StokHareketiRepository;
using DataAccess.Repositories.StokHareketiRepository;
using Business.Repositories.FaturaRepository;
using DataAccess.Repositories.FaturaRepository;
using Business.Repositories.FaturaDetayiRepository;
using DataAccess.Repositories.FaturaDetayiRepository;
using Business.Repositories.BorcCekiHareketRepository;
using DataAccess.Repositories.BorcCekiHareketRepository;
using DataAccess.Repositories.UserRepository;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();
           
            builder.RegisterType<HesapPlaniManager>().As<IHesapPlaniService>().SingleInstance();
            builder.RegisterType<EfHesapPlaniDal>().As<IHesapPlaniDal>().SingleInstance();

            builder.RegisterType<YevmiyeFisiManager>().As<IYevmiyeFisiService>().SingleInstance();
            builder.RegisterType<EfYevmiyeFisiDal>().As<IYevmiyeFisiDal>().SingleInstance();

            builder.RegisterType<CariManager>().As<ICariService>().SingleInstance();
            builder.RegisterType<EfCariDal>().As<ICariDal>().SingleInstance();

            builder.RegisterType<BankaHesabiManager>().As<IBankaHesabiService>().SingleInstance();
            builder.RegisterType<EfBankaHesabiDal>().As<IBankaHesabiDal>().SingleInstance();

            builder.RegisterType<BorcCekiManager>().As<IBorcCekiService>().SingleInstance();
            builder.RegisterType<EfBorcCekiDal>().As<IBorcCekiDal>().SingleInstance();

            builder.RegisterType<MusteriCekiManager>().As<IMusteriCekiService>().SingleInstance();
            builder.RegisterType<EfMusteriCekiDal>().As<IMusteriCekiDal>().SingleInstance();

            builder.RegisterType<BorcSenetiManager>().As<IBorcSenetiService>().SingleInstance();
            builder.RegisterType<EfBorcSenetiDal>().As<IBorcSenetiDal>().SingleInstance();

            builder.RegisterType<MusteriSenetiManager>().As<IMusteriSenetiService>().SingleInstance();
            builder.RegisterType<EfMusteriSenetiDal>().As<IMusteriSenetiDal>().SingleInstance();

            builder.RegisterType<CekSenetMuhasebeKoduManager>().As<ICekSenetMuhasebeKoduService>().SingleInstance();
            builder.RegisterType<EfCekSenetMuhasebeKoduDal>().As<ICekSenetMuhasebeKoduDal>().SingleInstance();

            builder.RegisterType<StokManager>().As<IStokService>().SingleInstance();
            builder.RegisterType<EfStokDal>().As<IStokDal>().SingleInstance();

            builder.RegisterType<StokHareketiManager>().As<IStokHareketiService>().SingleInstance();
            builder.RegisterType<EfStokHareketiDal>().As<IStokHareketiDal>().SingleInstance();

            builder.RegisterType<FaturaManager>().As<IFaturaService>().SingleInstance();
            builder.RegisterType<EfFaturaDal>().As<IFaturaDal>().SingleInstance();

            builder.RegisterType<FaturaDetayiManager>().As<IFaturaDetayiService>().SingleInstance();
            builder.RegisterType<EfFaturaDetayiDal>().As<IFaturaDetayiDal>().SingleInstance();

            builder.RegisterType<BorcCekiHareketManager>().As<IBorcCekiHareketService>().SingleInstance();
            builder.RegisterType<EfBorcCekiHareketDal>().As<IBorcCekiHareketDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
