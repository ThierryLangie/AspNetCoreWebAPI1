using AspNetCoreWebAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPI1.Services
{
	public class RepositoryService
	{
		private readonly AppDbContext _dbContext;

		public RepositoryService(AppDbContext dbContext) => _dbContext = dbContext;
		
		public async Task<List<User>> GetAllUsersAsync() => await _dbContext.Users.ToListAsync();
	}
}
