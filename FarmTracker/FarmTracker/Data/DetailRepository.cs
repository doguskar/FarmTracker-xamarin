using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    public class DetailRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;

        private PropertyRepository propertyRepository;
        private EntityRepository entityRepository;

        public DetailRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Detail>();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            propertyRepository = new PropertyRepository(System.IO.Path.Combine(path, "farmTracker"));
            entityRepository = new EntityRepository(System.IO.Path.Combine(path, "farmTracker"));

        }
        public Detail GetDetailById(Guid guid)
        {
            try
            {
                Detail detail = con.Table<Detail>().Where(x => x.Id.Equals(guid))
                    .FirstOrDefault();
                return detail;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public List<Detail> GetDetailsByOwnerId(Guid guid)
        {
            try
            {
                return con.Table<Detail>().Where(x => x.OwnerId.Equals(guid))
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }
        public List<Detail> GetDetails()
        {
            try
            {
                return con.Table<Detail>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }

        public int InsertDetail(Detail detail)
        {
            int result = 0;
            try
            {
                if (detail == null)
                    throw new Exception("Detail can not be null!");
                else if(String.IsNullOrWhiteSpace(detail.Name))
                    throw new Exception("Name can not be null!");
                else if(detail.OwnerId == null)
                    throw new Exception("OwnerId can not be null!");
                else if(detail.DetailType == null)
                    throw new Exception("DetailType can not be null!");

                if (detail.DetailType == DetailType.Property)
                {
                    Property property = propertyRepository.GetPropertyById(detail.OwnerId);
                    if (property == null)
                    {
                        throw new Exception("Owner can not find!");
                    }
                }
                else if (detail.DetailType == DetailType.Entity)
                {
                    Entity entity = entityRepository.GetEntityById(detail.OwnerId);
                    if (entity == null)
                    {
                        throw new Exception("Owner can not find!");
                    }
                }

                if (detail.Id == null)
                    detail.Id = Guid.NewGuid();
                detail.CreatedDate = DateTime.UtcNow;
                result = con.Insert(detail);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, detail.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", detail.Name, ex.Message);
            }

            return result;
        }
        public int DeleteDetailById(Guid guid)
        {
            int result = 0;
            try
            {
                Detail item = GetDetailById(guid);
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
                result = con.DeleteAll<Detail>();
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
