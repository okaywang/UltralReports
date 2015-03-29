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
		
		public const string SettingAccount = "系统设置-账号管理";		
		
		public const string SettingSms = "系统设置-短信设置";		
		
		public const string Report1 = "超限统计-统计1";		
		
		public const string Report2 = "超限统计-统计2";		
		
	}

	public sealed class Authorities
	{
		
		public AuthorityItem SettingAccount = new AuthorityItem( AuthorityNames.SettingAccount,(AuthorityType)1);		
		
		public AuthorityItem SettingSms = new AuthorityItem( AuthorityNames.SettingSms,(AuthorityType)1);		
		
		public AuthorityItem Report1 = new AuthorityItem( AuthorityNames.Report1,(AuthorityType)1);		
		
		public AuthorityItem Report2 = new AuthorityItem( AuthorityNames.Report2,(AuthorityType)1);		
		
	}

	public static class DefaultAuthoritiesForAdmin
    {
        private static List<string> defaultAuthorities = new List<string>();
        static DefaultAuthoritiesForAdmin()
        {
						defaultAuthorities.Add(AuthorityNames.SettingAccount);
								defaultAuthorities.Add(AuthorityNames.SettingSms);
								defaultAuthorities.Add(AuthorityNames.Report1);
								defaultAuthorities.Add(AuthorityNames.Report2);
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
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'系统设置-短信设置')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'超限统计-统计1')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'超限统计-统计2')");
					            

            System.IO.File.WriteAllText(filename, sb.ToString());   
        }
    }
}