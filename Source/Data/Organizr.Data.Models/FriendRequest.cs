namespace Organizr.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Organizr.Data.Common.Models;

    public class FriendRequest : BaseModel<int>
    {
        [Required]
        public string SenderId { get; set; }

        public User Sender { get; set; }

        public string ReceiverId { get; set; }

        public User Receiver { get; set; }
    }
}
