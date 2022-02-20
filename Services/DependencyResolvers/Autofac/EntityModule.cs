using Autofac;
using Core.Helper;
using Core.Repositories.Dapper;
using Infrastructure;

namespace Fifm.Services.DependencyResolvers.Autofac
{
    public class EntityModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDapperHelper>().As<DapperHelper>().As<IUnitofwork>().SingleInstance();
         }
    }
}
