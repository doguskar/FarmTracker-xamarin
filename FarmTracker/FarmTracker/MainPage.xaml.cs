using FarmTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FarmTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //lvAdds.ItemsSource = Repository.Adds;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDetailPage() { Title = "Angle" });
        }
    }
}
