using System;
using System.ComponentModel.DataAnnotations;

namespace VanzTube.Models
{   
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int VideoCategoryId { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        public Nullable<bool> IsHot { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsForMember { get; set; }
    
        public virtual VideoCategory VideoCategory { get; set; }
    }
}
