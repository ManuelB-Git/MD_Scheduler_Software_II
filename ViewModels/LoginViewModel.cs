using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MD_Scheduler_Software_II.Views;
using System.Windows;


namespace MD_Scheduler_Software_II.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _username = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        [ObservableProperty]
        private string loginErrorMessage = string.Empty;


        [RelayCommand]
        private static void NavigateToNewUser()
        {
            NewUserView newUserView = new();
            newUserView.ShowDialog();
        }

        
        [RelayCommand]
        private async Task NavigateToLogin()
        {
            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Username))
            {
                LoginErrorMessage = "Please enter both username and password.";
                return;
            }
            if (App.URDatabase == null)
            {
                LoginErrorMessage = "Database is not initialized. Please contact support.";
                return;
            }

            List<Models.User> users = [.. await App.URDatabase.GetAllUsersAsync()];
            

            if (users.Any(user => user.UserName == Username && user.UserPassword == Password))
            {
                var loginView = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();

                LoginErrorMessage = string.Empty;
                MainView mainView = new();
                Application.Current.MainWindow = mainView;

                loginView?.Close();
                mainView.Show();

            }
            else
            {
                LoginErrorMessage = "Credentials incorrect. Please try again.";
                return;
            }
        }
    }
}
