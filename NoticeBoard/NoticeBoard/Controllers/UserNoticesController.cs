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

        public ActionResult EditNotice(int noticeId){
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

            
            var noticeRepo = new NoticeRepository();
            var currentNotice = noticeRepo.GetNoticeById(noticeId);

            result.Title = currentNotice.Title;
            result.Amount = currentNotice.Amount.ToString();
            result.Description = currentNotice.Description;
            //result.ExpireTo = currentNotice.Title;
            result.SelectedCategoryId = currentNotice.CategoryId.ToString();
            result.NoticePlaceId = currentNotice.NoticePlaceId.ToString();
            result.Id = currentNotice.Id;

            return View(result);
        }

        public ActionResult UpdateNotice(NewNoticeViewModel model)
        {
            try
            {
                var noticeToUpdate = new NoticeEntity();
                noticeToUpdate.Amount = decimal.Parse(model.Amount);
                noticeToUpdate.CategoryId = int.Parse(model.SelectedCategoryId);
                noticeToUpdate.CreateDate = DateTime.Now;
                noticeToUpdate.Description = model.Description;
                //newNoticeToAdd.ExprireDate = DateTime.Now.AddDays(int.Parse(model.ExpireTo));
                noticeToUpdate.NoticePlaceId = int.Parse(model.NoticePlaceId);
                noticeToUpdate.Title = model.Title;
                noticeToUpdate.UserProfileId = WebMatrix.WebData.WebSecurity.CurrentUserId;
                noticeToUpdate.Id = model.Id;

                var noticeRepo = new NoticeRepository();
                noticeRepo.UpdateNotice(noticeToUpdate);
                ViewBag.Message = "Ogłoszenie zostało zedytowane.";
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
