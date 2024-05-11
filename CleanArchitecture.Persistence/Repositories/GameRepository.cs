using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Abstracts;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Persistence.Repositories
{
    public class GameRepository : GenericRepository<ApplicationDbContext, Game, int>, IGameRepository
    {
        public GameRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    }
}
