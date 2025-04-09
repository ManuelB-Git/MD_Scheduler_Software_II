using SQLite;

namespace MD_Scheduler_Software_II.Data
{
    public class CustomerRepository(SQLiteAsyncConnection database)
    {

        private readonly SQLiteAsyncConnection _database = database;


        public async Task<List<Models.Customer>> GetAllCustomersAsync()
        {
            return await _database.Table<Models.Customer>().ToListAsync();
        }
        public async Task<Models.Customer?> GetCustomerByIdAsync(int customerId)
        {
            return await _database.Table<Models.Customer>().FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
        public async Task<int> AddCustomerAsync(Models.Customer customer)
        {
            return await _database.InsertAsync(customer);
        }
        public async Task<int> UpdateCustomerAsync(Models.Customer customer)
        {
            return await _database.UpdateAsync(customer);
        }
        public async Task<int> DeleteCustomerAsync(int customerId)
        {
            return await _database.DeleteAsync(new Models.Customer { CustomerId = customerId });
        }
    }
   
}
