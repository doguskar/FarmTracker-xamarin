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
            con.CreateTable<Property>();

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
        public List<Entity> GetEntitiesByPropertyId(Guid guid)
        {
            try
            {
                List<Entity> entityList = con.Table<Entity>().Where(x => x.PropertyId.Equals(guid))
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
                else if(entity.PropertyId == null)
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
                    Property property = propertyRepository.GetPropertyById(detail.OwnerId);
                    if (property == null)
                    {
                        throw new Exception("Owner can not find!");
                    }
                }
                else if (entity.EntityType == EntityType.Item)
                {
                    User user = userRepository.GetUserById(entity.OwnerId);
                    if (property == null)
                    {
                        throw new Exception("Owner can not find!");
                    }
                }

                entity.Id = Guid.NewGuid();
                result = con.Insert(entity);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, entity.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", user.Email, ex.Message);
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
                    return con.Delete(item);
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
