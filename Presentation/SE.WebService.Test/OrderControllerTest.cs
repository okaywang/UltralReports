using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE.WebService.Controllers;
using Autofac;
using SE.BussinessLogic;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Reflection;
using SE.DataAccess;
using System.Data.Entity;
using SE.WebService.Models;
using System.Collections.Generic;

namespace SE.WebService.Test
{
    [TestClass]
    public class OrderControllerTest
    {
        private OrderController _controller;
        [TestInitialize]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            var dependencyRegistar = new DependencyRegistrar111();
            dependencyRegistar.Register(builder);
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;

            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            httpConfiguration.DependencyResolver = resolver;

            _controller = resolver.GetService(typeof(OrderController)) as OrderController;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var model = new NewOrderModel();
            model.Gender = Common.Types.GenderType.Female;
            model.UserId = 5;
            model.UserName = "wgj";
            model.TrueTime = "3.2";
            model.ShopId = 5;
            model.Remarks = "aaaaa";
            model.CommunityId = 1;
            model.CountyId = 1;
            model.Address = "chaoyang..dd";
            model.FromDeviceType = Common.Types.DeviceType.IPhone;
            model.SkuItems = new List<SkuOrder> 
            {  
                new SkuOrder
                {
                    Id = 1375,
                    Num= 1
                }
            };


            

            var d = _controller.Add(model);
            var x = 3 == 3 - 2;
            Assert.IsTrue(x);
        }
    }


    public class DependencyRegistrar111
    {
        public void Register(ContainerBuilder builder)
        {
            // builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<OrderController>().InstancePerDependency();
            builder.RegisterType<ShopTest10Entities>().As<DbContext>().InstancePerDependency();
            builder.RegisterGeneric(typeof(EfRepository<>)).InstancePerDependency();
            builder.RegisterType<ShopBussinessLogic>().InstancePerDependency();
            builder.RegisterType<CommunityBussinessLogic>().InstancePerDependency();
            builder.RegisterType<CustomerBussinessLogic>().InstancePerDependency();
            builder.RegisterType<GoodsBussinessLogic>().InstancePerDependency();
            builder.RegisterType<OrderBussinessLogic>().InstancePerDependency();
            builder.RegisterType<RecipientBussinessLogic>().InstancePerDependency();
            builder.RegisterType<ChinaAreaBussinessLogic>().InstancePerDependency();
            builder.RegisterType<ActivityBussinessLogic>().InstancePerDependency();
            builder.RegisterType<AppVersionBussinessLogic>().InstancePerDependency();
            builder.RegisterType<CommunityBussinessLogic>().InstancePerDependency();
            builder.RegisterType<ChinaAreaBussinessLogic>().InstancePerDependency();
            builder.RegisterType<OrderNumberSeedBussinessLogic>().InstancePerDependency();
        }
    }



}
