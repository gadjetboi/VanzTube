
using System;
using VanzTube.Models;

namespace VanzTube.Models.ViewModels
{
    public class VideoViewModel
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int VideoCategoryId { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsHot { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsForMember { get; set; }

        public virtual VideoCategory VideoCategory { get; set; }
    }
}