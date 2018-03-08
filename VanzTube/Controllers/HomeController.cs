using System.Web.Mvc;
using VanzTube.DataRepository;
using VanzTube.Interfaces;

namespace VanzTube.Controllers
{
    public class HomeController : Controller
    {
        IPageRepository _pageRepository;
        IVideoRepository _videoRepository;

        public HomeController()
        {
            _pageRepository = new PageRepository();
            _videoRepository = new VideoRepository();
        }
        public ActionResult Index()
        {
            _pageRepository.GetPage(1);
            _videoRepository.GetVideo(1);
            _videoRepository.GetVideoCategories();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}