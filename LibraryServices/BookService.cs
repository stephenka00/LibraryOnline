using LibraryModels;
using LibraryRespositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class BookService : IBookServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddBook(Book book)
        {
            await _unitOfWork.GenericRepository<Book>().AddAsync(book);
            _unitOfWork.Save();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _unitOfWork.GenericRepository<Book>().GetByIdAsync(filter: x => x.BookID == id);
            _unitOfWork.GenericRepository<Book>().Delete(book);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _unitOfWork.GenericRepository<Book>().GetAll();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _unitOfWork.GenericRepository<Book>().GetByIdAsync(filter: x => x.BookID == id); ;
        }

        public async Task UpdateBook(Book book)
        {
            var BookFromDb = await _unitOfWork.GenericRepository<Book>().GetByIdAsync(filter: x => x.BookID == book.BookID);
            if (BookFromDb != null)
            {
                BookFromDb.PublicationDate = DateTime.UtcNow;
                BookFromDb.Authors = book.Authors;
                BookFromDb.Categories = book.Categories;
                BookFromDb.Genres = book.Genres;
                BookFromDb.Title = book.Title;
                BookFromDb.Length = book.Length;
            }

        }
    }
}
