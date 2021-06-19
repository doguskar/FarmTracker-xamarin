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
    class IncomeAndExpensesViewModel : BaseViewModel
    {
        public ObservableRangeCollection<IncomeOrExpense> IncomeOrExpenses{ get; set; }
        private IncomeOrExpenseRepository incomeOrExpenseRepository;
        public IncomeAndExpensesViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            incomeOrExpenseRepository = new IncomeOrExpenseRepository(System.IO.Path.Combine(path, "farmTracker"));

            string userId = Preferences.Get("userId", null);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                List<IncomeOrExpense> incomeOrExpenseList = incomeOrExpenseRepository.GetIncomeOrExpensesByUserId(new Guid(userId));
                if (incomeOrExpenseList != null)
                {
                    foreach (var item in incomeOrExpenseList)
                    {
                        if (item.IncomeFlag)
                        {
                            item.Image = "moneybag1.png";
                        }
                        else
                        {
                            item.Image = "moneybag2.png";
                        }
                    }
                    IncomeOrExpenses = new ObservableRangeCollection<IncomeOrExpense>(incomeOrExpenseList);
                }
            }
        }

    }
}
