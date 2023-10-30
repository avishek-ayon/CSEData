using Autofac;
using CSEData.Application.Features.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Application
{
    public class ApplicationModule : Module
    {
        

        public ApplicationModule()
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
