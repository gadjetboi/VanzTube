using System.Web.Mvc;
using VanzTube.Models.ViewModels;
using VanzTube.DataRepository;
using VanzTube.Interfaces;
using VanzTube_v3.Infrastructure;
using VanzTube_v3.Controllers;
using System.Configuration;

namespace VanzTube.Controllers
{
    public class PageController : BasePageController
    {
        IPageRepository _pageRepository;
        IVideoRepository _videoRepository;

        public PageController()
        {
            _pageRepository = new PageRepository();
            _videoRepository = new VideoRepository();
        }

        [LogFilter]
        [ErrorFilter]
        [OutputCache(CacheProfile = "CacheProfileOneHour", VaryByParam = "page")]
        public ActionResult Index(int? page = null)
        {
            //throw new NullReferenceException();

            ViewBag.IsSuccess = false; 
            
            ViewBag.IsDisplayContent = false;

            page = page ?? 1;

            if (page == 2)
                ViewBag.IsDisplayContent = true;

                #region Bundle View Model
            var bundleViewModel = new BundleViewModel()
            {
                PageViewModel = _pageRepository.GetPage(page),
                VideoCategoryViewModels = _videoRepository.GetVideoCategories(),
                FeaturedViewModels = _videoRepository.GetFeaturedVideos(),
                WhatsHotViewModels = _videoRepository.GetHotVideos(),
                LatestUpdatedViewModels = _videoRepository.GetLatestUpdatedVideos()
            };
            #endregion

            return View(bundleViewModel);
            
        }

        [ChildActionOnly]
        [LogFilter]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Navigation()
        {
            var menuViewModel = new BundleViewModel()
            {
                PageViewModels = _pageRepository.GetPages(),
                VideoCategoryViewModels = _videoRepository.GetVideoCategories()
            };

            return PartialView("Partials/_Navigation", menuViewModel);
        }

        [OutputCache(CacheProfile = "CacheProfileOneHour", VaryByParam = "id")]
        public ActionResult Video(int id)
        {
            var viewVideoModel = _videoRepository.GetVideo(id);

            if (!Request.IsAuthenticated && viewVideoModel.IsForMember)
            {
                return RedirectPermanent("~/Account/Login/?returnUrl=" + Request.Url.PathAndQuery);
            }
            else
            {
                return View(viewVideoModel);
            }
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult HotVideo()
        {
            var hotVideoModels = _videoRepository.GetHotVideos();

            return PartialView("~/Views/Shared/Partials/_HotVideo.cshtml", hotVideoModels);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult MembersVideo()
        {
            var membersVideo = _videoRepository.GetVideoForMembers();

            return PartialView("~/Views/Shared/Partials/_MembersVideo.cshtml", membersVideo);
        }

        [AllowAnonymous]
        [OutputCache(CacheProfile = "CacheProfileOneHour", VaryByParam = "none")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.IsSuccess = false;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [OutputCache(CacheProfile = "CacheProfileOneHour", VaryByParam = "none")]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Process contact form here...
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsSuccess = false;
            }

            return View(model);
        }
    }
}
