using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppModelValidation.Customs;
using WebAppModelValidation.Properties;

namespace WebAppModelValidation.Models
{
    public class Person
    {
        [DisplayName("姓名")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }
        [DisplayName("性别")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [Domain("M", "F", ErrorMessageResourceName = "Domain", ErrorMessageResourceType = typeof(Resources))]
        public string Gender { get; set; }
        [DisplayName("年龄")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessage ="{0}是必须的")]
        [Range(18, 25, ErrorMessageResourceName = "Domain", ErrorMessageResourceType = typeof(Resources))]
        public int? Age { get; set; }
    }
}