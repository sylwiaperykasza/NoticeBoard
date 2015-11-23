using NoticeBoard.Models.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.ViewModels
{
    public class NoticeDetailsViewModel
    {
        public List<CategoryRepo> CategoriesList { get; set; }
        public NoticeRepo Notice { get; set; }
        public Nullable<int> SelectedCategoryId { get; set; }
    }
}