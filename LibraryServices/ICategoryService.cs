using LibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices
{
    public interface ICategoryService
    {
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
