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
    public class SkuControllerTest
    {
        private SkuController _controller;
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

            _controller = resolver.GetService(typeof(SkuController)) as SkuController;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var result = _controller.GetSkuList(5, null, null);

        }
    }
     



}
