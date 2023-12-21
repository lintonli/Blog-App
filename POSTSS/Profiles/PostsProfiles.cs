using AutoMapper;
using POSTSS.Models;
using POSTSS.Models.Dtos;

namespace POSTSS.Profiles
{
    public class PostsProfiles:Profile
    {
        public PostsProfiles()
        {
            CreateMap<AddPostDto, Post>().ReverseMap();
            CreateMap<AddPostImageDto, PostImage>().ReverseMap();
            CreateMap<Post, PostandImageResponseDto>().ReverseMap();
        }
    }
}
