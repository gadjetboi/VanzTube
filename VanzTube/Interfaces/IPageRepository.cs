using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VanzTube.Models.ViewModels;

namespace VanzTube.Interfaces
{
    public interface IPageRepository
    {
        PageViewModel GetPage(int? page);
        List<PageViewModel> GetPages();
    }
}