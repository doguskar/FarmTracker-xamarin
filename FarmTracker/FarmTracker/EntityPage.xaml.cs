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
    public partial class EntityPage : ContentPage
    {

        private CategoryPropertyRepository categoryPropertyRepository;
        private CategoryProperty2EntityRepository categoryProperty2EntityRepository;

        public EntityPage()
        {
            InitializeComponent();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            categoryPropertyRepository = new CategoryPropertyRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryProperty2EntityRepository = new CategoryProperty2EntityRepository(System.IO.Path.Combine(path, "farmTracker"));

            string currentEntityId = Preferences.Get("currentEntityId", null);
            if (!string.IsNullOrWhiteSpace(currentEntityId))
            {
                List<CategoryProperty2Entity> categoryProperty2EntityList = categoryProperty2EntityRepository.GetCategoryProperty2EntityByEntityId(new Guid(currentEntityId));
                if (categoryProperty2EntityList != null)
                {
                    foreach (var item in categoryProperty2EntityList)
                    {
                        CategoryProperty categoryProperty = categoryPropertyRepository.GetCategoryPropertyById(item.CategoryPropertyId);
                        AddKeyValueToStackLayout(categoryProperty.Name, item.Value);
                    }
                }
            }
        }

        private void AddKeyValueToStackLayout(string key, string value)
        {
            StackLayout stackLayout = new StackLayout();
            stackLayout.Orientation = StackOrientation.Horizontal;
            Label labelKey = new Label { Text = key + ":",  FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)), TextColor = Color.FromHex("000")};
            Label labelValue = new Label { Text = value,    FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)), TextColor = Color.FromHex("606060")}; //, Margin = new Thickness(0, 5, 0, 5) 
            if (value.Equals("good", StringComparison.OrdinalIgnoreCase))
            {
                labelValue.TextColor = Color.FromHex("3F9704");
            }
            else if (value.Equals("bad", StringComparison.OrdinalIgnoreCase))
            {
                labelValue.TextColor = Color.FromHex("DF0000");
            }
            stackLayout.Children.Add(labelKey);
            stackLayout.Children.Add(labelValue);
            MainStackLayout.Children.Add(stackLayout);
        }
    }
}