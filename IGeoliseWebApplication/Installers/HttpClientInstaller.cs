using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace IGeoliseWebApplication.Installers
{
    public class HttpClientInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof (HttpClient)).UsingFactoryMethod(() => new HttpClient()));
        }
    }
}