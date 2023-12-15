using LibraryModels;
using LibraryRespositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCategory(Category category)
        {
            await _unitOfWork.GenericRepository<Category>().AddAsync(category);
            _unitOfWork.Save();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(filter: x => x.CategoryID == id);
            _unitOfWork.GenericRepository<Category>().Delete(category);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.GenericRepository<Category>().GetAll();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _unitOfWork.GenericRepository<Category>().GetByIdAsync(filter: x => x.CategoryID == id); ;
        }

        public async Task UpdateCategory(Category category)
        {
            var CategoryFromDb = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(filter: x => x.CategoryID == category.CategoryID);
            if (CategoryFromDb != null)
            {
                CategoryFromDb.CategoryName = category.CategoryName;
                _unitOfWork.GenericRepository<Category>().Update(CategoryFromDb);
                _unitOfWork.Save();
            }

        }
    }
}
