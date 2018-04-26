using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppModelValidation.Customs
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Property)]
    public class AlwaysFailsAttribute:ValidationAttribute
    {
        private object typeId;
        public override bool IsValid(object value)
        {
            return false;
        }

        public override object TypeId
        {
            get
            {
                return typeId ?? (typeId = new object());
            }
        }
    }
}