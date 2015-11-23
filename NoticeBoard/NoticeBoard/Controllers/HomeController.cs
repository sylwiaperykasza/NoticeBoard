using NoticeBoard.Models.RepositoryModels;
using NoticeBoard.Models.ViewModels;
using NoticeBoard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Nullable<int> categoryId = null)
        {
            var categoryRepo = new CategoryRepository();
            var allCategory = categoryRepo.GetAllCategory();

            var noticeRepo = new NoticeRepository();
            var noticesList = new List<NoticeRepo>();

            if (categoryId == null)
                noticesList = noticeRepo.GetAllNotices();
            else 
                noticesList = noticeRepo.GetNoticesByCategoryId(categoryId.Value);

            var result = new HomeViewModel();
            result.CategoriesList = allCategory;
            result.NoticesList = noticesList;
            result.SelectedCategoryId = categoryId;

            return View(result);
        }

        public ActionResult ShowNoticeDetails(int noticeId)
        {
            var categoryRepo = new CategoryRepository();
            var allCategory = categoryRepo.GetAllCategory();

            var noticeRepo = new NoticeRepository();
            var currentNotice = noticeRepo.GetNoticeById(noticeId);

            var result = new NoticeDetailsViewModel();
            result.CategoriesList = allCategory;
            result.Notice = currentNotice;

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
