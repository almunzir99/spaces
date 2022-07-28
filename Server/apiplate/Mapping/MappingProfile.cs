using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;
using AutoMapper;

namespace apiplate.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoleResource, Role>().ReverseMap();
            CreateMap<RoleRequestResource, Role>().ReverseMap();
            CreateMap<PermissionResource, Permission>().ReverseMap();
            CreateMap<AdminResource, Admin>().ReverseMap();
            CreateMap<AdminRequestResource, Admin>().ReverseMap();
            CreateMap<MessageResource, Message>().ReverseMap();
            CreateMap<MessageRequestResource, Message>().ReverseMap();
            CreateMap<AdminResource, Admin>().ReverseMap();
            CreateMap<NotificationResource, Notification>().ReverseMap();
            CreateMap<TranslationResource, Translation>().ForMember(c => c.Id, opt => opt.Condition(c => c.Id != 0)).ReverseMap();
            CreateMap<TagResource, Tag>().ReverseMap();
            CreateMap<ImageResource, Image>().ForMember(c => c.Id, opt => opt.Condition(c => c.Id != 0)).ReverseMap();
            CreateMap<ArticleResource, Article>().ReverseMap();
            CreateMap<ArticleRequestResource, Article>()
            .ForMember(c => c.TitleId, opt => opt.Ignore())
            .ForMember(c => c.SubtitleId, opt => opt.Ignore())
            .ForMember(c => c.ContentId, opt => opt.Ignore())
            .ForMember(c => c.ImageId, opt => opt.Ignore());
            CreateMap<CommentResource, Comment>().ReverseMap();
            CreateMap<SectorResource, Sector>().ReverseMap();
            CreateMap<SectorRequestResource, Sector>()
             .ForMember(c => c.TitleId, opt => opt.Ignore())
            .ForMember(c => c.DescriptionId, opt => opt.Ignore())
            .ForMember(c => c.IconId, opt => opt.Ignore())
            .ForMember(c => c.ImageId, opt => opt.Ignore());
            CreateMap<RegionResource, Region>().ReverseMap();
            CreateMap<RegionRequestResource, Region>()
             .ForMember(c => c.DescriptionId, opt => opt.Ignore())
            .ForMember(c => c.TitleId, opt => opt.Ignore())
            .ForMember(c => c.ImageId, opt => opt.Ignore());
            CreateMap<SliderResource, Slider>().ReverseMap();
            CreateMap<SliderRequestResource, Slider>()
             .ForMember(c => c.TitleId, opt => opt.Ignore())
             .ForMember(c => c.SubtitleId, opt => opt.Ignore())
            .ForMember(c => c.DescriptionId, opt => opt.Ignore())
            .ForMember(c => c.ImageId, opt => opt.Ignore());
            CreateMap<TeamResource, Team>().ReverseMap();
            CreateMap<TeamRequestResource, Team>()
             .ForMember(c => c.NameId, opt => opt.Ignore())
             .ForMember(c => c.PositionId, opt => opt.Ignore())
            .ForMember(c => c.ImageId, opt => opt.Ignore());
            CreateMap<PartnerResource, Partner>().ReverseMap();
            CreateMap<PartnerRequestResource, Partner>()
             .ForMember(c => c.NameId, opt => opt.Ignore())
             .ForMember(c => c.LogoId, opt => opt.Ignore());
            CreateMap<TestimonialResource, Testimonial>().ReverseMap();
            CreateMap<TestimonialRequestResource, Testimonial>()
             .ForMember(c => c.ContentId, opt => opt.Ignore())
             .ForMember(c => c.AuthorId, opt => opt.Ignore())
            .ForMember(c => c.JobId, opt => opt.Ignore())
            .ForMember(c => c.ImageId, opt => opt.Ignore());
            CreateMap<ProjectResource, Project>().ReverseMap();
            CreateMap<ProjectRequestResource, Project>()
            .ForMember(c => c.TitleId, opt => opt.Ignore())
            .ForMember(c => c.SubtitleId, opt => opt.Ignore())
            .ForMember(c => c.ContentId, opt => opt.Ignore())
            .ForMember(c => c.ImageId, opt => opt.Ignore());
            CreateMap<MediaResource, Media>().ReverseMap();
            CreateMap<MediaRequestResource, Media>()
            .ForMember(c => c.Thumbnail, opt => opt.Ignore());
            CreateMap<VolunteerResource, Volunteer>().ReverseMap();
            CreateMap<VolunteerRequestResource, Volunteer>().ReverseMap();




        }


    }

}