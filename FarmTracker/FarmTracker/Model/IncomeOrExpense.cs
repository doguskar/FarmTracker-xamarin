using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class IncomeOrExpense
    {
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Image { get; set; }
        public bool IncomeFlag { get; set; }
    }
}
