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
                "Search/{text}/{page}",
                new { controller = "Search", action = "SimpleSearch", text = UrlParameter.Optional, page = UrlParameter.Optional }
            );
        }
    }
}