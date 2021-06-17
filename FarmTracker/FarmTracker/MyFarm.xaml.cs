using FarmTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFarm : ContentPage
    {
        public MyFarm()
        {
            InitializeComponent();
            //lvProperties.ItemsSource = Repository.Properties;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyProductTabbedPage() { Title = "MyProperty"});
        }
    }
}