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
using BussinessLogic;
using WebExpress.Core;
using Website.Controllers;

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
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredAttributeAdapter));

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
            Mapper.CreateMap<SmsGroup, NameValuePair>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            Mapper.CreateMap<Account, AccountListItemModel>();
            Mapper.CreateMap<AccountAddModel, Account>();
            Mapper.CreateMap<Account, NameValuePair>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            Mapper.CreateMap<MonitorType, MonitorTypeListItemModel>();
            Mapper.CreateMap<MonitorType, NameValuePair>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            Mapper.CreateMap<Major, MajorListItemModel>();
            Mapper.CreateMap<Major, NameValuePair>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            Mapper.CreateMap<Part, PartListItemModel>().ForMember(dest => dest.MachineSet, opt => opt.MapFrom(src => src.Equipment.MachineSet))
                .ForMember(dest => dest.CreateUser, opt => opt.MapFrom(src => string.Concat(src.FAAccount.Name, " ", src.FAAccount.Major == null ? string.Empty : src.FAAccount.Major.Name)))
                .ForMember(dest => dest.UpdateUser, opt => opt.MapFrom(src => string.Concat(src.LCAccount == null ? string.Empty : src.LCAccount.Name, " ", src.LCAccount == null ? string.Empty : src.LCAccount.Major == null ? string.Empty : src.LCAccount.Major.Name)));
            Mapper.CreateMap<PartAddModel, Part>();
            Mapper.CreateMap<Part, NameValuePair>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            Mapper.CreateMap<Part, ProPartListItemModel>().ForMember(dest => dest.MachineSet, opt => opt.MapFrom(src => src.Equipment.MachineSet));
            Mapper.CreateMap<ProPartAddModel, Part>();

            Mapper.CreateMap<Equipment, EquipmentListItemModel>().ForMember(i => i.MonitorTypeName, opt => opt.MapFrom(src => src.MonitorType.Name));
            Mapper.CreateMap<EquipmentAddModel, Equipment>();
            Mapper.CreateMap<Equipment, NameValuePair>().ForMember(i => i.Value, opt => opt.MapFrom(src => src.Id));

            Mapper.CreateMap<UltraSummary, UltraSummaryListItemModel>().ForMember(dest => dest.RatedRange, opt => opt.MapFrom(src => string.Format("{0}-{1}", src.L1, src.H1)));
            Mapper.CreateMap<UltraRecord, UltraRecordListItemModel>();
            Mapper.CreateMap<UltraRecord, ProUltraRecordListItemModel>().ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.Part.Equipment.Name))
                .ForMember(dest => dest.MajorName, opt => opt.MapFrom(src => src.Part.Major.Name));

            Mapper.CreateMap<PartSmsEditModel, PartSms>();
            Mapper.CreateMap<PartSms, PartSmsEditModel>();

            Mapper.CreateMap<DutyTime, DutyTimeModel>();
            Mapper.CreateMap<Duty, DutyModel>();

            Mapper.CreateMap<SmsLog, SmsLogListItemModel>().ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.SmsGroup.Name));
            Mapper.CreateMap<RtMonthTime, GapListItemModel>();
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