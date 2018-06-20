using System.Web.Mvc;
using VanzTube.DataRepository;
using VanzTube.Interfaces;

namespace VanzTube.Controllers
{
    public class SearchController : Controller
    {
        IVideoRepository _videoRepository;

        public SearchController()
        {
            _videoRepository = new VideoRepository();
        }

        [OutputCache(CacheProfile = "CacheProfileOneHour", VaryByParam = "search")]
        public ActionResult Index(string search)
        {
            var searchResults = _videoRepository.Search(search);

            return View(searchResults);
        }

        public ActionResult LatestUpdatedVideo()
        {
            var latestUpdatedVideoModels = _videoRepository.GetLatestUpdatedVideos();

            return PartialView("~/Views/Shared/Partials/_LatestUpdated.cshtml", latestUpdatedVideoModels);
        }

        public ActionResult Footer()
        {
            var videoCategories = _videoRepository.GetVideoCategories();

            return PartialView("~/Views/Shared/Partials/_Footer.cshtml", videoCategories);
           
        }
    }
}