using System;
using System.Collections.Generic;
using System.Linq;
using VanzTube.Models.ViewModels;
using VanzTube.Interfaces;
using VanzTube.Models;

namespace VanzTube.DataRepository
{
    public class VideoRepository : IVideoRepository
    {
        private VanzTubeContext _dbContext;

        public VideoRepository()
        {
            _dbContext = new VanzTubeContext();
        }

        public List<VideoViewModel> Search(string search)
        {
            var searchResults = _dbContext.Videos.Select(p => new VideoViewModel()
            {
                VideoId = p.VideoId,
                VideoCategoryId = p.VideoCategoryId,
                Title = p.Title,
                Description = p.Description,
                URL = p.URL,
                IsFeatured = p.IsFeatured ?? false,
                IsHot = p.IsHot ?? false,
                Image = p.Image,
                CreatedDate = p.CreatedDate,
                IsForMember = p.IsForMember ?? false
            }).Where(o => o.Title.ToLower().Contains(search.ToLower())).ToList();

            return searchResults;
        }

        public List<VideoCategoryViewModel> GetVideoCategories()
        {
            var videoCategories = _dbContext.VideoCategories.Select(p => new VideoCategoryViewModel()
            {
                VideoCategoryId = p.VideoCategoryId,
                Name = p.Name,
                Image = p.Image
            }).OrderBy(p => p.Name).ToList();

            return videoCategories;
        }

        public List<VideoCategoryViewModel> GetViewCategoriesWithContent() {
            var videoCategories = _dbContext.VideoCategories.Select(p => new VideoCategoryViewModel
            {
                VideoCategoryId = p.VideoCategoryId,
                Name = p.Name,
                Image = p.Image,
                VideoViewModels = p.Videos.Select(o => new VideoViewModel()
                {
                    VideoId = o.VideoId,
                    VideoCategoryId = o.VideoCategoryId,
                    Title = o.Title,
                    Description = o.Description,
                    URL = o.URL,
                    IsFeatured = o.IsFeatured ?? false,
                    IsHot = o.IsHot ?? false,
                    Image = o.Image,
                    CreatedDate = o.CreatedDate
                }).ToList()
            }).ToList();

            return videoCategories;
        }

        public VideoViewModel GetVideo(int id)
        {   
            var videoViewModel = _dbContext.Videos.Select(p => new VideoViewModel
            {
                VideoId = p.VideoId,
                VideoCategoryId = p.VideoCategoryId,
                Title = p.Title,
                Description = p.Description,
                URL = p.URL,
                IsFeatured = p.IsFeatured ?? false,
                IsHot = p.IsHot ?? false,
                Image = p.Image,
                CreatedDate = p.CreatedDate,
                IsForMember = p.IsForMember ?? false
            }).Where(p => p.VideoId == id).FirstOrDefault();

            return videoViewModel;
        }

        public List<VideoViewModel> GetFeaturedVideos()
        {
            var featuredVideos = _dbContext.Videos.Select(p => new VideoViewModel()
            {
                VideoId = p.VideoId,
                VideoCategoryId = p.VideoCategoryId,
                Title = p.Title,
                Description = p.Description,
                URL = p.URL,
                IsFeatured = p.IsFeatured ?? false,
                IsHot = p.IsHot ?? false,
                Image = p.Image,
                CreatedDate = p.CreatedDate,
                IsForMember = p.IsForMember ?? false
            }).Where(p => p.IsFeatured == true).ToList();

            return featuredVideos;
        }

        public List<VideoViewModel> GetHotVideos()
        {   
            var hotViewModels = _dbContext.Videos.Select(p => new VideoViewModel()
            {
                VideoId = p.VideoId,
                VideoCategoryId = p.VideoCategoryId,
                Title = p.Title,
                Description = p.Description,
                URL = p.URL,
                IsFeatured = p.IsFeatured ?? false,
                IsHot = p.IsHot ?? false,
                Image = p.Image,
                CreatedDate = p.CreatedDate,
                IsForMember = p.IsForMember ?? false
            }).Where(p => p.IsHot == true).ToList();

            return hotViewModels;
        }

        public List<VideoViewModel> GetLatestUpdatedVideos()
        {   
            var dateYesterday = DateTime.Today.AddDays(-1);
            var dateToday = DateTime.Today;

            var latestUpdatedVideoModels = _dbContext.Videos.Select(p => new VideoViewModel()
            {
                VideoId = p.VideoId,
                VideoCategoryId = p.VideoCategoryId,
                Title = p.Title,
                Description = p.Description,
                URL = p.URL,
                IsFeatured = p.IsFeatured ?? false,
                IsHot = p.IsHot ?? false,
                Image = p.Image,
                CreatedDate = p.CreatedDate,
                IsForMember = p.IsForMember ?? false
            }).Where(p => DateTime.Compare(p.CreatedDate ?? dateYesterday, dateToday) < 2).ToList();

            return latestUpdatedVideoModels;
        }

        public List<VideoViewModel> GetVideoForMembers()
        {  
            var membersVideos = _dbContext.Videos.Select(p => new VideoViewModel()
            {
                VideoId = p.VideoId,
                VideoCategoryId = p.VideoCategoryId,
                Title = p.Title,
                Description = p.Description,
                URL = p.URL,
                IsFeatured = p.IsFeatured ?? false,
                IsHot = p.IsHot ?? false,
                Image = p.Image,
                CreatedDate = p.CreatedDate,
                IsForMember = p.IsForMember ?? false
            }).Where(p => p.IsForMember == true).ToList();

            return membersVideos;
        }

        public BundleViewModel GetVideoBundleByCategoryId(int categoryId) {
            #region Video Category
            var videoCategoryViewModel = _dbContext.VideoCategories.Select(p => new VideoCategoryViewModel
            {
                VideoCategoryId = p.VideoCategoryId,
                Name = p.Name,
                Image = p.Image,
                VideoViewModels = p.Videos.Select(o => new VideoViewModel()
                {
                    VideoId = o.VideoId,
                    VideoCategoryId = o.VideoCategoryId,
                    Title = o.Title,
                    Description = o.Description,
                    URL = o.URL,
                    IsFeatured = o.IsFeatured ?? false,
                    IsHot = o.IsHot ?? false,
                    Image = o.Image,
                    CreatedDate = o.CreatedDate
                }).ToList()
            }).Where(p => p.VideoCategoryId == categoryId).FirstOrDefault();
            #endregion

            #region Video Categories
            var videoCategoryViewModels = _dbContext.VideoCategories.Select(p => new VideoCategoryViewModel
            {
                VideoCategoryId = p.VideoCategoryId,
                Name = p.Name,
                VideoViewModels = p.Videos.Select(o => new VideoViewModel()
                {
                    VideoId = o.VideoId,
                    VideoCategoryId = o.VideoCategoryId,
                    Title = o.Title,
                    Description = o.Description,
                    URL = o.URL,
                    IsFeatured = o.IsFeatured ?? false,
                    IsHot = o.IsHot ?? false,
                    Image = o.Image,
                    CreatedDate = o.CreatedDate
                }).ToList()
            }).ToList();
            #endregion

            #region Latest Updated Videos
            var dateYesterday = DateTime.Today.AddDays(-1);
            var dateToday = DateTime.Today;

            var latestUpdatedVideoModels = _dbContext.Videos.Select(o => new VideoViewModel()
            {
                VideoId = o.VideoId,
                VideoCategoryId = o.VideoCategoryId,
                Title = o.Title,
                Description = o.Description,
                URL = o.URL,
                IsFeatured = o.IsFeatured ?? false,
                IsHot = o.IsHot ?? false,
                Image = o.Image,
                CreatedDate = o.CreatedDate
            }).ToList();
            //.Where(p => DateTime.Compare(p.CreatedDate ?? dateYesterday, dateToday) < 2).ToList();
            #endregion

            BundleViewModel bundleViewModel = new BundleViewModel()
            {
                VideoCategoryViewModel = videoCategoryViewModel,
                VideoCategoryViewModels = videoCategoryViewModels,
                LatestUpdatedViewModels = latestUpdatedVideoModels
            };

            return bundleViewModel;
        }
        
    }
}