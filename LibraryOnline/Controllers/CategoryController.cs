using AutoMapper;
using LibraryModels;
using LibraryServices;
using LibraryWeb.Models.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private IMapper _mapper;

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            var categories = await _categoryService.GetAllCategories();
            var categoryViewModel = _mapper.Map<List<CategoryViewModel>>(categories);
            return Json(new { data = categoryViewModel });
        }
        [HttpPost]
        public IActionResult Update (CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                _categoryService.UpdateCategory(category);
                return Json(new { success = true, message = "update successful" });
            }
            return Json(new { success = false, message = "error while updating" });
        }
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategory(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return Json(categoryViewModel);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategory(id);
            if(category == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            await _categoryService.DeleteCategory(id);
            return Json(new { success = true, message = "delete successful" });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
