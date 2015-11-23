using NoticeBoard.Models.ViewModels;
using NoticeBoard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeBoard.Controllers
{
    public class UserNoticesController : Controller
    {
        //
        // GET: /UserNotices/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNotice()
        {
            var categoryRepo = new CategoryRepository();
            var allCategory = categoryRepo.GetAllCategory();

            var result = new NewNoticeViewModel();
            result.CategoryList = allCategory;
            return View(result);
        }

    }
}
