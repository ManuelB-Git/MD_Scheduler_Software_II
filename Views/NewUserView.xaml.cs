using MD_Scheduler_Software_II.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace MD_Scheduler_Software_II.Views
{
 
    public partial class NewUserView : Window
    {
        public NewUserView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is NewUserViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;

            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is NewUserViewModel vm)
            {
                vm.ConfirmPassword = ((PasswordBox)sender).Password;
            }
        }

        private void PasswordBox_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }
    }
}
