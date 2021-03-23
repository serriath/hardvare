using Autofac;
using Hardvare.Services.Interfaces;
using Hardvare.Services.Services;

namespace Hardvare.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerLifetimeScope();
        }
    }
}
