namespace MiniMvc.Framework
{
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext controllerContext, string actionName);
    }
}