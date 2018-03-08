using System.Web.Mvc;
using VanzTube.DataRepository;
using VanzTube.Interfaces;

namespace VanzTube.Controllers
{
    public class CategoryController : Controller
    {
        IVideoRepository _videoRepository;

        public CategoryController()
        { 
            _videoRepository = new VideoRepository();
        }

        public ActionResult Index(int categoryId)
        {  
            var bundleViewModel =  _videoRepository.GetVideoBundleByCategoryId(categoryId);
            return View(bundleViewModel);
        }

        public ActionResult All()
        {
            var videoCategories = _videoRepository.GetViewCategoriesWithContent();

            return View(videoCategories);
        }
    }
}