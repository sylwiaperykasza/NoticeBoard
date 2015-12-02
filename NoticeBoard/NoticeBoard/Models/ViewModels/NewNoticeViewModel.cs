using NoticeBoard.Models.RepositoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeBoard.Models.ViewModels
{
    public class NewNoticeViewModel
    {
        public NewNoticeViewModel()
        {
            CategoryList = new List<SelectListItem>();
        }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Amount { get; set; }
        public string ExpireTo { get; set; }
        public string SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public string NoticePlaceId { get; set; }
        public IEnumerable<SelectListItem> NoticePlaceList { get; set; }
    }
}