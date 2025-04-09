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
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            if (App.URDatabase == null)
            {
                MessageBox.Show("Database is not initialized. Please contact support.");
                return;
            }

            List<Models.User> users = [.. await App.URDatabase.GetAllUsersAsync()];
            if (users.Count == 0)
            {
                MessageBox.Show("No users found in the database.");
                return;
            }

            if (users.Any(user => user.UserName == Username && user.UserPassword == Password))
            {
                MainView mainView = new();
                mainView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credentials wrong. Please try again.");
            }
        }
    }
}
