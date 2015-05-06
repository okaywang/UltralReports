using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Types;
namespace Website
{
	public sealed class AuthorityItem
    {
        public AuthorityItem(string name, AuthorityType authorityType)
        {
            this.Name = name;
            this.AuthorityType = authorityType;
        }

        public string Name { get; private set; }
        public AuthorityType AuthorityType { get; private set; }
    }

	public sealed class AuthorityNames
	{
		
		public const string AccountSetting = "系统设置-账号管理";		
		
		public const string DutySetting = "系统设置-班次设置";		
		
		public const string SmsGroupSetting = "系统设置-短信接受组管理";		
		
		public const string NormalUltraReport = "超限统计-常规超限统计";		
		
		public const string ProUltraReport = "超限统计-专业超限统计";		
		
		public const string EquipmentSetting = "常规超限配置-设备管理";		
		
		public const string NormalPartSetting = "常规超限配置-部件管理";		
		
		public const string MonitorSetting = "常规超限配置-监控类别管理";		
		
		public const string ProPartSetting = "专业超限配置-部件管理";		
		
		public const string MajorSetting = "专业超限配置-专业";		
		
	}

	public sealed class Authorities
	{
		
		public AuthorityItem AccountSetting = new AuthorityItem( AuthorityNames.AccountSetting,(AuthorityType)1);		
		
		public AuthorityItem DutySetting = new AuthorityItem( AuthorityNames.DutySetting,(AuthorityType)2);		
		
		public AuthorityItem SmsGroupSetting = new AuthorityItem( AuthorityNames.SmsGroupSetting,(AuthorityType)2);		
		
		public AuthorityItem NormalUltraReport = new AuthorityItem( AuthorityNames.NormalUltraReport,(AuthorityType)2);		
		
		public AuthorityItem ProUltraReport = new AuthorityItem( AuthorityNames.ProUltraReport,(AuthorityType)2);		
		
		public AuthorityItem EquipmentSetting = new AuthorityItem( AuthorityNames.EquipmentSetting,(AuthorityType)2);		
		
		public AuthorityItem NormalPartSetting = new AuthorityItem( AuthorityNames.NormalPartSetting,(AuthorityType)2);		
		
		public AuthorityItem MonitorSetting = new AuthorityItem( AuthorityNames.MonitorSetting,(AuthorityType)2);		
		
		public AuthorityItem ProPartSetting = new AuthorityItem( AuthorityNames.ProPartSetting,(AuthorityType)2);		
		
		public AuthorityItem MajorSetting = new AuthorityItem( AuthorityNames.MajorSetting,(AuthorityType)2);		
		
	}

	public static class DefaultAuthoritiesForAdmin
    {
        private static List<string> defaultAuthorities = new List<string>();
        static DefaultAuthoritiesForAdmin()
        {
		        }
        public static List<string> DefaultAuthorities
        {
            get
            {
                return defaultAuthorities;
            }
        }
    }

	public static class DefaultAuthoritiesForShop
    {
        private static List<string> defaultAuthorities = new List<string>();
        static DefaultAuthoritiesForShop()
        {
		        }
        public static List<string> DefaultAuthorities
        {
            get
            {
                return defaultAuthorities;
            }
        }
    }
	public class CreateAuthoritiesSqlFile
    {
        public static void Create()
        {
            string filename = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/SqlServer.Authorities.sql");
            var sb = new System.Text.StringBuilder();
								sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'系统设置-账号管理')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'系统设置-班次设置')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'系统设置-短信接受组管理')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'超限统计-常规超限统计')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'超限统计-专业超限统计')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'常规超限配置-设备管理')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'常规超限配置-部件管理')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'常规超限配置-监控类别管理')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'专业超限配置-部件管理')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'专业超限配置-专业')");
					            

            System.IO.File.WriteAllText(filename, sb.ToString());   
        }
    }
}