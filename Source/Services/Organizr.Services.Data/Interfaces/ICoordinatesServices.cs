namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;

    public interface ICoordinatesServices
    {
        IQueryable<Coordinates> GetAll();

        void Delete(Coordinates coordinates);

        void Update(Coordinates coordinates);

        void Create(Coordinates coordinates);
    }
}
