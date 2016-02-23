namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Organizr.Data.Common;
    using Organizr.Data.Models;

    public class CoordinatesServices : ICoordinatesServices
    {
        private IDbRepository<Coordinates> coordinates;

        public CoordinatesServices(IDbRepository<Coordinates> coordinates)
        {
            this.coordinates = coordinates;
        }

        public void Delete(Coordinates coordinates)
        {
            this.coordinates.Delete(coordinates);
            this.coordinates.Save();
        }

        public void Update(Coordinates coordinates)
        {
            this.coordinates.Save();
        }

        public IQueryable<Coordinates> GetAll()
        {
            return this.coordinates.All();
        }

        public void Create(Coordinates coordinates)
        {
            this.coordinates.Add(coordinates);
            this.coordinates.Save();
        }
    }
}
