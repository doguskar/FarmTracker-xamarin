using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    public class EntityRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;
        
        private PropertyRepository propertyRepository;
        private CategoryRepository categoryRepository;
        private UserRepository userRepository;

        public EntityRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Entity>();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            propertyRepository = new PropertyRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));
            userRepository = new UserRepository(System.IO.Path.Combine(path, "farmTracker"));
        }

        public Entity GetEntityById(Guid guid)
        {
            try
            {
                Entity entity = con.Table<Entity>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public List<Entity> GetEntitiesByOwnerId(Guid guid)
        {
            try
            {
                List<Entity> entityList = con.Table<Entity>().Where(x => x.OwnerId.Equals(guid))
                    .OrderByDescending(x => x.LastModifiedDate)
                    .ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public int InsertEntity(Entity entity)
        {
            int result = 0;
            try
            {
                if (entity == null)
                    throw new Exception("Entity can not be null!");
                else if(entity.CategoryId == null)
                    throw new Exception("CategoryId can not be null!");
                else if(entity.OwnerId == null)
                    throw new Exception("PropertyId can not be null!");
                else if(entity.EntityType == null)
                    throw new Exception("EntityType can not be null!");

                Category category = categoryRepository.GetCategoryById(entity.CategoryId);
                if (category == null)
                {
                    throw new Exception("Category can not find!");
                }
                if (entity.EntityType == EntityType.Alive)
                {
                    Property property = propertyRepository.GetPropertyById(entity.OwnerId);
                    if (property == null)
                    {
                        throw new Exception("Owner can not find!");
                    }
                }
                else if (entity.EntityType == EntityType.Item)
                {
                    User user = userRepository.GetUserById(entity.OwnerId);
                    if (user == null)
                    {
                        throw new Exception("Owner can not find!");
                    }
                }

                if (entity.Id == null || entity.Id.Equals(new Guid()))
                    entity.Id = Guid.NewGuid();
                entity.LastModifiedDate = DateTime.UtcNow;
                result = con.Insert(entity);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, entity.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", entity.Name, ex.Message);
            }

            return result;
        }
        public int DeleteEntityById(Guid guid)
        {
            int result = 0;
            try
            {
                Entity item = GetEntityById(guid);
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
                result = con.DeleteAll<Entity>();
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
