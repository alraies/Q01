using Autofac;
using Data.DataRepository;
using Test5.Data;
using Test5.Services;

namespace Test5
{
    public class ServiceModules : Autofac.Module
    {
        //Auto Register Services
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<Test5DbContext>();
            builder.RegisterGeneric(typeof(DevRepository<>))
                    .As(typeof(IDevRepository<>));
            var assembly = typeof(CustomerService).Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
