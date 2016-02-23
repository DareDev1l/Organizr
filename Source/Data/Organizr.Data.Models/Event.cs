namespace Organizr.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Event : BaseModel<int>
    {
        private ICollection<User> participants;

        public Event()
        {
            this.participants = new HashSet<User>();
        }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public string OrganiserId { get; set; }

        public virtual User Organiser { get; set; }

        public DateTime? StartDate { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public int CoordinatesId { get; set; }

        public virtual Coordinates Coordinates { get; set; }

        public bool HasFinished { get; set; }

        public virtual ICollection<User> Participants
        {
            get
            {
                return this.participants;
            }

            set
            {
                this.participants = value;
            }
        }
    }
}
