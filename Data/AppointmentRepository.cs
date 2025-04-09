using SQLite;


namespace MD_Scheduler_Software_II.Data
{
    public class AppointmentRepository(SQLiteAsyncConnection database)
    {
        private readonly SQLiteAsyncConnection _database = database;
        public async Task<List<Models.Appointment>> GetAllAppointmentsAsync()
        {
            return await _database.Table<Models.Appointment>().ToListAsync();
        }
        public async Task<Models.Appointment?> GetAppointmentByIdAsync(int appointmentId)
        {
            return await _database.Table<Models.Appointment>().FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);
        }
        public async Task<int> AddAppointmentAsync(Models.Appointment appointment)
        {
            return await _database.InsertAsync(appointment);
        }
        public async Task<int> UpdateAppointmentAsync(Models.Appointment appointment)
        {
            return await _database.UpdateAsync(appointment);
        }
        public async Task<int> DeleteAppointmentAsync(int appointmentId)
        {
            return await _database.DeleteAsync(new Models.Appointment { AppointmentId = appointmentId });
        }
    }
   
}
