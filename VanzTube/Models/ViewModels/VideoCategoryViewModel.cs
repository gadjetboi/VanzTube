
using System.Collections.Generic;

namespace VanzTube.Models.ViewModels
{
    public class VideoCategoryViewModel
    {
        public int VideoCategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<VideoViewModel> VideoViewModels { get; set; }
    }
}