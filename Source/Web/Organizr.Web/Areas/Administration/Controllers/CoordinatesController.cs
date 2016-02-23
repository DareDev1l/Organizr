namespace Organizr.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using MvcTemplate.Services.Data;
    using ViewModels.Events;
    using System.Linq;
    using Data.Models;

    public class CoordinatesController : Controller
    {
        private ICoordinatesServices coordinates;

        public CoordinatesController(ICoordinatesServices coordinates)
        {
            this.coordinates = coordinates;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Coordinates_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.coordinates
                .GetAll()
                .To<CoordinatesViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Coordinates_Update([DataSourceRequest]DataSourceRequest request, CoordinatesInputModel coordinate)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.coordinates.GetAll().FirstOrDefault(x => x.Id == coordinate.Id);
                entity.Latitude = coordinate.Latitude;
                entity.Longitude = coordinate.Longitude;
                this.coordinates.Update(entity);
            }

            return this.Json(new[] { coordinate }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Coordinates_Destroy([DataSourceRequest]DataSourceRequest request, Coordinates coordinate)
        {
            var coordinateToDelete = this.coordinates.GetAll().Where(x => x.Id == coordinate.Id).FirstOrDefault();
            this.coordinates.Delete(coordinateToDelete);

            return this.Json(new[] { coordinateToDelete }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Coordinates_Create([DataSourceRequest]DataSourceRequest request, CoordinatesInputModel coordinate)
        {
            var createCoordinate = new Coordinates()
            {
                Latitude = 0,
                Longitude = 0
            };

            if (this.ModelState.IsValid)
            {
                createCoordinate.Longitude = coordinate.Longitude;
                createCoordinate.Latitude = coordinate.Latitude;

                this.coordinates.Create(createCoordinate);
            }

            return this.Json(new[] { createCoordinate }.ToDataSourceResult(request, this.ModelState));
        }
    }
}