namespace Organizr.Data.Models
{
    using Organizr.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class FriendRequest : BaseModel<int>
    {
        [Required]
        public string SenderId { get; set; }

        public User Sender { get; set; }
    }
}
