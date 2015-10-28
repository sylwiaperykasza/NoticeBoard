using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.DbModels
{
    [Table("Notice")]
    public class NoticeEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int NoticePlaceId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExprireDate { get; set; }

        public virtual UserProfileEntity UserProfile { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public virtual NoticePlaceEntity NoticePlace { get; set; }
    }
}