using System.Web.Mvc;

namespace Organizr.Web.Areas.Best
{
    public class BestAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Best";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Best_default",
                "Best",
                new { controller="Best" , action="Best" }
            );
        }
    }
}