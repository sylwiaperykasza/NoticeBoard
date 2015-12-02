using NoticeBoard.Models.DbModels;
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
    public class UserNoticesController : Controller
    {
        //
        // GET: /UserNotices/

        public ActionResult Index()
        {
            var noticeRepo = new NoticeRepository();
            var noticesList = new List<NoticeRepo>();

            noticesList = noticeRepo.GetNoticesByUserId();

            return View(noticesList);
        }
        public ActionResult AddNotice()
        {
            var categoryRepo = new CategoryRepository();
            var allCategory = categoryRepo.GetAllCategory();
            var noticePlaceRepo = new NoticePlaceRepository();
            var allNoticePlace = noticePlaceRepo.GetAllNoticePlace();

            var result = new NewNoticeViewModel();

            var categoryListTemporary = new List<SelectListItem>();
            foreach (var category in allCategory)
            {
                categoryListTemporary.AddRange(category.SubCategory.Select(x => new SelectListItem
                {
                    Text = string.Format("{0}, {1}", category.Name, x.Name),
                    Value = x.Id.ToString()
                }));
            }
            result.CategoryList = categoryListTemporary;

            result.NoticePlaceList = allNoticePlace.Select(x => new SelectListItem
            {
                Text = string.Format("{0}, {1}", x.Province, x.City),
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text);
            return View(result);
        }
        public ActionResult AddNoticeToDatabase(NewNoticeViewModel model)
        {
            try
            {
                var newNoticeToAdd = new NoticeEntity();
                newNoticeToAdd.Amount = decimal.Parse(model.Amount);
                newNoticeToAdd.CategoryId = int.Parse(model.SelectedCategoryId);
                newNoticeToAdd.CreateDate = DateTime.Now;
                newNoticeToAdd.Description = model.Description;
                newNoticeToAdd.ExprireDate = DateTime.Now.AddDays(int.Parse(model.ExpireTo));
                newNoticeToAdd.NoticePlaceId = int.Parse(model.NoticePlaceId);
                newNoticeToAdd.Title = model.Title;
                newNoticeToAdd.UserProfileId = WebMatrix.WebData.WebSecurity.CurrentUserId;

                var noticeRepo = new NoticeRepository();
                noticeRepo.AddNewNotice(newNoticeToAdd);
                ViewBag.Message = "Dodano ogłoszenie.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Ups coś poszło nie tak.";
                ViewBag.ExtendMessage = ex.Message;

            }
            return View();
        }

    }
}
