using Publishing_House.Model.DatabaseModels;

namespace Publishing_House.Services.Contracts
{
    public interface IBookService
    {
        ICollection<Book> GetBooks();
        Book Get(int id);
        bool Create(Book book);
        bool Update(Book book);
        bool Delete(int id);
    }
}
