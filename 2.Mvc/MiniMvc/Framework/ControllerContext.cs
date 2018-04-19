namespace MiniMvc.Framework
{
    public class ControllerContext
    {
        public ControllerBase Controller { get; set; }
        public RequestContext RequestContext { get; set; }
    }
}