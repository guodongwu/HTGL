using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.IO;
using HTGL.Repository.EF;

namespace HTGL.UI.Portal
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {

            ContainerBuilder builder = new ContainerBuilder();
            var baseType = typeof(IDependency);
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()); 
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerHttpRequest().PropertiesAutowired();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }


}