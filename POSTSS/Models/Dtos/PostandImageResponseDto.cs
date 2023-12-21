namespace POSTSS.Models.Dtos
{
    public class PostandImageResponseDto
    {
       public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        List<AddPostImageDto> postImages {  get; set; }=new List<AddPostImageDto>();

    }
}
