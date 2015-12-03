using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.RepositoryModels
{
    public class NoticeRepo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExprireDate { get; set; }
        public int CategoryId { get; set; }
        public int NoticePlaceId { get; set; }
        public string CategoryName { get; set; }
    }
}