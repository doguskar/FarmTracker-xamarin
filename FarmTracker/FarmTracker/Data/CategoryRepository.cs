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
        public int InsertCategory(Category item)
        {
            int result = 0;
            try
            {
                item.Id = Guid.NewGuid();
                result = con.Insert(item);
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, item.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", item.Name, ex.Message);
            }
            return result;
        }
        public int DeleteAll()
        {
            int result = 0;
            try
            {
                result = con.DeleteAll<Category>();
                StatusMessage = string.Format("{0} record(s) deleted", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error: {0}", ex.Message);
            }
            return result;
        }
    }
}
