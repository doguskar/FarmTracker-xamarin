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
    class IncomeOrExpenseFormViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private int cost;
        private bool incomeFlag;

        public ICommand SubmitCommand { get; set; }
        public string FormHeader { get; set; }

        private IncomeOrExpenseRepository incomeOrExpenseRepository;

        public IncomeOrExpenseFormViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            incomeOrExpenseRepository = new IncomeOrExpenseRepository(System.IO.Path.Combine(path, "farmTracker"));

            FormHeader = "Add Income Or Expense";
            SubmitCommand = new Command(AddIncomeOrExpense, CanAddIncomeOrExpense);
        }

        private void AddIncomeOrExpense()
        {
            int result = incomeOrExpenseRepository.InsertIncomeOrExpense(new IncomeOrExpense
            {
                Name = name,
                Description = description,
                Cost = cost,
                IncomeFlag = incomeFlag,
                Date = DateTime.UtcNow
            });
            if (result > 0)
            {
                App.Current.MainPage.Navigation.PopModalAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", incomeOrExpenseRepository.StatusMessage, "OK");
            }
        }
        private bool CanAddIncomeOrExpense()
        {
            return cost > 0 && !String.IsNullOrWhiteSpace(name);
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
                (SubmitCommand as Command).ChangeCanExecute();
            }
        }
        public bool IncomeFlag
        {
            get => incomeFlag;
            set
            {
                SetProperty(ref incomeFlag, value);
            }
        }
    }
}
