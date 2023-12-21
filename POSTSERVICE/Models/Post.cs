namespace POSTSERVICE.Models
{
    public class Post
    {
        public Guid Id {  get; set; }
        public string Description {  get; set; }=string.Empty;
        public string Image {  get; set; }=string.Empty;

    }
}
