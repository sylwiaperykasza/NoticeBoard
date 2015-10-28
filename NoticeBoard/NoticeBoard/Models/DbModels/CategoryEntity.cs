using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.DbModels
{
    [Table("Category")]
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            Notices = new List<NoticeEntity>();
            CategoryItem = new List<CategoryEntity>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }

        public virtual ICollection<NoticeEntity> Notices { get; set; }
        public virtual CategoryEntity ParentCategory { get; set; }
        public virtual ICollection<CategoryEntity> CategoryItem { get; set; }
    }
}