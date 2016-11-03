namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;

    public interface IFriendRequestServices
    {
        void CreateFriendRequest(FriendRequest friendRequest);

        void DeleteFriendRequest(FriendRequest friendRequest);

        IQueryable<FriendRequest> GetAll();
    }
}
