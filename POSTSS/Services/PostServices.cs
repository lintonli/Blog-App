using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POSTSS.Data;
using POSTSS.Migrations;
using POSTSS.Models;
using POSTSS.Models.Dtos;
using POSTSS.Services.IServices;

namespace POSTSS.Services
{
    public class PostServices : Ipost
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PostServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddPost(Post post)
        {
           _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return "Post added";
        }

        public async Task<string> DeletePost(Post pos)
        {
            _context.Posts.Remove(pos);
            await _context.SaveChangesAsync();
            return "Post deleted";
        }

        public  async Task<List<PostandImageResponseDto>> GetAllPost()

        {
            var posts = await _context.Posts.ToListAsync();
            var res = _mapper.Map<List<PostandImageResponseDto>>(posts);
          /*  Console.WriteLine(res);*/
            return res; 
        }

        public async Task<Post> GetPost(Guid Id)
        {
            return await _context.Posts.Where(x => x.Id == Id).FirstOrDefaultAsync();
         
            
            
        }

        public async Task<string> UpdatePost(Post post)
        {
            await _context.SaveChangesAsync();
            return "Post updated";
        }
    }
}
