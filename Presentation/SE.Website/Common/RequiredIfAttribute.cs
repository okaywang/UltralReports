using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Common
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private String PropertyName { get; set; }
        private Object DesiredValue { get; set; }

        public string JsRequiredExpression { get; set; }

        public RequiredIfAttribute(String propertyName, Object desiredvalue, string jsExpression)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
            JsRequiredExpression = jsExpression;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (proprtyvalue.ToString() == DesiredValue.ToString())
            {
                if (value == null)
                {
                    return new ValidationResult(context.DisplayName + " 不能为空");
                }
            }
            return ValidationResult.Success;
        }
    }
}