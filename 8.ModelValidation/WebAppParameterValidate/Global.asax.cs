using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppParameterValidate.Customs;

namespace WebAppParameterValidate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //DataAnnotationsModelValidatorProvider validatorProvider = ModelValidatorProviders.Providers
            //    .OfType<DataAnnotationsModelValidatorProvider>()
            //    .FirstOrDefault();
            //if (null != validatorProvider)
            //{
            //    ModelValidatorProviders.Providers.Remove(validatorProvider);
            //}
            //ModelValidatorProviders.Providers.Add(new ParameterValidationModelValidatorProvider());

            DataAnnotationsModelValidatorProvider validatorProvider = ModelValidatorProviders.Providers
                .OfType<DataAnnotationsModelValidatorProvider>()
                .FirstOrDefault();
            if (null != validatorProvider)
            {
                ModelValidatorProviders.Providers.Remove(validatorProvider);
            }
            ModelValidatorProviders.Providers.Add(new RuleBasedValidatorProvider());
        }
    }
}
