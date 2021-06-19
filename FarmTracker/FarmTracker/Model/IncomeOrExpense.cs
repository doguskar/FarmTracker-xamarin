using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class IncomeOrExpense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public bool IncomeFlag { get; set; }
        public Guid UserId { get; set; }
        public string Image { get; set; }
    }
}
