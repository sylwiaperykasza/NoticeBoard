using NoticeBoard.Models.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.ViewModels
{
    public class NewNoticeViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public int ExpireTo { get; set; }
        public CategoryRepo Category { get; set; }
        public List<CategoryRepo> CategoryList { get; set; }
        //public string NoticePlace { get; set; }
        //public List<> NoticePlaceList { get; set; }
    }
}