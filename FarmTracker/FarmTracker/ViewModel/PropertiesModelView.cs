using FarmTracker.Data;
using FarmTracker.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FarmTracker.ViewModel
{
    public class PropertiesViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Property> Properties { get; set; }
        private Property selectedProperty;

        private PropertyRepository propertyRepository;

        public PropertiesViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            propertyRepository = new PropertyRepository(System.IO.Path.Combine(path, "farmTracker"));

            string userId = Preferences.Get("userId", null);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                List<Property> propertyList = propertyRepository.GetPropertiesByUserId(new Guid(userId));
                if (propertyList != null)
                {
                    Properties = new ObservableRangeCollection<Property>(propertyList);
                }
            }
        }

        public Property SelectedProperty
        {
            get => selectedProperty;
            set
            {
                if (value != null)
                {
                    Preferences.Set("currentPropertyId", value.Id.ToString());
                    App.Current.MainPage.Navigation.PushModalAsync(new PropertyTabbedPage());
                }
                selectedProperty = value;
                OnPropertyChanged();
            }
        }


    }
}
