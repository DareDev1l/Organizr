namespace MvcTemplate.Data.Models
{
    using Organizr.Data.Common.Models;
    using Organizr.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Location : BaseModel<int>
    {
        private ICollection<LocationRate> rates;
        private ICollection<User> owners;

        public Location()
        {
            this.owners = new HashSet<User>();
            this.rates = new HashSet<LocationRate>();
        }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public virtual ICollection<User> Owners
        {
            get
            {
                return this.owners;
            }

            set
            {
                this.owners = value;
            }
        }

        public virtual ICollection<LocationRate> Rates
        {
            get
            {
                return this.rates;
            }

            set
            {
                this.rates = value;
            }
        }

        public double Rating
        {
            // TODO: Extract method logic
            get
            {
                if (this.Rates.Count == 0)
                {
                    return 0;
                }

                double totalSum = 0;

                foreach (var rate in this.Rates)
                {
                    totalSum += rate.Value;
                }

                double averageRating = totalSum / this.Rates.Count;

                return averageRating;
            }
        }
    }
}