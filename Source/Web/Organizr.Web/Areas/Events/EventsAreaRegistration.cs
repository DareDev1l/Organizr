using System.Web.Mvc;

namespace Organizr.Web.Areas.Events
{
    public class EventsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Events";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Rates_Rate",
                "Rates/Rate",
                new { controller = "Rates", action = "Rate" }
            );

            context.MapRoute(
                "Events_filter",
                "Events/Filter",
                new { controller = "List", action = "Filter" }
            );

            context.MapRoute(
                "Events_details",
                "Events/{id}",
                new { controller="Details", action="ById"}
            );

            context.MapRoute(
                "Events_edit",
                "Events/{id}/Edit",
                new { controller = "Edit", action = "Edit" }
            );

            context.MapRoute(
                "Events_default",
                "Events/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}