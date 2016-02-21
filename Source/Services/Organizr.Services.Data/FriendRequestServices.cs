namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Organizr.Data.Common;
    using Organizr.Data.Models;

    public class FriendRequestServices : IFriendRequestServices
    {
        private IDbRepository<FriendRequest> friendRequests;

        public FriendRequestServices(IDbRepository<FriendRequest> friendRequests)
        {
            this.friendRequests = friendRequests;
        }

        public void CreateFriendRequest(FriendRequest friendRequest)
        {
            this.friendRequests.Add(friendRequest);
            this.friendRequests.Save();
        }

        public void DeleteFriendRequest(FriendRequest friendRequest)
        {
            friendRequest.IsDeleted = true;
            this.friendRequests.Save();
        }

        public IQueryable<FriendRequest> GetAll()
        {
            return this.friendRequests.All();
        }
    }
}
