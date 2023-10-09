using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Abstracts;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class BookRepository : GenericRepository<ApplicationDbContext, Book, int>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext) {}


        public async Task<List<Book>> GetActiveBooks()
        {
            return await _dbContext.Books.Where(c => c.IsActive == true).ToListAsync();
        }

        public async Task<List<Book>> GetDeActiveBooks()
        {
            return await _dbContext.Books.Where(c => c.IsActive != true ).ToListAsync();
        }

        public async Task<List<Book>> GetBooksInsideCategory(string category)
        {
            return await _dbContext.Books.Where(c => c.Category == category).ToListAsync();
        }
    }
}
