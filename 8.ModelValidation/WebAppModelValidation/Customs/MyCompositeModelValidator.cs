using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppModelValidation.Customs
{
    public class MyCompositeModelValidator : ModelValidator
    {
        public MyCompositeModelValidator(ModelMetadata metadata, ControllerContext controllerContext) : base(metadata, controllerContext)
        {
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            bool isProtpertiesValid = true;
            foreach (ModelMetadata propertyMetadata in Metadata.Properties)
            {
                foreach (ModelValidator validator in propertyMetadata.GetValidators(ControllerContext))
                {
                    IEnumerable<ModelValidationResult> results = validator.Validate(Metadata.Model);
                    if (results.Any())
                    {
                        isProtpertiesValid = false;
                    }
                    foreach (ModelValidationResult result in results)
                    {
                        string key = (propertyMetadata.PropertyName ?? "") + "." + (result.MemberName ?? "");
                        yield return new ModelValidationResult
                        {
                            MemberName = key,
                            Message = result.Message
                        };
                    }
                }
            }
            if (isProtpertiesValid)
            {
                foreach (ModelValidator validator in Metadata.GetValidators(ControllerContext))
                {
                    IEnumerable<ModelValidationResult> results = validator.Validate(Metadata.Model);
                    foreach (ModelValidationResult result in results)
                    {
                        yield return result;
                    }
                }
            }
        }
    }
}