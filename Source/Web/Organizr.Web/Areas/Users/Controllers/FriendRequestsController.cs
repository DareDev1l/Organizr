namespace Organizr.Web.Areas.Users.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;
    using ViewModels;

    [Authorize]
    public class FriendRequestsController : Controller
    {
        private IUsersServices usersServices;
        private IFriendRequestServices friendRequestServices;

        public FriendRequestsController(IUsersServices usersServices, IFriendRequestServices friendRequestServices)
        {
            this.usersServices = usersServices;
            this.friendRequestServices = friendRequestServices;
        }

        public ActionResult GetFriendRequests()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var currentUser = this.usersServices.GetUserById(currentUserId);

            var friendRequests = this.friendRequestServices
                                    .GetAll()
                                    .Where(x => x.IsDeleted == false && x.ReceiverId == currentUserId)
                                    .To<FriendRequestViewModel>()
                                    .ToList();

            return this.View(friendRequests);
        }

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