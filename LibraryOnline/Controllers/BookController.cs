using AutoMapper;
using LibraryModels;
using LibraryServices;
using LibraryWeb.Models.BookViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace LibraryWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _bookservice;
        private IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public BookController(IBookServices bookService,IMapper mapper, ICategoryService categoryService)
        {
            _bookservice = bookService;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookservice.GetAllBooks();
            var bookViewModel = _mapper.Map<List<BookViewModel>>(books);
            return Json(new {data = bookViewModel});
        }
        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid) 
            {
                var book = _mapper.Map<Book>(bookViewModel);
                await _bookservice.AddBook(book);
                return Json(new { success = true, message = "add new book successful" });
            }
            return Json(new { success = false, message = "error wile creating" });
        }
    }
        
    
}
