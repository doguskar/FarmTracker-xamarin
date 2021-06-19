using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;
using Xamarin.Essentials;

namespace FarmTracker.Data
{
    public class PropertyRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;


        private CategoryRepository categoryRepository;
        private UserRepository userRepository;

        public PropertyRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Property>();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            userRepository = new UserRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));
        }
        public Property GetPropertyById(Guid guid)
        {
            try
            {
                Property property = con.Table<Property>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();
                if (string.IsNullOrWhiteSpace(property.Image))
                    property.Image = categoryRepository.GetCategoryById(property.CategoryId).Image;
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
                List<Property> propertyList2 = con.Table<Property>()
                    .ToList();
                List<Property> propertyList = con.Table<Property>().Where(x => x.UserId.Equals(guid))
                    .OrderByDescending(x => x.LastModifiedDate)
                    .ToList();
                foreach (var item in propertyList)
                {
                    if (string.IsNullOrWhiteSpace(item.Image))
                        item.Image = categoryRepository.GetCategoryById(item.CategoryId).Image;
                }
                return propertyList;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public int InsertProperty(Property item)
        {
            int result = 0;
            try
            {
                if (item == null)
                    throw new Exception("Property can not be null!");
                else if (String.IsNullOrWhiteSpace(item.Name))
                    throw new Exception("Name can not be null!");

                User user = userRepository.GetUserById(item.UserId);
                if (user == null)
                {
                    string userId = Preferences.Get("userId", null);
                    if (!string.IsNullOrWhiteSpace(userId))
                    {
                        user = userRepository.GetUserById(new Guid(userId));
                    }
                }
                if (user == null)
                    throw new Exception(string.Format("User is not found! [UserId: {0}", item.UserId));

                Category category = categoryRepository.GetCategoryById(item.CategoryId);
                if (category == null)
                    throw new Exception(string.Format("Category is not found! [UserId: {0}", item.UserId));

                item.UserId = user.Id;
                item.LastModifiedDate = DateTime.UtcNow;
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
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", guid, ex.Message);
            }

            return result;
        }
        public int DeleteAll()
        {
            int result = 0;
            try
            {
                result = con.DeleteAll<Property>();
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
