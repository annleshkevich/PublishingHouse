using Microsoft.EntityFrameworkCore;
using Publishing_House.Model;
using Publishing_House.Model.DatabaseModels;
using Publishing_House.Services.Contracts;

namespace Publishing_House.Services.Implementations
{
    public class BookService:IBookService
    {
        private readonly PublishingHouseContext _db;
        public BookService(PublishingHouseContext context) =>
            _db = context;
        public bool Create(Book book)
        {
            _db.Books.Add(book);
            return Save();
        }
        public bool Delete(int id)
        {
            var book = _db.Books.FirstOrDefault(c => c.Id == id);
            if (book == null)
                return false;
            _db.Books.Remove(book);
            return Save();
        }
        public ICollection<Book> GetBooks() =>
            _db.Books.AsNoTracking().ToList();

        public Book Get(int id) =>
            _db.Books.AsNoTracking().FirstOrDefault(c => c.Id == id);
        public bool Update(Book book)
        {
            _db.Update(book);
            return Save();
        }
        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
