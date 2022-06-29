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
            CreateMap<TranslationResource,Translation>().ReverseMap();
            CreateMap<TagResource,Tag>().ReverseMap();
            CreateMap<ImageResource,Image>().ReverseMap();
            CreateMap<ArticleResource,Article>().ReverseMap();
            CreateMap<ArticleRequestResource,Article>().ReverseMap();
            CreateMap<CommentResource,Comment>().ReverseMap();
            CreateMap<SectorResource,Sector>().ReverseMap();
            CreateMap<SectorRequestResource,Sector>().ReverseMap();
        }

         
    }

}