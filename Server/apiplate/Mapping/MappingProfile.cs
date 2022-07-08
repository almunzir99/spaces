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
            CreateMap<TranslationResource, Translation>().ReverseMap();
            CreateMap<TagResource, Tag>().ReverseMap();
            CreateMap<ImageResource, Image>().ReverseMap();
            CreateMap<ArticleResource, Article>().ReverseMap();
            CreateMap<ArticleRequestResource, Article>().ReverseMap();
            CreateMap<CommentResource, Comment>().ReverseMap();
            CreateMap<SectorResource, Sector>().ReverseMap();
            CreateMap<SectorRequestResource, Sector>().ReverseMap();
            CreateMap<RegionResource, Region>().ReverseMap();
            CreateMap<RegionRequestResource, Region>().ReverseMap();
            CreateMap<SliderResource, Slider>().ReverseMap();
            CreateMap<SliderRequestResource, Slider>().ReverseMap();
            CreateMap<TeamRequestResource, Team>().ReverseMap();
            CreateMap<TeamResource, Team>().ReverseMap();
            CreateMap<TeamRequestResource, Team>().ReverseMap();
            CreateMap<PartnerResource, Partner>().ReverseMap();
            CreateMap<PartnerRequestResource, Partner>().ReverseMap();
            CreateMap<TestimonialResource, Testimonial>().ReverseMap();
            CreateMap<TestimonialRequestResource, Testimonial>().ReverseMap();
            CreateMap<ProjectResource, Project>().ReverseMap();
            CreateMap<ProjectRequestResource, Project>().ReverseMap();
            CreateMap<MediaResource, Media>().ReverseMap();
            CreateMap<MediaRequestResource, Media>().ReverseMap();


        }


    }

}