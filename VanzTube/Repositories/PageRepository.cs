using System.Collections.Generic;
using System.Linq;
using VanzTube.Models.ViewModels;
using VanzTube.Interfaces;
using VanzTube.Models;

namespace VanzTube.DataRepository
{
    public class PageRepository : IPageRepository
    {
        private VanzTubeContext _dbContext;

        public PageRepository()
        {
            _dbContext = new VanzTubeContext();
        }

        public PageViewModel GetPage(int? page)
        { 
            var pageViewModel = _dbContext.Pages.Select(p => new PageViewModel
            {
                PageId = p.PageId,
                Title = p.Title,
                Content = p.Content,
                Name = p.Name
            }).Where(p => p.PageId == page).FirstOrDefault();

            return pageViewModel;
        }
        
        public List<PageViewModel> GetPages()
        {   
            var pageViewModels = _dbContext.Pages.Select(p => new PageViewModel
            {
                PageId = p.PageId,
                Title = p.Title,
                Content = p.Content,
                Name = p.Name
            }).ToList();

            return pageViewModels;
        }
    }
}