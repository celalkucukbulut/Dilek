using Autofac;
using Services.AdminsServices;
using Services.ContentsServices;
using Services.DBCodesServices;
using Services.ForgotPasswordServices;
using Services.ImagesServices;
using Services.MessagesServices;

namespace Fifm.Services.DependencyResolvers.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ImagesServices>().As<IImagesServices>().SingleInstance();
            builder.RegisterType<ContentsServices>().As<IContentsServices>().SingleInstance();
            builder.RegisterType<DBCodesServices>().As<IDBCodesServices>().SingleInstance();
            builder.RegisterType<MessagesServices>().As<IMessagesServices>().SingleInstance();
            builder.RegisterType<AdminsServices>().As<IAdminsServices>().SingleInstance();
            builder.RegisterType<ForgotPasswordServices>().As<IForgotPasswordServices>().SingleInstance();
        }
    }
}
