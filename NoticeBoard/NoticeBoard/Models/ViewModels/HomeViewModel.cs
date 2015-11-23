using NoticeBoard.Models.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.ViewModels
{
    public class HomeViewModel
    {
        public Nullable<int> SelectedCategoryId { get; set; }
        public List<CategoryRepo> CategoriesList { get; set; }
        public List<NoticeRepo> NoticesList { get; set; }


    }
}