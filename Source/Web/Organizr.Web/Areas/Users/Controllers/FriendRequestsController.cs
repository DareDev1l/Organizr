namespace Organizr.Web.Areas.Users.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using MvcTemplate.Services.Data;

    public class FriendRequestsController : Controller
    {
        private IUsersServices usersServices;
        private IFriendRequestServices friendRequestServices;

        public FriendRequestsController(IUsersServices usersServices, IFriendRequestServices friendRequestServices)
        {
            this.usersServices = usersServices;
            this.friendRequestServices = friendRequestServices;
        }

        // GET: Users/FriendRequests
        public ActionResult SendFriendRequest(string senderId, string receiverId)
        {
            // var sender = this.usersServices.GetUserById(senderId);
            // var receiver = this.usersServices.GetUserById(receiverId);
            var friendshipRequest = new FriendRequest()
            {
                CreatedOn = DateTime.Now,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            this.friendRequestServices.CreateFriendRequest(friendshipRequest);

            return this.View("Index");
        }
    }
}