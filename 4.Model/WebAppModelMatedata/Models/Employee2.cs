using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppModelMatedata.Customs;

namespace WebAppModelMatedata.Models
{
    public class Employee2
    {
        [DisplayTextNoIMetadataAware]
        public string Name { get; set; }
        [DisplayTextNoIMetadataAware]
        public string Gender { get; set; }
        [DisplayTextNoIMetadataAware]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DisplayTextNoIMetadataAware]
        public string Department { get; set; }
    }
}