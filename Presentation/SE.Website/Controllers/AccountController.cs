﻿
using BussinessLogic;
using DataAccess;
using Website.Filters;
using Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using WebExpress.Core.Guards;
using WebExpress.Website.Exceptions;
using AutoMapper;
using Common.Types;

namespace Website.Controllers
{
    [RequireAuthority(AuthorityNames.AccountSetting)]
    public class AccountController : Controller
    {
        //private ShopBussinessLogic _shopBll;
        private AccountBussinessLogic _bllAccount;
        //private PersonBussinessLogic _personBll;
        //public AccountController(ShopBussinessLogic shopBll, AccountBussinessLogic accountBll, PersonBussinessLogic personBll)
        //{
        //    _shopBll = shopBll;
        //    _accountBll = accountBll;
        //    _personBll = personBll;
        //}

        public AccountController(AccountBussinessLogic bllAccount)
        {
            _bllAccount = bllAccount;
        }

        //[RequireAuthority(AuthorityNames.SettingAccount)]
        public ActionResult Index()
        {
            var model = new AccountListPageModel();
            model.Title = "账号列表";
            model.RequestListUrl = "/Account/_List";
            model.AddItemUrl = "/Account/Add";
            return View(model);
        }

        // [RequireAuthority(AuthorityNames.SettingAccount)]
        public PartialViewResult _List(AccountSearchCriteria criteria)
        {
            var accounts = _bllAccount.Search(criteria);

            var items = Mapper.Map<PagedList<Account>, AccountListItemModel[]>(accounts);
            var model = new PagedModel<AccountListItemModel>();
            model.Items = items;
            model.PagingResult = accounts.PagingResult;
            return PartialView("_CommonList", model);
        }

        //#region 登录

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            var captcha = Session["captcha"];
            if (captcha == null || !captcha.ToString().Equals(model.Captcha, StringComparison.CurrentCultureIgnoreCase))
            {
                return Json(new ResultModel(false, "验证码错误"));
            }
            var entity = _bllAccount.GetAccountByLoginName(model.LoginName);
            if (entity == null)
            {
                return Json(new ResultModel(false, "用户名或密码错误"));
            }
            if (!entity.Password.Equals(model.Password))
            {
                return Json(new ResultModel(false, "密码错误"));
            }
            //if (entity.AccountType == AccountType.Shop)
            //{
            //    if (!entity.Shop.IsIntegral)
            //    {
            //        return Json(new ResultModel(false, "请先完善改店铺资料"));
            //    }
            //}

            var _authenticationService = new FormAuthenticationService();
            _authenticationService.SignIn(model.LoginName, model.RememberMe);

            return Json(new ResultModel(true));
        }
        //验证码生成
        [AllowAnonymous]
        public FileContentResult CaptchaImage()
        {
            var captcha = new LiteralCaptcha(60, 30, 4);
            var bytes = captcha.Generate();
            Session["captcha"] = captcha.Captcha;
            return new FileContentResult(bytes, "image/jpeg"); ;
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            IAuthenticationService _authenticationService = new FormAuthenticationService();
            _authenticationService.SignOut();
            return RedirectToAction("Login", "Account");
        }

        //#endregion

        #region 删除账号
        //[RequireAuthority(AuthorityNames.AccountDelete)]
        public JsonResult Delete(int id)
        {
            var account = _bllAccount.Get(id);
            //Guard.IsNotNull<DataNotFoundException>(account); 
            _bllAccount.Delete(account);
            return Json(new ResultModel(true), JsonRequestBehavior.AllowGet);
        }
        #endregion

        //#region 重设密码
        //[HttpPost]
        //[RequireAuthority(AuthorityNames.ShopAccountResetPassword)]
        //public ActionResult ResetPassword(int accountId)
        //{
        //    var account = _accountBll.Get(accountId);
        //    Guard.IsNotNull<DataNotFoundException>(account);
        //    account.Password = "123456";
        //    _accountBll.Update(account);
        //    return Json(new ResultModel(true));
        //}
        //#endregion

        //#region 账号密码修改
        //[RequireAuthority(AuthorityNames.ShopAccountModifyPassword)]
        //public ActionResult ChangePassword(ChangePasswordModel model)
        //{
        //    var account = _accountBll.Get(model.AccountId);
        //    Guard.IsNotNull<DataNotFoundException>(account);
        //    if (account.Password != model.OldPassword)
        //    {
        //        return Json(new ResultModel(false, "原密码不正确"));
        //    }
        //    account.Password = model.NewPassword;
        //    _accountBll.Update(account);
        //    return Json(new ResultModel(true));
        //}
        //#endregion

        //#region 商户账号
        //[RequireAuthority(AuthorityNames.ShopAccountView)]
        //public ActionResult Shops()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[RequireAuthority(AuthorityNames.ShopAccountView)]
        //public PartialViewResult Shops(ShopSearchCriteria criteria)
        //{
        //    if (UserContext.Current.AccountType == AccountType.GeneralUser)
        //    {
        //        criteria.ShopId = UserContext.Current.Shop.Id;
        //    }

        //    var result = _shopBll.Search(criteria);
        //    var model = result.ToPagedModel<Shop, ShopAccountModel>();
        //    return PartialView("_Shops", model);
        //}
        //[RequireAuthority(AuthorityNames.ShopAccountAdd)]
        //public JsonResult AddShopAccount(ShopAccountModel model)
        //{
        //    if (_accountBll.Exist(i => i.LoginName == model.LoginName))
        //    {
        //        return Json(new ResultModel(false, "登录名已存在"));
        //    }
        //    var entity = model.Translate(model);

        //    if (!string.IsNullOrEmpty(model.BilinShopOriginalId))
        //    {
        //        var originalId = model.BilinShopOriginalId;
        //        var bllBLShop = DependencyResolver.Current.GetService<BilinShopBussinessLogic>();
        //        var bllBLShopCmty = DependencyResolver.Current.GetService<BilinShopCommunityBussinessLogic>();
        //        var blShop = bllBLShop.GetByOriginalId(model.BilinShopOriginalId);
        //        entity.DeliveryMinAmount = blShop.DeliveryMinAmount;
        //        entity.DeliveryRate = blShop.DeliveryRate ?? 0;
        //        entity.TelePhoneNumber = blShop.TelePhoneNumber;
        //        entity.MobilePhoneNumber = blShop.MobilePhoneNumber;
        //        entity.DetailAddress = blShop.DetailAddress;
        //        entity.DailyOpeningTime = blShop.DailyOpeningTime;
        //        entity.DailyClosingTime = blShop.DailyClosingTime;
        //        entity.BilinOriginalId = originalId;
        //        entity.CommunityId = blShop.LocalCommunityId;
        //        entity.CommunityShops = bllBLShopCmty.Where(i => i.ShopOriginalId == originalId).ToList().Select(i => new CommunityShop { CommunityId = i.CommunityId }).ToList();
        //        blShop.Status = SE.Common.Types.BilinShopStatus.AccountCreated;
        //    }
        //    _shopBll.Insert(entity);

        //    //张俊杰添加
        //    //2014-07-29
        //    #region 添加商户权限
        //    var shopAccount = entity.Account;
        //    shopAccount.AccountAuthorities.Clear();
        //    var allAuthorities = _accountBll.GetAllAuthorities();
        //    var defaultAuthorities = DefaultAuthoritiesForShop.DefaultAuthorities;
        //    for (int i = 0; i < defaultAuthorities.Count; i++)
        //    {
        //        var theAuthority = allAuthorities.FirstOrDefault(m => m.Name.Equals(defaultAuthorities[i]));
        //        if (theAuthority != null)
        //        {
        //            shopAccount.AccountAuthorities.Add(new AccountAuthority()
        //            {
        //                Account = shopAccount,
        //                Authority = theAuthority
        //            });
        //        }
        //    }
        //    _accountBll.Update(shopAccount);
        //    #endregion
        //    return Json(new ResultModel(true));
        //}

        //#endregion

        //#region 内部账号
        //[RequireAuthority(AuthorityNames.AccountView)]
        //public ActionResult Persons()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public PartialViewResult Persons(PersonSearchCriteria criteria)
        //{
        //    var result = _personBll.Search(criteria);
        //    var model = result.ToPagedModel<AdminPerson, PersonAccountModel>();
        //    return PartialView("_Persons", model);
        //}

        //public bool Validate(PersonAccountModel model, out string message)
        //{
        //    var at = DependencyResolver.Current.GetService<AccountBussinessLogic>().GetAccountByLoginName(model.LoginName);
        //    if (at != null && at.Id != model.PersonId)
        //    {
        //        message = "账号已存在";
        //        return false;
        //    }
        //    if (model.Name == null)
        //    {
        //        message = "员工姓名不能为空";
        //        return false;
        //    }
        //    if (model.LoginName == null)
        //    {
        //        message = "登录名不能为空";
        //        return false;
        //    }
        //    if (model.Password == null)
        //    {
        //        message = "密码不能为空";
        //        return false;
        //    }
        //    if (model.Department == null)
        //    {
        //        message = "部门不能为空";
        //        return false;
        //    }

        //    message = null;
        //    return true;
        //}

        //[RequireAuthority(AuthorityNames.AccountAdd)]
        public JsonResult Add(AccountAddModel model)
        {
            var entity = Mapper.Map<AccountAddModel, Account>(model);
            entity.AccountType = AccountType.GeneralUser;
            _bllAccount.Insert(entity);
            return Json(new ResultModel(true));
        }

        //[RequireAuthority(AuthorityNames.AccountUpdate)]
        public JsonResult Update(AccountUpdateModel model)
        {
            var entity = _bllAccount.Get(model.Id);
            entity.Name = model.Name;
            entity.LoginName = model.LoginName;
            entity.MajorId = model.MajorId;
            entity.Password = model.Password;
            entity.PhoneNumber = model.PhoneNumber;
            _bllAccount.Update(entity);
            return Json(new ResultModel(true));
        }
        //#endregion

        #region 权限
        public JsonResult GetAuthorities(int accountId)
        {
            var authorities = _bllAccount.Get(accountId).AccountAuthorities.Select(i => i.AuthorityId).ToArray();
            return Json(authorities);
        }

        //[RequireAuthority(AuthorityNames.SettingAccount)]
        public ActionResult UpdateAuthorities(int accountId, int[] authorityIds)
        {
            var account = _bllAccount.Get(accountId);
            if (account == null)
            {
                return Json(new ResultModel(false, "没有获取到该账号信息"));
            }
            #region 修改权限
            var allAuthorities = _bllAccount.GetAllAuthorities().Where(i => i.Name != AuthorityNames.AccountSetting);

            foreach (var item in allAuthorities)
            {
                if (authorityIds.Contains(item.Id))
                {
                    if (!account.AccountAuthorities.Any(p => p.AuthorityId == item.Id))
                    {
                        account.AccountAuthorities.Add(new AccountAuthority()
                        {
                            Account = account,
                            Authority = item
                        });
                    }
                }
                else
                {
                    var accountAuthority = account.AccountAuthorities.FirstOrDefault(p => p.AuthorityId == item.Id);
                    if (accountAuthority != null)
                    {
                        _bllAccount.DeleteAccountAuthority(accountAuthority);
                    }
                }
            }

            _bllAccount.Update(account);
            #endregion

            return Json(new ResultModel(true));
        }
        #endregion
    }
}
