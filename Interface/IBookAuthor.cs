
using EF_core_empty_controler__Day_3_.Models;

namespace EF_core_empty_controler__Day_3_.Interface

{
    public interface IBookAuthor<T> where T : class   //generic interface
    {

        //Author
        //Index GetAll
        Task<IEnumerable<T>> GetAll();

        //Details
        Task<Author> GetByIdAsync(int id);

        //create
        Task CreateAsync(Author author);

        //update
        Task<Author> UpdateAsync(Author author);

        //delete
        Task DeleteAsync(int id);

        //Book
        //Task<IEnumerable<T>> GetAlls();

        //Task<IEnumerable<Book>> GetAllAsync();
        //Task<Book> GetByIdAsyncc(int id);
        //Task CreateAsync(Book book);
        //Task<Book> UpdateAsync(Book book);
        //Task DeleteAsyncc(int id);
    }
}
