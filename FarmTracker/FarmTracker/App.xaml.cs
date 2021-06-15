using FarmTracker.Model;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmTracker
{
    public partial class App : Application
    {
        public App()
        {
            bool initialize = Preferences.Get("initialize", true);
            if (initialize)
            {
                Initialize();   
            }

            InitializeComponent();

            MainPage = new MasterDetailPage1();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void Initialize()
        {
            List<Guid> guids = new List<Guid>();
            for (int i = 0; i < 20; i++)
                guids.Add(Guid.NewGuid());

            List<User> userList = new List<User>
            {
                new User{ Id=guids[10], FullName="Admin FarmTracker", Email="admin@farmtracker.com", Password="admin", Username="admin", Phone="+90 555 333 22 11"}
            };

            List<Category> categoryList = new List<Category>
            {
                new Category{ Id = guids[0], Name = "Alive", EndPointFlag = false },
                new Category{ Id = guids[1], Name = "Item", EndPointFlag = false },

                new Category{ Id = guids[2], Name = "Plant", EndPointFlag = false, Pic = "animal.png", SuperCategoryId = guids[0] },
                new Category{ Id = Guid.NewGuid(), Name = "Terrestrial", EndPointFlag = true, Pic = "Terrestrial.png", SuperCategoryId = guids[2] },
                new Category{ Id = Guid.NewGuid(), Name = "Aquatic", EndPointFlag = true, Pic = "Aquatic.png", SuperCategoryId = guids[2] },
                
                new Category{ Id = guids[3], Name = "Animal", EndPointFlag = false, SuperCategoryId = guids[0] },
                new Category{ Id = Guid.NewGuid(), Name = "Saltwater", EndPointFlag = true, Pic = "Saltwater.png", SuperCategoryId = guids[3] },
                new Category{ Id = guids[4], Name = "Freshwater", EndPointFlag = false, SuperCategoryId = guids[3] },
                new Category{ Id = guids[5], Name = "Cichlids", EndPointFlag = false, SuperCategoryId = guids[4] },
                new Category{ Id = guids[6], Name = "Blue Dolphin", EndPointFlag = true, Pic = "animal.png", SuperCategoryId = guids[5] },
                new Category{ Id = guids[7], Name = "Electric Yellow", EndPointFlag = true, Pic = "animal.png", SuperCategoryId = guids[5] },
                new Category{ Id = guids[15], Name = "Angle", EndPointFlag = true, Pic = "Angle.png", SuperCategoryId = guids[5] },
                new Category{ Id = guids[8], Name = "Livebearers", EndPointFlag = false, SuperCategoryId = guids[4] },
                new Category{ Id = guids[9], Name = "Guppy", EndPointFlag = true, Pic = "Guppy.png", SuperCategoryId = guids[8] },
                new Category{ Id = guids[14], Name = "Endler", EndPointFlag = true, Pic = "Endler.png", SuperCategoryId = guids[8] },
            };

            List<Property> propertyList = new List<Property>
            {
                new Property{ Id = guids[11], Name = "Cichlid Aquarium", Description = "Main Aquarium", CategoryId = guids[4], UserId = guids[10], LastModifiedDate = DateTime.UtcNow },
                new Property{ Id = guids[12], Name = "Quarantine Aquarium", Description = "Middle Aquarium", CategoryId = guids[4], UserId = guids[10], LastModifiedDate = DateTime.UtcNow },
                new Property{ Id = guids[13], Name = "Livebearer Aquarium", Description = "Middle Aquarium", CategoryId = guids[4], UserId = guids[10], LastModifiedDate = DateTime.UtcNow },
            };

            List<Entity> entityList = new List<Entity>
            {
                new Entity{ Id = guids[16], Name = "Male Blue Dolphin", Count = 1, Cost = 0, CategoryId = guids[6], PropertyId = guids[11], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = guids[17], Name = "Female Blue Dolphin 1", Count = 1, Cost = 0, CategoryId = guids[6], PropertyId = guids[11], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = guids[18], Name = "Female Blue Dolphin 2", Count = 1, Cost = 0, CategoryId = guids[6], PropertyId = guids[11], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Electric Yellow", Count = 1, Cost = 0, CategoryId = guids[7], PropertyId = guids[11], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Electric Yellow 2", Count = 1, Cost = 0, CategoryId = guids[7], PropertyId = guids[11], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Blue Dolphin", Count = 100, Cost = 0, CategoryId = guids[6], PropertyId = guids[12], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Angle", Count = 1, Cost = 0, CategoryId = guids[15], PropertyId = guids[13], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Guppy", Count = 5, Cost = 0, CategoryId = guids[9], PropertyId = guids[13], LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Endler", Count = 5, Cost = 0, CategoryId = guids[14], PropertyId = guids[13], LastModifiedDate = DateTime.UtcNow },
            };


        }
    }
}
