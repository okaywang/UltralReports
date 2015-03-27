using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web; 
using DataAccess;
using BussinessLogic;

namespace Website
{
    public class DependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UltralReportsEntities>().As<DbContext>().InstancePerHttpRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).InstancePerHttpRequest();

            builder.RegisterType<AccountBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<SmsBussinessLogic>().InstancePerHttpRequest();
        }
    }
}