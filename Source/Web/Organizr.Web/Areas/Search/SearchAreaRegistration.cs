using System.Web.Mvc;

namespace Organizr.Web.Areas.Search
{
    public class SearchAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Search";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Search_default",
                "Search",
                new { controller = "Search", action = "SimpleSearch" }
            );
        }
    }
}