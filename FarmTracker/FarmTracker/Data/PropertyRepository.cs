using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    public class PropertyRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;


        private CategoryRepository categoryRepository;

        public PropertyRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Property>();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));
        }
        public Property GetPropertyById(Guid guid)
        {
            try
            {
                Property property = con.Table<Property>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();

                property.Category = categoryRepository.GetCategoryById(property.CategoryId);

                return property;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public List<Property> GetPropertiesByUserId(Guid guid)
        {
            try
            {
                List<Property> propertyList = con.Table<Property>().Where(x => x.UserId.Equals(guid))
                    .ToList();
                foreach (var property in propertyList)
                {
                    property.Category = categoryRepository.GetCategoryById(property.CategoryId);
                }
                return propertyList;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public int DeletePropertyById(Guid guid)
        {
            int result = 0;
            try
            {
                Property item = GetPropertyById(guid);
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
