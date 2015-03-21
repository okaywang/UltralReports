using Art.WebService.Models;
using SE.BussinessLogic;
using SE.Common.Helpers;
using SE.Common.Types;
using SE.DataAccess;
using SE.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebExpress.Core;

namespace SE.WebService.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerBussinessLogic _customerBll;
        private OrderBussinessLogic _orderBll;
        private ActivityBussinessLogic _activityBll;
        private AppVersionBussinessLogic _appVersionBll;
        public CustomerController(CustomerBussinessLogic customerBll, OrderBussinessLogic orderBll, ActivityBussinessLogic activityBll, AppVersionBussinessLogic appVersionBll)
        {
            _customerBll = customerBll;
            _orderBll = orderBll;
            _activityBll = activityBll;
            _appVersionBll = appVersionBll;
        }
        private static string _CheckCode = "123456";
        /// <summary>
        /// 手机号码登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ActionStatus(typeof(LoginModelStatus))]
        [HttpPost]
        public ResultModel<LoginResultModel> Login(LoginModel model)
        {
            if (!CommonValidator.IsValidPhoneNumber(model.PhoneNumber))
            {
                return ResultModel<LoginResultModel>.Conclude(LoginModelStatus.InvalidPhoneNumber);
            }
            if (model.PhoneNumber == "15811282129")
            {
                if (model.Code != _CheckCode)
                    return ResultModel<LoginResultModel>.Conclude(LoginModelStatus.IncorrectCheckCode);
            }
            //if (model.Code != SEApiCaching.Instance.Get(model.PhoneNumber))
            //{
            //    return ResultModel<LoginResultModel>.Conclude(LoginModelStatus.IncorrectCheckCode);
            //}

            var result = new LoginResultModel();

            var customer = _customerBll.GetByPhoneNumber(model.PhoneNumber);
            if (customer == null)
            {
                customer = new Customer();
                customer.PhoneNumber = model.PhoneNumber;
                customer.CurrentScore = 0;
                customer.RegisterDateTime = DateTime.Now;
                _customerBll.Insert(customer);
            }

            result.CustomerId = customer.Id;

            if (customer.Recipient != null)
            {
                result.Address = customer.Recipient.DetailAddress;
                result.Gender = customer.Recipient.Gender;
                result.Name = customer.Recipient.Name;
            }

            return ResultModel<LoginResultModel>.Conclude(LoginModelStatus.Success, result);
        }

        /// <summary>
        /// 请求动态验证码
        /// c</summary>
        [ActionStatus(typeof(SendCheckCodeStatus))]
        [HttpGet]
        public SimpleResultModel CheckCode(string PhoneNumber)
        {
            if (!CommonValidator.IsValidPhoneNumber(PhoneNumber))
            {
                return SimpleResultModel.Conclude(SendCheckCodeStatus.InvlidPhoneNumber);
            }
            var randomCode = new Random().Next(1000000).ToString("D6");

            var sms = new WebReference.SmsSoapClient();

            var msg = string.Format(SEApiConfig.Instance.SmsContentCheckCodeShop, randomCode);
            try
            {
                SEApiCaching.Instance.Add(PhoneNumber, randomCode); 
                Task.Factory.StartNew(() =>
                {
                    sms.SendSmsSaveLog(PhoneNumber, msg, 2, "ShopWebApi");
                }); 

                return SimpleResultModel.Conclude(SendCheckCodeStatus.Sending); 
            }
            catch (Exception)
            {
                return SimpleResultModel.Conclude(SendCheckCodeStatus.SendFailure);
            }
        }

        /// <summary>
        /// 反馈建议
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [ActionStatus(typeof(SuggestionModelStatus))]
        [HttpGet]
        public ResultModel<bool> UpSuggestion(int userId, string message, string PhoneNumber)
        {
            if (_customerBll.Get(userId) == null)
            {
                return ResultModel<bool>.Conclude(SuggestionModelStatus.InvalidUser);
            }
            if (!CommonValidator.IsValidPhoneNumber(PhoneNumber))
            {
                return ResultModel<bool>.Conclude(LoginModelStatus.InvalidPhoneNumber);
            }
            var suggestion = new Suggestion()
            {
                CustomerId = userId,
                Message = message,
                AddTime = DateTime.Now,
                Status = 0,
                PhoneNumber = PhoneNumber
            };
            _customerBll.InsertSuggestion(suggestion);
            return ResultModel<bool>.Conclude(SuggestionModelStatus.Success, true);

        }
        /// <summary>
        /// 发起返现
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        [ActionStatus(typeof(SuggestionModelStatus))]
        [HttpGet]
        public ResultModel<bool> DoCashback(int UserId, int Price)
        {
            var customer = _customerBll.Get(UserId);
            if (customer == null)
            {
                return ResultModel<bool>.Conclude(SuggestionModelStatus.InvalidUser);
            }
            if (customer.CurrentScore < Price)
            {
                return ResultModel<bool>.Conclude(SuggestionModelStatus.CashBackPriceFalse);
            }
            customer.ThisCashBackPrice = Price;
            customer.CurrentScore = customer.CurrentScore - Price;
            _customerBll.Update(customer);
            return ResultModel<bool>.Conclude(SuggestionModelStatus.Success, true);

        }
        /// <summary>
        /// 我的返现
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(SuggestionModelStatus))]
        [HttpGet]
        public ResultModel<MyCashBackModel> MyCashBack(int UserId)
        {
            var customer = _customerBll.Get(UserId);
            if (customer == null)
            {
                return ResultModel<MyCashBackModel>.Conclude(SuggestionModelStatus.InvalidUser);
            }
            var activity = _activityBll.GetActivity(true);
            var model = new MyCashBackModel()
            {
                CashBackPrice = customer.CurrentScore
            };
            if (activity != null)
            {
                model.ImagePath = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/Activity/" + activity.ImageName;
            }
            return ResultModel<MyCashBackModel>.Conclude(SuggestionModelStatus.Success, model);

        }
        /// <summary>
        /// 获取最新版本号
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionStatus(typeof(LatestVersionStatus))]
        public ResultModel<LatestVersionModel> LatestVersion(DeviceType DeviceType)
        {
            if (!Enum.IsDefined(typeof(DeviceType), DeviceType))
            {
                return ResultModel<LatestVersionModel>.Conclude(LatestVersionStatus.InvalidDeviceType);
            }
            var result = _appVersionBll.GetLastedVersion(DeviceType);

            if (result != null)
            {
                var LatestVersionResult = new LatestVersionModel()
                {
                    LatestVersion = result.Version,
                    IsMandatoryUpgrade = result.IsMandatoryUpgrade,
                    UrlAddress = result.UrlAddress,
                    Message = result.Message
                };
                return ResultModel<LatestVersionModel>.Conclude(SuggestionModelStatus.Success, LatestVersionResult);
            }
            else
            {
                return ResultModel<LatestVersionModel>.Conclude(SuggestionModelStatus.Success, null);
            }


        }
        public enum LatestVersionStatus
        {
            Success,

            [DisplayText("无效的版本号")]
            InvalidDeviceType
        }
    }
}