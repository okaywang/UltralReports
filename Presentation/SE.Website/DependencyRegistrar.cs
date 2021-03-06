﻿using Autofac;
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
            builder.RegisterGeneric(typeof(BussinessLogicBase<>)).InstancePerHttpRequest();

            builder.RegisterType<AccountBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<SmsBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<SmsLogBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<EquipmentBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<UltraReportBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<MajorBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<DutyBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<LogExceptionBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<KPIBussinessLogic>().InstancePerHttpRequest();
        }
    }
}