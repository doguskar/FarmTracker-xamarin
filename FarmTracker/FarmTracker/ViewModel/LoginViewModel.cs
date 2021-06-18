using FarmTracker.Data;
using FarmTracker.Model;
using MvvmHelpers;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FarmTracker.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        
        private string key;
        private string password;
        private bool isPassword = true;
        
        public ICommand SignInCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }

        private UserRepository userRepository;

        
        public LoginViewModel()
        {
            SignInCommand = new Command(SignIn, CanSignIn);
            RegisterCommand = new Command(Register);
            ShowPasswordCommand = new Command(ShowPassword);
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            userRepository = new UserRepository(System.IO.Path.Combine(path, "farmTracker"));            
        }


        public string Key
        {
            get => key;
            set
            {
                SetProperty(ref key, value);
                (SignInCommand as Command).ChangeCanExecute();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                (SignInCommand as Command).ChangeCanExecute();
            }
        }
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                SetProperty(ref isPassword, value);
            }
        }

        private bool CanSignIn()
        {
            return !String.IsNullOrWhiteSpace(key) && !String.IsNullOrWhiteSpace(password);
        }
        private void SignIn()
        {
            User user = userRepository.GetUserByEmailOrUsername(key);
            if(user != null && user.Password == password)
            {
                Preferences.Set("userId", user.Id.ToString());
                App.Current.MainPage = new MasterDetailPage1();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Invalid username or password", "OK");
            }
        }
        private void Register()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
        }
        private void ShowPassword()
        {
            IsPassword = !IsPassword;
        }
    }
}
