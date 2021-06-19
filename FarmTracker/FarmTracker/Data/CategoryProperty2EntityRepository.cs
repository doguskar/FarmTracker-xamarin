using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    public class CategoryProperty2EntityRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;
        public CategoryProperty2EntityRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<CategoryProperty2Entity>();
        }
        public CategoryProperty2Entity GetCategoryProperty2EntityById(Guid guid)
        {
            try
            {
                CategoryProperty2Entity categoryProperty2Entity = con.Table<CategoryProperty2Entity>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();
                return categoryProperty2Entity;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public List<CategoryProperty2Entity> GetCategoryProperty2EntityByEntityId(Guid guid)
        {
            try
            {
                List<CategoryProperty2Entity> categoryProperty2Entities = con.Table<CategoryProperty2Entity>().Where(x => x.EntityId.Equals(guid))
                    .ToList();
                return categoryProperty2Entities;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public int InsertCategoryProperty2Entity(CategoryProperty2Entity item)
        {
            int result = 0;
            try
            {
                if (item.Id == null)
                    item.Id = Guid.NewGuid();
                result = con.Insert(item);
                StatusMessage = string.Format("{0} record(s) added [Value: {1})", result, item.Value);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", item.Value, ex.Message);
            }
            return result;
        }
        public int DeleteAll()
        {
            int result = 0;
            try
            {
                result = con.DeleteAll<CategoryProperty2Entity>();
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
