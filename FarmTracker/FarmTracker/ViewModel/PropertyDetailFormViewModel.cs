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
    class PropertyDetailFormViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private int cost;
        private DateTime date = DateTime.Now;
        private DateTime? remainderDate;
        private bool addExpenseFlag;
        private bool isAddExpenseFlagActive;
        public ICommand SubmitCommand { get; set; }
        public string FormHeader { get; set; }

        private DetailRepository detailRepository;
        private IncomeOrExpenseRepository incomeOrExpenseRepository;

        public PropertyDetailFormViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            detailRepository = new DetailRepository(System.IO.Path.Combine(path, "farmTracker"));
            incomeOrExpenseRepository = new IncomeOrExpenseRepository(System.IO.Path.Combine(path, "farmTracker"));

            FormHeader = "Add Detail";
            SubmitCommand = new Command(AddItem, CanAddItem);
        }
        private void AddItem()
        {

            if (remainderDate != null && (((DateTime)remainderDate).Date - DateTime.UtcNow.Date).Days <= 0)
            {
                remainderDate = null;
            }
            string ownerId = Preferences.Get("currentPropertyId", null);
            int result = detailRepository.InsertDetail(new Detail
            {
                Name = name,
                Description = description,
                Cost = cost,
                Date = date,
                RemainderDate = remainderDate,
                DetailType = DetailType.Property,
                OwnerId = new Guid(ownerId),
            });
            if (result > 0)
            {
                if (cost > 0 && addExpenseFlag)
                {
                    incomeOrExpenseRepository.InsertIncomeOrExpense(new IncomeOrExpense
                    {
                        Name = name,
                        Description = description,
                        Date = date,
                        Cost = cost
                    });
                }
                App.Current.MainPage.Navigation.PopModalAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", detailRepository.StatusMessage, "OK");
            }
        }
        private bool CanAddItem()
        {
            return !String.IsNullOrWhiteSpace(name);
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
        public int Cost
        {
            get => cost;
            set
            {
                SetProperty(ref cost, value);
                IsAddExpenseFlagActive = cost > 0;
                AddExpenseFlag = cost > 0;
            }
        }
        public DateTime Date
        {
            get => date;
            set
            {
                SetProperty(ref date, value);
            }
        }
        public DateTime? RemainderDate
        {
            get => remainderDate;
            set
            {
                SetProperty(ref remainderDate, value);
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
    }
}
