using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SE.WebService
{
    public class SEApiConfig
    {
        public static readonly SEApiConfig Instance = new SEApiConfig();

        private string _smsContentCheckCodeShop;
        public string SmsContentCheckCodeShop
        {
            get
            {
                if (string.IsNullOrEmpty(_smsContentCheckCodeShop))
                {
                    _smsContentCheckCodeShop = ConfigurationManager.AppSettings["SmsContentCheckCodeShop"];
                }
                return _smsContentCheckCodeShop;
            }
        }

        private string _smsContentPassword;
        public string SmsContentPassword
        {
            get
            {
                if (string.IsNullOrEmpty(_smsContentPassword))
                {
                    _smsContentPassword = ConfigurationManager.AppSettings["SmsContentPassword"];
                }
                return _smsContentPassword;
            }
        }
        private string _smsContentShop;
        public string SmsContentShop
        {
            get
            {
                if (string.IsNullOrEmpty(_smsContentShop))
                {
                    _smsContentShop = ConfigurationManager.AppSettings["SmsContentShop"];
                }
                return _smsContentShop;
            }
        }
    }
}