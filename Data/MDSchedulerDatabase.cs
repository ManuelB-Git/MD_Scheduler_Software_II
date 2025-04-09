using SQLite;

namespace MD_Scheduler_Software_II.Data
{
    public class MDSchedulerDatabase(string dbPath)
    {
        private readonly SQLiteAsyncConnection _database = new(dbPath);


        public async Task InitAsync()
        {
            await _database.CreateTableAsync<Models.Appointment>();
            await _database.CreateTableAsync<Models.Customer>();
            await _database.CreateTableAsync<Models.User>();
        }

        public SQLiteAsyncConnection Connection => _database;


    }
}
