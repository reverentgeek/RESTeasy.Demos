using System.Web.Http;

namespace RESTeasy.Demos
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
				);

			//config.Routes.MapHttpRoute(
			//	name: "DefaultApiV2",
			//	routeTemplate: "api/{version}/{controller}/{id}",
			//	defaults: new { id = RouteParameter.Optional }
			//	);
		}
	}
}
