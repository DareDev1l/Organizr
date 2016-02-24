namespace Organizr.Web.Areas.Administration.ViewModels.Users
{
    using System.ComponentModel;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User> , IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Events visited")]
        public string EventsParticipatedCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(x => x.EventsParticipatedCount, opt => opt.MapFrom(x => x.EventsParticipated.Count));
        }
    }
}