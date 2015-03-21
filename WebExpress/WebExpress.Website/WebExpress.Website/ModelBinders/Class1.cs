using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebExpress.Website.ModelBinders
{
    public class ArrayModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var originalMetadata = bindingContext.ModelMetadata;

            bindingContext.ModelMetadata = new ModelMetadata(
                ModelMetadataProviders.Current,
                originalMetadata.ContainerType,
                () => null,  //Forces model to null
                originalMetadata.ModelType,
                originalMetadata.PropertyName);

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
