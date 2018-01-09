using Autofac;
using Autofac.Integration.Mvc;
using AutofacMvc.Controllers;
using AutofacMvc.Data;
using AutofacMvc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutofacMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            //扫描程序集,注册所有的控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //注册指定的控制器"HomeController",每一个Http请求都会创建一个实例
            //builder.RegisterType<HomeController>().InstancePerHttpRequest();
            builder.RegisterType<SqlServerConnection>().As<ISqlConnection>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
