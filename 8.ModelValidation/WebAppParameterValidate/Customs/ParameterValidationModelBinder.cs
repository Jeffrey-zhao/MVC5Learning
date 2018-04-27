using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppParameterValidate.Customs
{
    public class ParameterValidationModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object model = bindingContext.ModelMetadata.Model = base.BindModel(controllerContext, bindingContext);
            ModelMetadata metadata = bindingContext.ModelMetadata;
            if (metadata.IsComplexType || null == model)
            {
                return model;
            }
            Dictionary<string, bool> dicionary = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
            var results = ModelValidator.GetModelValidator(metadata, controllerContext).Validate(null);
            foreach (ModelValidationResult result in results)
            {
                string key = bindingContext.ModelName;
                if (!dicionary.ContainsKey(key))
                {
                    dicionary[key] = bindingContext.ModelState.IsValidField(key);
                }
                if (dicionary[key])
                {
                    bindingContext.ModelState.AddModelError(key, result.Message);
                }
            }
            return model;
        }
    }
}