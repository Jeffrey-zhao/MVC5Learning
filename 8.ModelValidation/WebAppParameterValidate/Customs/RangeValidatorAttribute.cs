using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebAppParameterValidate.Customs
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class RangeValidatorAttribute : ValidatorAttribute
    {
        private RangeAttribute rangeAttribute;
        public RangeValidatorAttribute(int minimum, int maximum)
        {
            rangeAttribute = new RangeAttribute(minimum, maximum);
        }
        public RangeValidatorAttribute(double minimum, double maximum)
        {
            rangeAttribute = new RangeAttribute(minimum, maximum);
        }
        public RangeValidatorAttribute(Type type, string minimum, string maximum)
        {
            rangeAttribute = new RangeAttribute(type, minimum, maximum);
        }
        public override bool IsValid(object value)
        {
            return rangeAttribute.IsValid(value);
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, base.ErrorMessageString, new object[] { name, rangeAttribute.Minimum, rangeAttribute.Maximum });
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValidatorAttribute : ValidationAttribute
    {
        private object typeId;
        public string RuleName { get; set; }
        public override object TypeId
        {
            get
            {
                return typeId ?? (typeId = new object());
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidationRuleAttribute : Attribute
    {
        public string RuleName { get; private set; }
        public ValidationRuleAttribute(string ruleName)
        {
            this.RuleName = ruleName;
        }
    }
}