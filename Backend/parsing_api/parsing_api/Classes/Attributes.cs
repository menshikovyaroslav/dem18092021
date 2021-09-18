using Microsoft.AspNetCore.Mvc.Filters;

namespace parsing_api.Classes
{
    /// <summary>
    /// Аттрибут для фронтенда - без него не работало
    /// </summary>
    public class AllowCrossSiteJson : ActionFilterAttribute
    {
        /// <summary>
        /// Переопределен метод для добавления заголовка
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}
