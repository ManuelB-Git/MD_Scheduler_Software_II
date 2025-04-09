using MD_Scheduler_Software_II.Data;
using System.Windows;

namespace MD_Scheduler_Software_II
{

    public partial class App : Application
    {
        public static MDSchedulerDatabase? Database { get; private set; }
        public static UserRepository? URDatabase { get; private set; }
        public static CustomerRepository? CRDatabase { get; private set; }
        public static AppointmentRepository? ARDatabase { get; private set; }

        public App()
        {
            InitializeComponent();
            OnStartup();  
        }

        private static void OnStartup()
        {
            string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mdscheduler.db");
            Database = new MDSchedulerDatabase(dbPath);
            Database.InitAsync().Wait();

            URDatabase = new UserRepository(Database.Connection);
            CRDatabase = new CustomerRepository(Database.Connection);
            ARDatabase = new AppointmentRepository(Database.Connection);
        }
    }
}
