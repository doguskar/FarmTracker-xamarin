using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    public class CategoryPropertyRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;
        public CategoryPropertyRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<CategoryProperty>();
        }
        public CategoryProperty GetCategoryPropertyById(Guid guid)
        {
            try
            {
                CategoryProperty categoryProperty = con.Table<CategoryProperty>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();
                return categoryProperty;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public int InsertCategoryProperty(CategoryProperty item)
        {
            int result = 0;
            try
            {
                if (item.Id == null)
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
                result = con.DeleteAll<CategoryProperty>();
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
