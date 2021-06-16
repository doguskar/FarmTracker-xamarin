using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    class IncomeOrExpenseRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;

        public IncomeOrExpenseRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Property>();
        }
        public List<IncomeOrExpense> GetIncomeOrExpensesByUserId(Guid guid)
        {
            try
            {
                return con.Table<IncomeOrExpense>().Where(x => x.UserId.Equals(guid))
                    .ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
    }
}
