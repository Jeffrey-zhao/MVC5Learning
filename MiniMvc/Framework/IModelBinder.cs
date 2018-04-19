using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMvc.Framework
{
    public interface IModelBinder
    {
        object BindModel(ControllerContext controllerContext, string modelName, Type modelType);
    }
}
