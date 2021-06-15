using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    public class CategoryRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;
        public CategoryRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Category>();
        }
        public Category GetCategoryById(Guid guid)
        {
            try
            {
                Category category = con.Table<Category>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();
                return category;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
    }
}
