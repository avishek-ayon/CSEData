using Autofac;
using CSEData.Application.Features.Training.Services;
using CSEData.Infrastructure.Features.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Application
{
    public class InfrastructureModule : Module
    {
        

        public InfrastructureModule()
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerLifetimeScope();
            builder.RegisterType<PriceService>().As<IPriceService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
