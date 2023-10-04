using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.EF
{
    public class UserService : IUserService
    {
        public readonly ApplicationDbContext dbContext;
        public UserService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<User> GetUser()
        {
            var user = dbContext.Users.OrderByDescending(x => x.Orders.Count).FirstOrDefault();

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = dbContext.Users.Where(x => x.Status == Enums.UserStatus.Inactive);
            return users.ToList();
        }
    }
}
