using System.ComponentModel.DataAnnotations.Schema;

namespace POSTSS.Models
{
    public class PostImage
    {
        public Guid Id {  get; set; }
        public string Image {  get; set; }=string.Empty;
        [ForeignKey("PostId")]
        public Post post { get; set; }
        public Guid PostId {  get; set; }
    }
}
