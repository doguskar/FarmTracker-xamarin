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
    class EntityFormViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private int count = 1;
        private decimal cost;
        private DateTime? purchasedDate;
        private bool addExpenseFlag;
        private bool isAddExpenseFlagActive;
        private int pickerLv1SelectedIndex = -1;
        private int pickerLv2SelectedIndex = -1;
        public string FormHeader { get; set; }
        public ObservableRangeCollection<string> PickerLv1Source { get; set; }
        public ObservableRangeCollection<string> PickerLv2Source { get; set; }
        private List<Category> SubCategoriesLv1;
        private List<Category> SubCategoriesLv2;
        private bool isPickerLv2Active;

        public ICommand SubmitCommand { get; set; }

        private CategoryRepository categoryRepository;
        private EntityRepository entityRepository;
        private IncomeOrExpenseRepository incomeOrExpenseRepository;
        private PropertyRepository propertyRepository;

        public EntityFormViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            entityRepository = new EntityRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));
            incomeOrExpenseRepository = new IncomeOrExpenseRepository(System.IO.Path.Combine(path, "farmTracker"));
            propertyRepository = new PropertyRepository(System.IO.Path.Combine(path, "farmTracker"));

            FormHeader = "Add Entity";
            SubmitCommand = new Command(AddItem, CanAddItem);

            PickerLv1Source = new ObservableRangeCollection<string>();
            PickerLv2Source = new ObservableRangeCollection<string>();
            Property property = propertyRepository.GetPropertyById(new Guid(Preferences.Get("currentPropertyId", null)));
            if (property != null)
            {
                List<Category> lv1Categories = categoryRepository.GetSubCategoryById(property.CategoryId);
                SubCategoriesLv1 = lv1Categories;
                if (SubCategoriesLv1 != null)
                {
                    foreach (var item in SubCategoriesLv1)
                    {
                        PickerLv1Source.Add(item.Name);
                    }
                }
            }

        }
        private void AddItem()
        {
            if (pickerLv2SelectedIndex >= 0)
            {
                Guid categoryId = SubCategoriesLv2[pickerLv2SelectedIndex].Id;

                int result = entityRepository.InsertEntity(new Entity
                {
                    Name = name,
                    Description = description,
                    CategoryId = categoryId,
                    Count = count,
                    Cost = cost,
                    PurchasedDate = (purchasedDate == null) ? DateTime.Now : (DateTime)purchasedDate,
                    OwnerId = new Guid(Preferences.Get("currentPropertyId", null)),
                    EntityType = EntityType.Alive
                });
                if (result > 0)
                {
                    if (cost > 0 && isAddExpenseFlagActive)
                    {
                        incomeOrExpenseRepository.InsertIncomeOrExpense(new IncomeOrExpense
                        {
                            Name = name,
                            Description = description,
                            Date = (purchasedDate == null)? DateTime.Now: (DateTime)purchasedDate,
                            Cost = cost
                        });
                    }
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Alert", entityRepository.StatusMessage, "OK");
                }
            }
        }
        private bool CanAddItem()
        {
            return pickerLv2SelectedIndex >= 0 && !String.IsNullOrWhiteSpace(name) && count >= 1;
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
        public int Count
        {
            get => count;
            set
            {
                SetProperty(ref count, value);
                (SubmitCommand as Command).ChangeCanExecute();
            }
        }
        public decimal Cost
        {
            get => cost;
            set
            {
                SetProperty(ref cost, value);
                IsAddExpenseFlagActive = cost > 0;
                AddExpenseFlag = cost > 0;
            }
        }
        public bool AddExpenseFlag
        {
            get => addExpenseFlag;
            set
            {
                SetProperty(ref addExpenseFlag, value);
                OnPropertyChanged();
            }
        }
        public bool IsAddExpenseFlagActive
        {
            get => isAddExpenseFlagActive;
            set
            {
                SetProperty(ref isAddExpenseFlagActive, value);
                OnPropertyChanged();
            }
        }
        public DateTime? PurchasedDate
        {
            get => purchasedDate;
            set
            {
                SetProperty(ref purchasedDate, value);
            }
        }
        public int PickerLv1SelectedIndex
        {
            get => pickerLv1SelectedIndex;
            set
            {
                pickerLv2SelectedIndex = -1;
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
                SetProperty(ref pickerLv2SelectedIndex, value);
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
    }
}
