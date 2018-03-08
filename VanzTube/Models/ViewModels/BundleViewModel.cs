using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanzTube.Models.ViewModels
{
    public class BundleViewModel
    {
        public PageViewModel PageViewModel { get; set; }
        public List<PageViewModel> PageViewModels { get; set; }
        public List<VideoCategoryViewModel> VideoCategoryViewModels { get; set; }
        public List<VideoViewModel> FeaturedViewModels { get; set; }
        public List<VideoViewModel> WhatsHotViewModels { get; set; }
        public List<VideoViewModel> LatestUpdatedViewModels { get; set; }
        public VideoCategoryViewModel VideoCategoryViewModel { get; set; }
    }
}