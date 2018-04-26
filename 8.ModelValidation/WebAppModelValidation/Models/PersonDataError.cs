using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppModelValidation.Customs;
using WebAppModelValidation.Properties;

namespace WebAppModelValidation.Models.DataError
{
    public class Person : IDataErrorInfo
    {
        [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("性别")]
        public string Gender { get; set; }
        [DisplayName("年龄")]
        public int? Age { get; set; }

        public string Error
        {
            get; private set;
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            if (string.IsNullOrEmpty(this.Name))
                            {
                                return "Name 是必须字段";
                            }
                            return null;
                        }
                    case "Gender":
                        {
                            if (string.IsNullOrEmpty(this.Gender))
                            {
                                return "Gender 是必须字段";
                            }
                            else if (!new string[] { "M", "F" }.Any(g => string.Compare(this.Gender, g, true) == 0))
                            {
                                return "有效Gender 必须是M，F之一";
                            }
                            return null;
                        }
                    case "Age":
                        {
                            if (null == this.Age)
                            {
                                return "Age 是必须字段";
                            }
                            else if (this.Age > 25 || this.Age < 18)
                            {
                                return "有效Age 必须在18到25岁之间";
                            }
                            return null;
                        }
                    default: return null;
                }
            }
        }
    }
}