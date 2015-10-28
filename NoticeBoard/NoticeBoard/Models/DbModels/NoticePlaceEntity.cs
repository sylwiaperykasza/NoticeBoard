using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.DbModels
{
    [Table("NoticePlace")]
    public class NoticePlaceEntity
    {
        public NoticePlaceEntity()
        {
            Notices = new List<NoticeEntity>();
        }
        [Key]
        public int Id { get; set; }
        public string Province { get; set; }
        public string City { get; set; }

        public virtual ICollection<NoticeEntity> Notices { get; set; }
    }
}