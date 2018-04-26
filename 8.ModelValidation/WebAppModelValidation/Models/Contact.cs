﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppModelValidation.Customs;

namespace WebAppModelValidation.Models
{
    [AlwaysFails(ErrorMessage = "Contact")]
    public class Contact
    {
        [AlwaysFails(ErrorMessage = "Contact.Name")]
        [Required(ErrorMessage ="{0}必须的")]
        public string Name { get; set; }
        [AlwaysFails(ErrorMessage = "Contact.PhoneNo")]
        public string PhoneNo { get; set; }
        [AlwaysFails(ErrorMessage = "Contact.EmailAddress")]
        public string EmailAddress { get; set; }
        [AlwaysFails(ErrorMessage = "Contact.Address")]
        public Address Address { get; set; }
    }
    [AlwaysFails(ErrorMessage = "Address")]
    public class Address
    {
        [AlwaysFails(ErrorMessage = "Address.Province")]
        public string Province { get; set; }
        [AlwaysFails(ErrorMessage = "Address.City")]
        public string City { get; set; }
        [AlwaysFails(ErrorMessage = "Address.District")]
        public string District { get; set; }
        [AlwaysFails(ErrorMessage = "Address.Street")]
        public string Street { get; set; }
    }
}