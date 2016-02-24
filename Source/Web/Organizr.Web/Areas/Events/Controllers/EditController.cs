namespace Organizr.Web.Areas.Events.Controllers
{
    using System.Web.Mvc;
    using MvcTemplate.Services.Data;
    using Services.Web;
    using ViewModels;
    using Web.Controllers;

    public class EditController : BaseController
    {
        private IEventsServices eventsServices;
        private IIdentifierProvider provider;

        public EditController(IEventsServices eventsServices)
        {
            this.eventsServices = eventsServices;
            this.provider = new IdentifierProvider();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventToEdit = this.eventsServices.GetById(id);

            var eventModel = this.Mapper.Map<EventEditViewModel>(eventToEdit);

            return this.View(eventModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Edit(model.Id);
            }

            var eventToEdit = this.eventsServices.GetById(model.Id);
            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.StartDate = model.StartDate;

            this.eventsServices.Update(eventToEdit);

            return this.Redirect("/Events/" + this.provider.EncodeId(model.Id));
        }
    }
}