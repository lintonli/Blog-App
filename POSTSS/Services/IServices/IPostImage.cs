using POSTSS.Models;

namespace POSTSS.Services.IServices
{
    public interface IPostImage
    {
        Task<string> AddImage(Guid Id, PostImage postImage);
    }
}
