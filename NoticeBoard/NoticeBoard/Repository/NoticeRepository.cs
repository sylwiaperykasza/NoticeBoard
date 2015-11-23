using NoticeBoard.Models;
using NoticeBoard.Models.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace NoticeBoard.Repository
{
    public class NoticeRepository
    {
        public List<NoticeRepo> GetAllNotices()
        {
            using (var context = new UsersContext())
            {
                var allNotices = context.Notices.ToList();
                var result = allNotices.Select(x => new NoticeRepo()
                {
                    Amount = x.Amount,
                    CreateDate = x.CreateDate,
                    Description = x.Description.Substring(0, 250),
                    ExprireDate = x.ExprireDate,
                    Id = x.Id,
                    Title = x.Title

                }).ToList();

                return result;
            }
        }

        public List<NoticeRepo> GetNoticesByUserId()
        {
            using (var context = new UsersContext())
            {

                var allNotices = context.Notices.Where(x => x.UserProfileId == WebSecurity.CurrentUserId).ToList();
                var result = allNotices.Select(x => new NoticeRepo()
                {
                    Amount = x.Amount,
                    CreateDate = x.CreateDate,
                    Description = x.Description,
                    ExprireDate = x.ExprireDate,
                    Id = x.Id,
                    Title = x.Title

                }).ToList();

                return result;
            }
        }

        public List<NoticeRepo> GetNoticesByCategoryId(int categoryId)
        {
            using (var context = new UsersContext())
            {
                var allNotices = context.Notices.Where(x => x.CategoryId == categoryId).ToList();
                var result = allNotices.Select(x => new NoticeRepo()
                {
                    Amount = x.Amount,
                    CreateDate = x.CreateDate,
                    Description = x.Description.Substring(0,250),
                    ExprireDate = x.ExprireDate,
                    Id = x.Id,
                    Title = x.Title
                }).ToList();

                return result;
            }
        }

        public NoticeRepo GetNoticeById(int id)
        {
            using (var context = new UsersContext())
            {
                var notice = context.Notices.FirstOrDefault(x => x.Id == id);
                var result = new NoticeRepo()
                {
                    Amount = notice.Amount,
                    CreateDate = notice.CreateDate,
                    Description = notice.Description,
                    ExprireDate = notice.ExprireDate,
                    Id = notice.Id,
                    Title = notice.Title,
                    Place = notice.NoticePlace.City
                };

                return result;
            }
        }
    }
}