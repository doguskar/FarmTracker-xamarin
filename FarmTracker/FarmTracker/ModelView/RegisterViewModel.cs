using FarmTracker.Data;
using FarmTracker.Model;
using MvvmHelpers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FarmTracker.ModelView
{
    public class RegisterViewModel: BaseViewModel
    {
        private string username;
        private string email;
        private string password;
        private string phone;
        private string fullName;
        private bool isPassword = true;

        public ICommand SignUpCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }

        private UserRepository userRepository;

        public RegisterViewModel()
        {
            SignUpCommand = new Command(SignUp, CanSignUp);
            BackCommand = new Command(Back);
            ShowPasswordCommand = new Command(ShowPassword);
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            userRepository = new UserRepository(System.IO.Path.Combine(path, "farmTracker"));
        }


        public string Username 
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                SetProperty(ref phone, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                SetProperty(ref fullName, value);
                (SignUpCommand as Command).ChangeCanExecute();
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

        private bool CanSignUp()
        {
            return !String.IsNullOrWhiteSpace(username) 
                && !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(password)
                && !String.IsNullOrWhiteSpace(fullName);
        }
        private void SignUp()
        {
            if (userRepository.GetUserByEmailOrUsername(username) != null)
            {
                App.Current.MainPage.DisplayAlert("Alert", "Username has already been used.", "OK");
                return;
            }
            else if (userRepository.GetUserByEmailOrUsername(email) != null)
            {
                App.Current.MainPage.DisplayAlert("Alert", "Email has already been used.", "OK");
                return;
            }

            User newUser = new User();
            newUser.Email = email;
            newUser.FullName= fullName;
            newUser.Password= password;
            newUser.Username= username;
            newUser.Phone= phone;
            
            if (userRepository.InsertUser(newUser) > 0)
            {
                User user = userRepository.GetUserByEmailOrUsername(email);
                if (user != null)
                {
                    Preferences.Set("userId", user.Id.ToString());
                    App.Current.MainPage.Navigation.PopModalAsync();
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", userRepository.StatusMessage, "OK");
            }
        }
        private void Back()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }
        private void ShowPassword()
        {
            IsPassword = !IsPassword;
        }

    }
}
