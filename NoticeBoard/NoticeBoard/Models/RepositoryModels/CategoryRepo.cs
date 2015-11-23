using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.RepositoryModels
{
    public class CategoryRepo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CategoryRepo> SubCategory { get; set; }

        public CategoryRepo()
        {
            this.SubCategory = new List<CategoryRepo>();
        }
    }
}