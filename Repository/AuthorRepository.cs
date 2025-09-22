using EF_core_empty_controler__Day_3_.Interface;
using EF_core_empty_controler__Day_3_.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_core_empty_controler__Day_3_.Repository
{
    
    public class AuthorRepository : IBookAuthor<Author>
    {
        private readonly bookauthorContext _context;

        public AuthorRepository(bookauthorContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAll() 
        {
            IEnumerable<Author> authorList = await _context.Authors.ToListAsync();
            return authorList;
        }


        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors
                .FindAsync(id);
        }


        public async Task CreateAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
