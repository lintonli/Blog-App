namespace POSTSS.Models.Dtos
{
    public class AddPostDto
    {
        /*ublic Guid Id { get; set; }*/
        public string Description { get; set; } = string.Empty;
      
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; } 
    }
}
