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
        public IncomeOrExpense GetIncomeOrExpenseById(Guid guid)
        {
            try
            {
                return con.Table<IncomeOrExpense>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
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
        public int DeleteIncomeOrExpenseById(Guid guid)
        {
            int result = 0;
            try
            {
                IncomeOrExpense item = GetIncomeOrExpenseById(guid);
                if(item != null)
                {
                    result = con.Delete(item);
                    StatusMessage = string.Format("{0} record(s) deleted [Name: {1})", result, item.Name);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", item.Id, ex.Message);
            }

            return result;
        }
    }
}
