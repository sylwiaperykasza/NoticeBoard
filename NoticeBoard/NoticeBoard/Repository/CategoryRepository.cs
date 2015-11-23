using NoticeBoard.Models;
using NoticeBoard.Models.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeBoard.Repository
{
    public class CategoryRepository
    {
        public List<CategoryRepo> GetAllCategory()
        {
            using (var contex = new UsersContext())
            {
                var allCategory = contex.Categories.Where(x => x.ParentId == null).ToList();
                var result = allCategory.Select(x => new CategoryRepo
                {
                    Id = x.Id,
                    Name = x.Name,
                    SubCategory = x.CategoryItem.Select(y => new CategoryRepo
                    {
                        Id = y.Id,
                        Name = y.Name
                    }).ToList()
                }).ToList();

                return result;
            }
        }
    }
}