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
    public class PropertyFormViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private string image;
        private int pickerLv1SelectedIndex = -1;
        private int pickerLv2SelectedIndex = -1;
        private int pickerLv3SelectedIndex = -1;
        private string categoryId;
        public string FormHeader { get; set; }
        public ObservableRangeCollection<string> PickerLv1Source { get; set; }
        public ObservableRangeCollection<string> PickerLv2Source { get; set; }
        public ObservableRangeCollection<string> PickerLv3Source { get; set; }
        private List<Category> SubCategoriesLv1;
        private List<Category> SubCategoriesLv2;
        private List<Category> SubCategoriesLv3;
        private bool isPickerLv2Active;
        private bool isPickerLv3Active;



        public ICommand SubmitCommand { get; set; }

        private PropertyRepository propertyRepository;
        private CategoryRepository categoryRepository;

        public PropertyFormViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            propertyRepository = new PropertyRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));

            FormHeader = "Add Property";
            SubmitCommand = new Command(AddProperty, CanAddProperty);

            PickerLv1Source = new ObservableRangeCollection<string>();
            PickerLv2Source = new ObservableRangeCollection<string>();
            PickerLv3Source = new ObservableRangeCollection<string>();
            Category aliveCategory = categoryRepository.GetCategoryByName("Alive");
            if (aliveCategory != null)
            {
                SubCategoriesLv1 = categoryRepository.GetSubCategoryById(aliveCategory.Id);
                if (SubCategoriesLv1 != null)
                {
                    foreach (var item in SubCategoriesLv1)
                    {
                        PickerLv1Source.Add(item.Name);
                    }
                }
            }
        }

        private void AddProperty()
        {
            if (pickerLv3SelectedIndex >= 0)
            {
                Guid categoryId = SubCategoriesLv3[pickerLv3SelectedIndex].Id;

                int result = propertyRepository.InsertProperty(new Property
                {
                    Name = name,
                    Description = description,
                    CategoryId = categoryId
                });
                if (result > 0)
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Alert", propertyRepository.StatusMessage, "OK");
                }
            }
        }
        private bool CanAddProperty()
        {
            return pickerLv3SelectedIndex >= 0 && !String.IsNullOrWhiteSpace(name);
        }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                (SubmitCommand as Command).ChangeCanExecute();
            }
        }
        public string Description
        {
            get => description;
            set
            {
                SetProperty(ref description, value);
            }
        }
        public int PickerLv1SelectedIndex
        {
            get => pickerLv1SelectedIndex;
            set
            {
                pickerLv2SelectedIndex = -1;
                pickerLv3SelectedIndex = -1;
                IsPickerLv3Active = false;
                if (value >= 0)
                {
                    SubCategoriesLv2 = categoryRepository.GetSubCategoryById(SubCategoriesLv1[value].Id);
                    if (SubCategoriesLv2 != null)
                    {
                        PickerLv2Source.Clear();
                        foreach (var item in SubCategoriesLv2)
                        {
                            PickerLv2Source.Add(item.Name);
                        }
                        IsPickerLv2Active = true;
                    }
                }
                SetProperty(ref pickerLv1SelectedIndex, value);
            }
        }
        public int PickerLv2SelectedIndex
        {
            get => pickerLv2SelectedIndex;
            set
            {
                pickerLv3SelectedIndex = -1;
                if (value >= 0)
                {
                    SubCategoriesLv3 = categoryRepository.GetSubCategoryById(SubCategoriesLv2[value].Id);
                    if (SubCategoriesLv3 != null)
                    {
                        PickerLv3Source.Clear();
                        foreach (var item in SubCategoriesLv3)
                        {
                            PickerLv3Source.Add(item.Name);
                        }
                        IsPickerLv3Active = true;
                    }
                }
                SetProperty(ref pickerLv2SelectedIndex, value);
                (SubmitCommand as Command).ChangeCanExecute();
            }
        }
        public int PickerLv3SelectedIndex
        {
            get => pickerLv3SelectedIndex;
            set
            {
                SetProperty(ref pickerLv3SelectedIndex, value);
                (SubmitCommand as Command).ChangeCanExecute();
            }
        }

        public bool IsPickerLv2Active 
        { 
            get => isPickerLv2Active;
            set 
            {
                isPickerLv2Active = value;
                OnPropertyChanged();
            }
        }
        public bool IsPickerLv3Active 
        { 
            get => isPickerLv3Active;
            set 
            {
                isPickerLv3Active = value;
                OnPropertyChanged();
            }
        }
    }
}
