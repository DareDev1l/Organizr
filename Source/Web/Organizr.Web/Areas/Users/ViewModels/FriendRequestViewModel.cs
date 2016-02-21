namespace Organizr.Web.Areas.Users.ViewModels
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class FriendRequestViewModel : IMapFrom<FriendRequest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string SenderEmail { get; set; }

        public string SenderId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Organizr.Data.Models.FriendRequest, FriendRequestViewModel>()
                .ForMember(x => x.SenderEmail, opt => opt.MapFrom(x => x.Sender.Email));
        }
    }
}