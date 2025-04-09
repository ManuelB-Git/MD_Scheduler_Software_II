using SQLite; 

namespace MD_Scheduler_Software_II.Data
{
    public class UserRepository(SQLiteAsyncConnection database)
    {
        private readonly SQLiteAsyncConnection _database = database;

        public async Task<List<Models.User>> GetAllUsersAsync()
        {
            return await _database.Table<Models.User>().ToListAsync();
        }
        public async Task<Models.User?> GetUserByIdAsync(int userId)
        {
            return await _database.Table<Models.User>().FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task<int> AddUserAsync(Models.User user)
        {
            return await _database.InsertAsync(user);
        }
        public async Task<int> UpdateUserAsync(Models.User user)
        {
            return await _database.UpdateAsync(user);
        }
        public async Task<int> DeleteUserAsync(int userId)
        {
            return await _database.DeleteAsync(new Models.User { UserId = userId });
        }
    }
}
