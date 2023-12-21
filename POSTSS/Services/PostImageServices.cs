using POSTSS.Data;
using POSTSS.Models;
using POSTSS.Services.IServices;

namespace POSTSS.Services
{
    public class PostImageServices : IPostImage
    {
        private readonly ApplicationDbContext _context;
        public PostImageServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddImage(Guid Id, PostImage postImage)
        {
            var posts= _context.Posts.Where(x=>x.Id == Id).FirstOrDefault();
            posts.Images.Add(postImage);
            await _context.SaveChangesAsync();
            return "Image Added";
        }
    }
}
