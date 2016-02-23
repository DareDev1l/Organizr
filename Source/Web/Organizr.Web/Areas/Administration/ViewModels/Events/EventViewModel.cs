namespace Organizr.Web.Areas.Administration.ViewModels.Events
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Organiser { get; set; }

        public DateTime? StartDate { get; set; }

        public string Location { get; set; }

        public bool HasFinished { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.Organiser, opt => opt.MapFrom(x => x.Organiser.FirstName + x.Organiser.LastName));

            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location.Name));
        }
    }
}