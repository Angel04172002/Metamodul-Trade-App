using Microsoft.AspNetCore.Mvc.Filters;

namespace MetamodulTradeApp.Attributes
{
    public class GetQueryIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.HttpContext.Request;


        }
    }
}
