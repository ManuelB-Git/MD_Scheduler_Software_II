using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MD_Scheduler_Software_II.Views;

namespace MD_Scheduler_Software_II.ViewModels
{
    public partial class MainViewModel:ObservableObject
    {

        [ObservableProperty]
        private object currentView;

        [ObservableProperty]
        private string title;


        public MainViewModel()
        {
            // Set default view
            Title = "Home";
            CurrentView = new HomeView();
        }

        [RelayCommand]
        private void ShowHomeView()
        {
            Title = "Home";
            CurrentView = new HomeView();
        }

        [RelayCommand]
        private void ShowCustomerView()
        {
            Title = "Customers";
            CurrentView = new CustomersView();
        }

        [RelayCommand]
        private void ShowAppointmentView()
        {
            Title = "Appointments";
            CurrentView = new AppointmentsView();
        }

        [RelayCommand]
        private void ShowReportView()
        {
            Title = "Reports";
            CurrentView = new ReportsView();
        }


    }
}
