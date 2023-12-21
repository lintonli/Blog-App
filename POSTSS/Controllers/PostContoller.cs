using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSTSS.Models;
using POSTSS.Models.Dtos;
using POSTSS.Services.IServices;

namespace POSTSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostContoller : ControllerBase
    {
        private readonly Ipost _postService;

        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;

        public PostContoller(Ipost ipost,IMapper mapper)

        {
            _postService = ipost;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto>>AddPost(AddPostDto dto)
        {
            var post = _mapper.Map<Post>(dto);
            var res = await _postService.AddPost(post);
            _responseDto.Result= res;
            return Created("", _responseDto);
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>>GetAllPosts()
        {
             
            var res = await _postService.GetAllPost();
            _responseDto.Result= res;
            return Ok(_responseDto);
        }
        [HttpDelete("{Id}")]
        public async Task<string> DeletePost(Guid Id)
        {
            var post = await _postService.GetPost(Id);
            if(post == null)
            {
                return "Post not found";
            }
            var res = await _postService.DeletePost(post);
            return "Post Deleted Successfully";
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseDto>>GetPost(Guid Id)
        {
            var post = await _postService.GetPost(Id);
            if(post == null)
            {
                return NotFound(_responseDto);
            }
            _responseDto.Result= post;
            return Ok(_responseDto);
        }
    }
}
