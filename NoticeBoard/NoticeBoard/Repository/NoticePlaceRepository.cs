using NoticeBoard.Models;
using NoticeBoard.Models.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeBoard.Repository
{
    public class NoticePlaceRepository
    {
        public List<NoticePlaceRepo> GetAllNoticePlace()
        {
            using (var contex = new UsersContext())
            {
                var allNoticePlace = contex.NoticePlaces.ToList();
                var result = allNoticePlace.Select(x => new NoticePlaceRepo
                {
                    Id = x.Id,
                    Province = x.Province,
                    City = x.City
                }).ToList();

                return result;
            }
        }
    }
}