using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MD_Scheduler_Software_II.Views;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace MD_Scheduler_Software_II.ViewModels
{
    public partial class NewUserViewModel : ObservableValidator
    {
      

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "First Name is required.")]
        private string firstName = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Last Name is required.")]
        private string lastName = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Company ID is required.")]
        private string companyId = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Username is required.")]
        private string username = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        private string password = string.Empty;

        [ObservableProperty]
        private string confirmPassword = string.Empty;


        [ObservableProperty]
        string passwordMatch = string.Empty;
       
        private bool ValidatePasswordMatch()
        {
            if (Password != ConfirmPassword)
            {
                PasswordMatch = "Passwords dont match.";
                return false;
            }
            else if (string.IsNullOrEmpty(ConfirmPassword))
            {
                PasswordMatch = "Please confirm your password.";
                return false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                PasswordMatch = "Please enter a password.";
                return false;
            }
            else if(Password.Length < 6)
            {
                PasswordMatch = "Password must be at least 6 characters.";
                return false;
            }
            else
            {
                PasswordMatch = string.Empty;
                return true;
            }

        }


        [RelayCommand]
        private void SaveUser()
        {
            ValidateAllProperties();

            if (!ValidatePasswordMatch() || !CanSubmit)
            {
                return;
            }

            if (App.URDatabase == null)
            {
                throw new ArgumentNullException(nameof(App.URDatabase), "Database is null");
            }

            Models.User newUser = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserCompanyId = CompanyId,
                UserName = Username,
                UserPassword = Password
            };
            _ = App.URDatabase.AddUserAsync(newUser);
            MessageBox.Show("User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            CancelWindow(Application.Current.Windows.OfType<NewUserView>().FirstOrDefault());
        }

        [RelayCommand]
        private static void CancelWindow(Window? window)
        {
            window?.Close();
        }
      

        public bool CanSubmit => !HasErrors;
    }
}
