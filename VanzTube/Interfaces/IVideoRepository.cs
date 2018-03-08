using System.Collections.Generic;
using VanzTube.Models.ViewModels;

namespace VanzTube.Interfaces
{
    public interface IVideoRepository
    {
        List<VideoViewModel> Search(string look);
        List<VideoCategoryViewModel> GetVideoCategories();
        VideoViewModel GetVideo(int id);
        List<VideoViewModel> GetFeaturedVideos();
        List<VideoViewModel> GetHotVideos();
        List<VideoViewModel> GetLatestUpdatedVideos();
        List<VideoViewModel> GetVideoForMembers();
        BundleViewModel GetVideoBundleByCategoryId(int categoryId);
        List<VideoCategoryViewModel> GetViewCategoriesWithContent();
    }
}