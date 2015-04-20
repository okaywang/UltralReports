using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Text;
using System.Web.Hosting;
using System.IO;
using Website.App_Start;
using Website.Common;
using Website.Models;
using DataAccess;
using AutoMapper;

namespace Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var dependencyRegistar = new DependencyRegistrar();
            dependencyRegistar.Register(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Add(new SEViewEngine());
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredAttributeAdapter));

            //启用压缩
            //BundleTable.EnableOptimizations = true;//发布时设置为true
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string jsChina = HostingEnvironment.MapPath("~/Scripts/chinaArea.js");
            if (!File.Exists(jsChina))
            {
                WriteChinaAreaScripts(jsChina);
            }

            AuthorityHelper.Init();
            InitAutoMapper();
            // CreateAuthoritiesSqlFile.Create();
        }

        private void InitAutoMapper()
        {
            Mapper.CreateMap<AccountAddModel, Account>();
            Mapper.CreateMap<MonitorType, MonitorTypeListItemModel>();
            Mapper.CreateMap<MonitorType, NameValuePair>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<Equipment, EquipmentListItemModel>().ForMember(i => i.MonitorTypeName, opt => opt.MapFrom(src => src.MonitorType.Name));
            Mapper.CreateMap<EquipmentAddModel, Equipment>();
        }


        private void WriteChinaAreaScripts(string fullFileName)
        {
            var sb = new StringBuilder();
            var ds = new ChinaAreaScriptWriter();
            ds.WriteScripts(sb);
            File.WriteAllText(fullFileName, sb.ToString());
        }
    }
}