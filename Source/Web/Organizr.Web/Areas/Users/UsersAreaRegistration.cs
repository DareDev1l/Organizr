using System.Web.Mvc;

namespace Organizr.Web.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Users_FriendRequests",
                "Me/FriendRequests",
                new { controller = "FriendRequests", action = "GetFriendRequests" }
            );
            context.MapRoute(
                "Users_default",
                "{controller}/{action}/{senderId}/{receiverId}",
                new {controller = "FriendRequests", action = "SendFriendRequest" }
            );
        }
    }
}