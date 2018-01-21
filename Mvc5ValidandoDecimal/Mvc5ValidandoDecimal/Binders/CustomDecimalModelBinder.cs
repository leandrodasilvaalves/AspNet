using System;
using System.Globalization;
using System.Web.Mvc;

namespace Mvc5ValidandoDecimal.Binders
{
    public class CustomDecimalModelBinder : IModelBinder
    {

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                var isNullableAndNull = (bindingContext.ModelMetadata.IsNullableValueType &&
                                            string.IsNullOrEmpty(valueResult.AttemptedValue));

                if (!isNullableAndNull)
                {
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
                }
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }

    }
}