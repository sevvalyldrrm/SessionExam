using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SessionExam.Filter
{
	public class Auth : Attribute, IActionFilter
	{
		void IActionFilter.OnActionExecuted(ActionExecutedContext context)
		{
			if (context.HttpContext.Session.Get("user") == null)
				context.Result = new RedirectResult("/Login/Login");

		}

		void IActionFilter.OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.Get("user") == null)
				context.Result = new RedirectResult("/Login/Login");

		}
	}
}
