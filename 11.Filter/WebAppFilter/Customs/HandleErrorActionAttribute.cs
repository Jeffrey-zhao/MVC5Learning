
using System;

namespace WebAppFilter.Customs
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HandleErrorActionAttribute:Attribute
    {
        public string HandleErrorAction { get; private set; }
        public HandleErrorActionAttribute(string handleErrorAction)
        {
            this.HandleErrorAction = handleErrorAction;
        }
    }
}