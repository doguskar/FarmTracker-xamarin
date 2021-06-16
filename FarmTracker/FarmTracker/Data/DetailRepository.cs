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

        public DetailRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Property>();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            propertyRepository = new PropertyRepository(System.IO.Path.Combine(path, "farmTracker"));

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
                    Property property = propertyRepository.GetPropertyById(detail.OwnerId);
                    if (property == null)
                    {
                        throw new Exception("Owner can not find!");
                    }
                }


                detail.Id = Guid.NewGuid();
                result = con.Insert(detail);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, user.Email);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", user.Email, ex.Message);
            }

            return result;
        }
    }
}
