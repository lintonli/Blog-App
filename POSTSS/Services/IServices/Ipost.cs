using POSTSS.Models;
using POSTSS.Models.Dtos;

namespace POSTSS.Services.IServices
{
    public interface Ipost
    {
        Task<List<PostandImageResponseDto>> GetAllPost();
        Task<Post> GetPost(Guid Id);
        Task<string> AddPost(Post post);
        Task<string> DeletePost(Post Pos);
        Task <string>UpdatePost(Post post);


    }
}
