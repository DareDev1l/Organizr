namespace MvcTemplate.Services.Data
{
    using Organizr.Data.Models;

    public interface IFriendRequestServices
    {
        void CreateFriendRequest(FriendRequest friendRequest);

        void DeleteFriendRequest(FriendRequest friendRequest);
    }
}
