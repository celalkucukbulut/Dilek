using Autofac;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;

namespace Fifm.Services.DependencyResolvers.Autofac
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ImagesRepository>().As<IImagesRepository>();
            builder.RegisterType<DBCodesRepository>().As<IDBCodesRepository>();
            builder.RegisterType<ContentsRepository>().As<IContentsRepository>();
            builder.RegisterType<MessagesRepository>().As<IMessagesRepository>();
            builder.RegisterType<AdminsRepository>().As<IAdminsRepository>();
            builder.RegisterType<ForgotPasswordRepository>().As<IForgotPasswordRepository>();
        }
    }
}
