using System;

namespace POSTSS.Models
{
    public class Post
    {
        public Guid Id {  get; set; }
        public string Description {  get; set; }=string.Empty;
        public  List<PostImage> Images {  get; set; }=new List<PostImage>();
        public DateTime created_at {  get; set; }=DateTime.Now;
        public DateTime updated_at { get; set;}=DateTime.Now;
        

    }
}
