using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VanzTube.Models
{   
    public class VideoCategory
    {
        public VideoCategory()
        {
            this.Videos = new HashSet<Video>();
        }

        [Key]
        public int VideoCategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    
        public virtual ICollection<Video> Videos { get; set; }
    }
}
