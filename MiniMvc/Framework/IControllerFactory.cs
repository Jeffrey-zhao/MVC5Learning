namespace MiniMvc.Framework
{
    public interface IControllerFactory
    {
        IController CreateController(RequestContext requestContext, string controllerName);
    }
}