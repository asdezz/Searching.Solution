using Searching.UI.WinClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient
{
   partial class MainPage
    {
        CategoriesViewModel _categories = new CategoriesViewModel();
        AnnouncingViewModel _ann = new AnnouncingViewModel();
        FilterViewModel _filter = new FilterViewModel();
        RetCategoriesViewModel _returnCategories = new RetCategoriesViewModel();
    }
}
