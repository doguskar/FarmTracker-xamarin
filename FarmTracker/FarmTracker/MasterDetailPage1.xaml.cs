using FarmTracker.Data;
using FarmTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        private UserRepository userRepository;
        public MasterDetailPage1()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            userRepository = new UserRepository(System.IO.Path.Combine(path, "farmTracker"));

            string userId = Preferences.Get("userId", null);
            if (!String.IsNullOrWhiteSpace(userId))
            {
                User user = userRepository.GetUserById(new Guid(userId));
                if (user == null)
                {
                    Navigation.PushModalAsync(new LoginPage());
                }
            }
            else
            {
                Navigation.PushModalAsync(new LoginPage());
            }

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPage1MasterMenuItem;
            if (item == null)
                return;
            if(item.Id == 3)
            {
                SignOut();
            }
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private void SignOut()
        {
            Preferences.Remove("userId");
            Navigation.PushModalAsync(new LoginPage());
        }
            
    }
}