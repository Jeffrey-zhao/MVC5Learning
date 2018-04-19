namespace MiniMvc.Framework
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(ControllerContext context);
    }
}