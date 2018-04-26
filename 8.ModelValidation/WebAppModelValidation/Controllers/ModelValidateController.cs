using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppModelValidation.Models;

namespace WebAppModelValidation.Controllers
{
    public class ModelValidateController : Controller
    {
        // GET: ModelValidate
        public ActionResult Index()
        {
            Address address = new Address
            {
                Province = "shanghai",
                City = "shagnhai",
                District = "minhang",
                Street = "dongchuan"
            };
            Contact contact = new Contact
            {
                Name = "jeffrey",
                PhoneNo = "123444",
                EmailAddress = "jeffrey@gmail.com",
                Address = address
            };
            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(() => contact, typeof(Contact));
            ModelValidator validator = ModelValidator.GetModelValidator(metadata, ControllerContext);
            return View(validator.Validate(contact));
        }

        public ActionResult Contact()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            return View(contact);
        }
    }
}