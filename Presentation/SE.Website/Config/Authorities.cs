using Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
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
		
		public const string IndexShopStatistics = "后台首页-签约商户";		
		
		public const string IndexChart = "后台首页-今日营业额";		
		
		public const string SkuCategoryView = "商品类型管理-查看";		
		
		public const string SkuCategoryAdd = "商品类型管理-添加";		
		
		public const string SkuCategoryUpdate = "商品类型管理-修改";		
		
		public const string SkuCategoryDelete = "商品类型管理-删除";		
		
		public const string BrandView = "品牌管理-查看";		
		
		public const string BrandAdd = "品牌管理-添加";		
		
		public const string BrandUpdate = "品牌管理-修改";		
		
		public const string BrandDelete = "品牌管理-删除";		
		
		public const string BrandBindTypes = "品牌管理-关联商品类型";		
		
		public const string GoodsView = "商品管理-查看";		
		
		public const string GoodsAdd = "商品管理-添加";		
		
		public const string GoodsUpdate = "商品管理-编辑";		
		
		public const string GoodsDelete = "商品管理-删除";		
		
		public const string GoodsPublish = "商品管理-发布";		
		
		public const string CommonGoodsView = "公共商品管理-查看";		
		
		public const string CommonGoodsAdd = "公共商品管理-添加";		
		
		public const string CommonGoodsUpdate = "公共商品管理-编辑";		
		
		public const string CommonGoodsDelete = "公共商品管理-删除";		
		
		public const string OrderView = "订单管理-查看";		
		
		public const string OrderStatView = "订单管理-统计";		
		
		public const string Cashback = "订单管理-返现";		
		
		public const string ShopView = "商户管理-查看";		
		
		public const string ShopDayang = "商户管理-打烊";		
		
		public const string ShopClose = "商户管理-关店";		
		
		public const string ShopAccountAuthSet = "帐号维护-权限设置";		
		
		public const string ShopAccountResetPassword = "帐号维护-重置密码";		
		
		public const string ShopAccountView = "帐号维护-查看";		
		
		public const string ShopAccountAdd = "帐号维护-添加";		
		
		public const string ShopAccountIntegrate = "帐号维护-完善资料";		
		
		public const string ShopAccountModifyPassword = "帐号维护-修改密码";		
		
		public const string CustomerView = "会员管理-查看";		
		
		public const string CustomerReturn = "会员管理-返现";		
		
		public const string CommunityView = "楼宇库-查看";		
		
		public const string CommunityAdd = "楼宇库-添加";		
		
		public const string CommunityUpdate = "楼宇库-编辑";		
		
		public const string CommunityDelete = "楼宇库-删除";		
		
		public const string AccountView = "内部帐号管理-查看";		
		
		public const string AccountAdd = "内部帐号管理-添加";		
		
		public const string AccountUpdate = "内部帐号管理-编辑";		
		
		public const string AccountDelete = "内部帐号管理-删除";		
		
		public const string AccountAuthSet = "内部帐号管理-权限设置";		
		
		public const string AccountModifyPassword = "内部帐号管理-修改密码";		
		
		public const string SuggestionView = "投诉管理-查看";		
		
		public const string ActivityView = "活动设置-查看";		
		
		public const string ActivityAdd = "活动设置-添加";		
		
		public const string ActivityUpdate = "活动设置-修改";		
		
		public const string ShopBilinView = "商户数据维护-查看";		
		
		public const string ShopBilinAgree = "商户数据维护-合作";		
		
		public const string ShopBilinReject = "商户数据维护-暂不合作";		
		
		public const string ShopBilinCreateAccount = "商户数据维护-开通帐号";		
		
		public const string RecommendShopView = "推荐商户管理-查看";		
		
	}

	public sealed class Authorities
	{
		
		public AuthorityItem IndexShopStatistics = new AuthorityItem( AuthorityNames.IndexShopStatistics,(AuthorityType)1);		
		
		public AuthorityItem IndexChart = new AuthorityItem( AuthorityNames.IndexChart,(AuthorityType)3);		
		
		public AuthorityItem SkuCategoryView = new AuthorityItem( AuthorityNames.SkuCategoryView,(AuthorityType)1);		
		
		public AuthorityItem SkuCategoryAdd = new AuthorityItem( AuthorityNames.SkuCategoryAdd,(AuthorityType)1);		
		
		public AuthorityItem SkuCategoryUpdate = new AuthorityItem( AuthorityNames.SkuCategoryUpdate,(AuthorityType)1);		
		
		public AuthorityItem SkuCategoryDelete = new AuthorityItem( AuthorityNames.SkuCategoryDelete,(AuthorityType)1);		
		
		public AuthorityItem BrandView = new AuthorityItem( AuthorityNames.BrandView,(AuthorityType)1);		
		
		public AuthorityItem BrandAdd = new AuthorityItem( AuthorityNames.BrandAdd,(AuthorityType)1);		
		
		public AuthorityItem BrandUpdate = new AuthorityItem( AuthorityNames.BrandUpdate,(AuthorityType)1);		
		
		public AuthorityItem BrandDelete = new AuthorityItem( AuthorityNames.BrandDelete,(AuthorityType)1);		
		
		public AuthorityItem BrandBindTypes = new AuthorityItem( AuthorityNames.BrandBindTypes,(AuthorityType)1);		
		
		public AuthorityItem GoodsView = new AuthorityItem( AuthorityNames.GoodsView,(AuthorityType)3);		
		
		public AuthorityItem GoodsAdd = new AuthorityItem( AuthorityNames.GoodsAdd,(AuthorityType)2);		
		
		public AuthorityItem GoodsUpdate = new AuthorityItem( AuthorityNames.GoodsUpdate,(AuthorityType)2);		
		
		public AuthorityItem GoodsDelete = new AuthorityItem( AuthorityNames.GoodsDelete,(AuthorityType)2);		
		
		public AuthorityItem GoodsPublish = new AuthorityItem( AuthorityNames.GoodsPublish,(AuthorityType)2);		
		
		public AuthorityItem CommonGoodsView = new AuthorityItem( AuthorityNames.CommonGoodsView,(AuthorityType)1);		
		
		public AuthorityItem CommonGoodsAdd = new AuthorityItem( AuthorityNames.CommonGoodsAdd,(AuthorityType)1);		
		
		public AuthorityItem CommonGoodsUpdate = new AuthorityItem( AuthorityNames.CommonGoodsUpdate,(AuthorityType)1);		
		
		public AuthorityItem CommonGoodsDelete = new AuthorityItem( AuthorityNames.CommonGoodsDelete,(AuthorityType)1);		
		
		public AuthorityItem OrderView = new AuthorityItem( AuthorityNames.OrderView,(AuthorityType)1);		
		
		public AuthorityItem OrderStatView = new AuthorityItem( AuthorityNames.OrderStatView,(AuthorityType)1);		
		
		public AuthorityItem Cashback = new AuthorityItem( AuthorityNames.Cashback,(AuthorityType)1);		
		
		public AuthorityItem ShopView = new AuthorityItem( AuthorityNames.ShopView,(AuthorityType)1);		
		
		public AuthorityItem ShopDayang = new AuthorityItem( AuthorityNames.ShopDayang,(AuthorityType)1);		
		
		public AuthorityItem ShopClose = new AuthorityItem( AuthorityNames.ShopClose,(AuthorityType)1);		
		
		public AuthorityItem ShopAccountAuthSet = new AuthorityItem( AuthorityNames.ShopAccountAuthSet,(AuthorityType)1);		
		
		public AuthorityItem ShopAccountResetPassword = new AuthorityItem( AuthorityNames.ShopAccountResetPassword,(AuthorityType)1);		
		
		public AuthorityItem ShopAccountView = new AuthorityItem( AuthorityNames.ShopAccountView,(AuthorityType)3);		
		
		public AuthorityItem ShopAccountAdd = new AuthorityItem( AuthorityNames.ShopAccountAdd,(AuthorityType)1);		
		
		public AuthorityItem ShopAccountIntegrate = new AuthorityItem( AuthorityNames.ShopAccountIntegrate,(AuthorityType)1);		
		
		public AuthorityItem ShopAccountModifyPassword = new AuthorityItem( AuthorityNames.ShopAccountModifyPassword,(AuthorityType)2);		
		
		public AuthorityItem CustomerView = new AuthorityItem( AuthorityNames.CustomerView,(AuthorityType)1);		
		
		public AuthorityItem CustomerReturn = new AuthorityItem( AuthorityNames.CustomerReturn,(AuthorityType)1);		
		
		public AuthorityItem CommunityView = new AuthorityItem( AuthorityNames.CommunityView,(AuthorityType)1);		
		
		public AuthorityItem CommunityAdd = new AuthorityItem( AuthorityNames.CommunityAdd,(AuthorityType)1);		
		
		public AuthorityItem CommunityUpdate = new AuthorityItem( AuthorityNames.CommunityUpdate,(AuthorityType)1);		
		
		public AuthorityItem CommunityDelete = new AuthorityItem( AuthorityNames.CommunityDelete,(AuthorityType)1);		
		
		public AuthorityItem AccountView = new AuthorityItem( AuthorityNames.AccountView,(AuthorityType)1);		
		
		public AuthorityItem AccountAdd = new AuthorityItem( AuthorityNames.AccountAdd,(AuthorityType)1);		
		
		public AuthorityItem AccountUpdate = new AuthorityItem( AuthorityNames.AccountUpdate,(AuthorityType)1);		
		
		public AuthorityItem AccountDelete = new AuthorityItem( AuthorityNames.AccountDelete,(AuthorityType)1);		
		
		public AuthorityItem AccountAuthSet = new AuthorityItem( AuthorityNames.AccountAuthSet,(AuthorityType)1);		
		
		public AuthorityItem AccountModifyPassword = new AuthorityItem( AuthorityNames.AccountModifyPassword,(AuthorityType)1);		
		
		public AuthorityItem SuggestionView = new AuthorityItem( AuthorityNames.SuggestionView,(AuthorityType)1);		
		
		public AuthorityItem ActivityView = new AuthorityItem( AuthorityNames.ActivityView,(AuthorityType)1);		
		
		public AuthorityItem ActivityAdd = new AuthorityItem( AuthorityNames.ActivityAdd,(AuthorityType)1);		
		
		public AuthorityItem ActivityUpdate = new AuthorityItem( AuthorityNames.ActivityUpdate,(AuthorityType)1);		
		
		public AuthorityItem ShopBilinView = new AuthorityItem( AuthorityNames.ShopBilinView,(AuthorityType)1);		
		
		public AuthorityItem ShopBilinAgree = new AuthorityItem( AuthorityNames.ShopBilinAgree,(AuthorityType)1);		
		
		public AuthorityItem ShopBilinReject = new AuthorityItem( AuthorityNames.ShopBilinReject,(AuthorityType)1);		
		
		public AuthorityItem ShopBilinCreateAccount = new AuthorityItem( AuthorityNames.ShopBilinCreateAccount,(AuthorityType)1);		
		
		public AuthorityItem RecommendShopView = new AuthorityItem( AuthorityNames.RecommendShopView,(AuthorityType)1);		
		
	}

	public static class DefaultAuthoritiesForAdmin
    {
        private static List<string> defaultAuthorities = new List<string>();
        static DefaultAuthoritiesForAdmin()
        {
						defaultAuthorities.Add(AuthorityNames.IndexShopStatistics);
								defaultAuthorities.Add(AuthorityNames.IndexChart);
								defaultAuthorities.Add(AuthorityNames.SkuCategoryView);
								defaultAuthorities.Add(AuthorityNames.SkuCategoryAdd);
								defaultAuthorities.Add(AuthorityNames.SkuCategoryUpdate);
								defaultAuthorities.Add(AuthorityNames.SkuCategoryDelete);
								defaultAuthorities.Add(AuthorityNames.BrandView);
								defaultAuthorities.Add(AuthorityNames.BrandAdd);
								defaultAuthorities.Add(AuthorityNames.BrandUpdate);
								defaultAuthorities.Add(AuthorityNames.BrandDelete);
								defaultAuthorities.Add(AuthorityNames.BrandBindTypes);
								defaultAuthorities.Add(AuthorityNames.GoodsView);
								defaultAuthorities.Add(AuthorityNames.CommonGoodsView);
								defaultAuthorities.Add(AuthorityNames.CommonGoodsAdd);
								defaultAuthorities.Add(AuthorityNames.CommonGoodsUpdate);
								defaultAuthorities.Add(AuthorityNames.CommonGoodsDelete);
								defaultAuthorities.Add(AuthorityNames.OrderView);
								defaultAuthorities.Add(AuthorityNames.OrderStatView);
								defaultAuthorities.Add(AuthorityNames.Cashback);
								defaultAuthorities.Add(AuthorityNames.ShopView);
								defaultAuthorities.Add(AuthorityNames.ShopDayang);
								defaultAuthorities.Add(AuthorityNames.ShopClose);
								defaultAuthorities.Add(AuthorityNames.ShopAccountAuthSet);
								defaultAuthorities.Add(AuthorityNames.ShopAccountResetPassword);
								defaultAuthorities.Add(AuthorityNames.ShopAccountView);
								defaultAuthorities.Add(AuthorityNames.ShopAccountAdd);
								defaultAuthorities.Add(AuthorityNames.ShopAccountIntegrate);
								defaultAuthorities.Add(AuthorityNames.CustomerView);
								defaultAuthorities.Add(AuthorityNames.CustomerReturn);
								defaultAuthorities.Add(AuthorityNames.CommunityView);
								defaultAuthorities.Add(AuthorityNames.CommunityAdd);
								defaultAuthorities.Add(AuthorityNames.CommunityUpdate);
								defaultAuthorities.Add(AuthorityNames.CommunityDelete);
								defaultAuthorities.Add(AuthorityNames.SuggestionView);
								defaultAuthorities.Add(AuthorityNames.ActivityView);
								defaultAuthorities.Add(AuthorityNames.ActivityAdd);
								defaultAuthorities.Add(AuthorityNames.ActivityUpdate);
								defaultAuthorities.Add(AuthorityNames.ShopBilinView);
								defaultAuthorities.Add(AuthorityNames.ShopBilinAgree);
								defaultAuthorities.Add(AuthorityNames.ShopBilinReject);
								defaultAuthorities.Add(AuthorityNames.ShopBilinCreateAccount);
								defaultAuthorities.Add(AuthorityNames.RecommendShopView);
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
						defaultAuthorities.Add(AuthorityNames.IndexChart);
								defaultAuthorities.Add(AuthorityNames.GoodsView);
								defaultAuthorities.Add(AuthorityNames.GoodsAdd);
								defaultAuthorities.Add(AuthorityNames.GoodsUpdate);
								defaultAuthorities.Add(AuthorityNames.GoodsDelete);
								defaultAuthorities.Add(AuthorityNames.GoodsPublish);
								defaultAuthorities.Add(AuthorityNames.ShopAccountView);
								defaultAuthorities.Add(AuthorityNames.ShopAccountModifyPassword);
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
								sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'后台首页-签约商户')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 3, N'后台首页-今日营业额')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商品类型管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商品类型管理-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商品类型管理-修改')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商品类型管理-删除')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'品牌管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'品牌管理-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'品牌管理-修改')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'品牌管理-删除')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'品牌管理-关联商品类型')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 3, N'商品管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'商品管理-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'商品管理-编辑')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'商品管理-删除')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'商品管理-发布')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'公共商品管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'公共商品管理-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'公共商品管理-编辑')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'公共商品管理-删除')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'订单管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'订单管理-统计')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'订单管理-返现')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商户管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商户管理-打烊')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商户管理-关店')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'帐号维护-权限设置')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'帐号维护-重置密码')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 3, N'帐号维护-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'帐号维护-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'帐号维护-完善资料')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'帐号维护-修改密码')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'会员管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'会员管理-返现')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'楼宇库-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'楼宇库-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'楼宇库-编辑')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'楼宇库-删除')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'内部帐号管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'内部帐号管理-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'内部帐号管理-编辑')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'内部帐号管理-删除')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'内部帐号管理-权限设置')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'内部帐号管理-修改密码')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'投诉管理-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'活动设置-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'活动设置-添加')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'活动设置-修改')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商户数据维护-查看')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商户数据维护-合作')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商户数据维护-暂不合作')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'商户数据维护-开通帐号')");
										sb.AppendLine("INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'推荐商户管理-查看')");
					            

            System.IO.File.WriteAllText(filename, sb.ToString());   
        }
    }
}