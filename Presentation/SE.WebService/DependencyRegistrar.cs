using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac.Integration.WebApi;
using SE.DataAccess;
using System.Data.Entity;
using SE.BussinessLogic;

namespace SE.WebService
{
    public class DependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ShopTest10Entities>().As<DbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).InstancePerRequest();
            builder.RegisterType<ShopBussinessLogic>().InstancePerRequest();
            builder.RegisterType<CommunityBussinessLogic>().InstancePerRequest();
            builder.RegisterType<CustomerBussinessLogic>().InstancePerRequest();
            builder.RegisterType<GoodsBussinessLogic>().InstancePerRequest();
            builder.RegisterType<OrderBussinessLogic>().InstancePerRequest();
            builder.RegisterType<RecipientBussinessLogic>().InstancePerRequest();
            builder.RegisterType<ChinaAreaBussinessLogic>().InstancePerRequest();
            builder.RegisterType<ActivityBussinessLogic>().InstancePerRequest();
            builder.RegisterType<AppVersionBussinessLogic>().InstancePerRequest();
            builder.RegisterType<CommunityBussinessLogic>().InstancePerRequest();
            builder.RegisterType<ChinaAreaBussinessLogic>().InstancePerRequest();
            builder.RegisterType<OrderNumberSeedBussinessLogic>().InstancePerRequest();
        }
    }
}