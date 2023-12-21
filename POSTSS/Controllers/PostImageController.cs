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
    public class PostImageController : ControllerBase
    {
        private readonly Ipost _postService;
        private readonly IPostImage _postImageService;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        public PostImageController(IMapper mapper, Ipost ipost,IPostImage postImage)
        {
            _mapper = mapper;
            _postImageService = postImage;
            _responseDto = new ResponseDto();
            _postService = ipost;
        }
        [HttpPost("{Id}")]
        public async Task<ActionResult<ResponseDto>> AddImage(Guid Id, AddPostImageDto addPostImageDto)
        {
            var post = await _postService.GetPost(Id);
            if (post == null)
            {
                _responseDto.ErrorMessage = "Post Not found";
                return NotFound(_responseDto);
            }
            var image = _mapper.Map<PostImage>(addPostImageDto);
            var res = await _postImageService.AddImage(Id, image);
            _responseDto.Result = res;
            return Created("", _responseDto);
        }
    }
}
