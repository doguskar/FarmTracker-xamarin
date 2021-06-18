﻿using FarmTracker.Data;
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
        private UserRepository userRepository;
        public App()
        {
            //Preferences.Remove("initialize");
            bool initialize = Preferences.Get("initialize", true);
            if (initialize)
            {
                Initialize();   
            }

            InitializeComponent();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            userRepository = new UserRepository(System.IO.Path.Combine(path, "farmTracker"));

            string userId = Preferences.Get("userId", null);
            if (!String.IsNullOrWhiteSpace(userId))
            {
                User user = userRepository.GetUserById(new Guid(userId));
                if (user == null)
                {
                    MainPage = new LoginPage();
                }
                else
                {
                    MainPage = new MasterDetailPage1();
                }
            }
            else
            {
                MainPage = new LoginPage();
            }

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
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            UserRepository userRepository = new UserRepository(System.IO.Path.Combine(path, "farmTracker"));
            CategoryRepository categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));
            PropertyRepository propertyRepository = new PropertyRepository(System.IO.Path.Combine(path, "farmTracker"));
            EntityRepository entityRepository = new EntityRepository(System.IO.Path.Combine(path, "farmTracker"));
            DetailRepository detailRepository = new DetailRepository(System.IO.Path.Combine(path, "farmTracker"));
            IncomeOrExpenseRepository incomeOrExpenseRepository= new IncomeOrExpenseRepository(System.IO.Path.Combine(path, "farmTracker"));

            List<Guid> guids = new List<Guid>();
            for (int i = 0; i < 20; i++)
                guids.Add(Guid.NewGuid());

            /* User TABLE */
            userRepository.DeleteAll();
            List<User> userList = new List<User>
            {
                new User{ Id=guids[10], FullName="Admin FarmTracker", Email="admin@farmtracker.com", Password="admin", Username="admin", Phone="+90 555 333 22 11"}
            };
            foreach (var item in userList)
            {
                userRepository.InsertUser(item);
            }
            /* User TABLE END */

            /* Category TABLE */
            categoryRepository.DeleteAll();
            List<Category> categoryList = new List<Category>
            {
                new Category{ Id = guids[0], Name = "Alive", EndPointFlag = false },
                new Category{ Id = guids[1], Name = "Item", EndPointFlag = true, Image = "item.png" },

                new Category{ Id = guids[2], Name = "Plant", EndPointFlag = false, Image = "animal.png", SuperCategoryId = guids[0] },
                new Category{ Id = Guid.NewGuid(), Name = "Terrestrial", EndPointFlag = true, Image = "Terrestrial.png", SuperCategoryId = guids[2] },
                new Category{ Id = Guid.NewGuid(), Name = "Aquatic", EndPointFlag = true, Image = "Aquatic.png", SuperCategoryId = guids[2] },
                
                new Category{ Id = guids[3], Name = "Animal", EndPointFlag = false, SuperCategoryId = guids[0] },
                new Category{ Id = Guid.NewGuid(), Name = "Saltwater", EndPointFlag = true, Image = "Saltwater.png", SuperCategoryId = guids[3] },
                new Category{ Id = guids[4], Name = "Freshwater", EndPointFlag = false, SuperCategoryId = guids[3], Image = "Freshwater.jpg" },
                new Category{ Id = guids[5], Name = "Cichlids", EndPointFlag = false, SuperCategoryId = guids[4] },
                new Category{ Id = guids[6], Name = "Blue Dolphin", EndPointFlag = true, Image = "animal.png", SuperCategoryId = guids[5] },
                new Category{ Id = guids[7], Name = "Electric Yellow", EndPointFlag = true, Image = "animal.png", SuperCategoryId = guids[5] },
                new Category{ Id = guids[15], Name = "Angle", EndPointFlag = true, Image = "Angle.png", SuperCategoryId = guids[5] },
                new Category{ Id = guids[8], Name = "Livebearers", EndPointFlag = false, SuperCategoryId = guids[4] },
                new Category{ Id = guids[9], Name = "Guppy", EndPointFlag = true, Image = "Guppy.png", SuperCategoryId = guids[8] },
                new Category{ Id = guids[14], Name = "Endler", EndPointFlag = true, Image = "Endler.png", SuperCategoryId = guids[8] },
            };
            foreach (var item in categoryList)
            {
                categoryRepository.InsertCategory(item);
            }
            /* Category TABLE END*/

            /* Property TABLE */
            propertyRepository.DeleteAll();
            List<Property> propertyList = new List<Property>
            {
                new Property{ Id = guids[11], Name = "Cichlid Aquarium", Description = "Main Aquarium", Image="Cichlid.jpg", CategoryId = guids[4], UserId = guids[10], LastModifiedDate = DateTime.UtcNow },
                new Property{ Id = guids[12], Name = "Quarantine Aquarium", Description = "Middle Aquarium", Image="Quarantine.jpg", CategoryId = guids[4], UserId = guids[10], LastModifiedDate = DateTime.UtcNow },
                new Property{ Id = guids[13], Name = "Livebearer Aquarium", Description = "Middle Aquarium", Image="Livebearer.jpg", CategoryId = guids[4], UserId = guids[10], LastModifiedDate = DateTime.UtcNow },
            };
            foreach (var item in propertyList)
            {
                propertyRepository.InsertProperty(item);
            }
            /* Property TABLE END*/

            /* Entity TABLE */
            entityRepository.DeleteAll();
            List<Entity> entityList = new List<Entity>
            {
                new Entity{ Id = guids[16], Name = "Male Blue Dolphin", Count = 1, Cost = 0, CategoryId = guids[6], OwnerId = guids[11], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = guids[17], Name = "Female Blue Dolphin 1", Count = 1, Cost = 0, CategoryId = guids[6], OwnerId = guids[11], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = guids[18], Name = "Female Blue Dolphin 2", Count = 1, Cost = 0, CategoryId = guids[6], OwnerId = guids[11], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Electric Yellow", Count = 1, Cost = 0, CategoryId = guids[7], OwnerId = guids[11], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Electric Yellow 2", Count = 1, Cost = 0, CategoryId = guids[7], OwnerId = guids[11], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Blue Dolphin", Count = 100, Cost = 0, CategoryId = guids[6], OwnerId = guids[12], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Angle", Count = 1, Cost = 0, CategoryId = guids[15], OwnerId = guids[13], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Guppy", Count = 5, Cost = 0, CategoryId = guids[9], OwnerId = guids[13], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },
                new Entity{ Id = Guid.NewGuid(), Name = "Endler", Count = 5, Cost = 0, CategoryId = guids[14], OwnerId = guids[13], EntityType = EntityType.Alive, LastModifiedDate = DateTime.UtcNow },

                new Entity{ Id = Guid.NewGuid(), Name = "Aquarium", Description = "120x60x50 450Lt", Count = 1, CategoryId = guids[1], EntityType = EntityType.Item, OwnerId = guids[10] },
                new Entity{ Id = Guid.NewGuid(), Name = "Airpumnp", Description = "Eheim 400 airpump", Count = 1, CategoryId = guids[1], EntityType = EntityType.Item, OwnerId = guids[10] },
                new Entity{ Id = Guid.NewGuid(), Name = "External Filter", Description = "1000 Lt/H filter", Count = 1, CategoryId = guids[1], EntityType = EntityType.Item, OwnerId = guids[10] },
                new Entity{ Id = Guid.NewGuid(), Name = "Fish Food", Description = "Tetra Discus 10Lt", Count = 1, CategoryId = guids[1], EntityType = EntityType.Item, OwnerId = guids[10] },
            };
            foreach (var item in entityList)
            {
                entityRepository.InsertEntity(item);
            }
            /* Entity TABLE END*/

            /* Detail TABLE END*/
            detailRepository.DeleteAll();
            List<Detail> detailList = new List<Detail>
            {
                new Detail{ Id = Guid.NewGuid(), Name = "Pregnant", RemainderDate = DateTime.UtcNow.AddDays(-15), RemainderCompletedDate = DateTime.UtcNow, DetailType = DetailType.Entity, OwnerId = guids[17]},
                new Detail{ Id = Guid.NewGuid(), Name = "Birth", Description="100 Babies", DetailType = DetailType.Entity, OwnerId = guids[17]},

                new Detail{ Id = Guid.NewGuid(), Name = "Patient", Description="Not eating", DetailType = DetailType.Entity, OwnerId = guids[16]},

                new Detail{ Id = Guid.NewGuid(), Name = "Water change", Description="weakly %30 water change", Date = DateTime.UtcNow, DetailType = DetailType.Property, OwnerId = guids[11]},
                new Detail{ Id = Guid.NewGuid(), Name = "Water change", Description="weakly %25 water change", Date = DateTime.UtcNow.AddDays(-7), DetailType = DetailType.Property, OwnerId = guids[11]},
                new Detail{ Id = Guid.NewGuid(), Name = "Water change", Description="weakly %50 water change", Date = DateTime.UtcNow.AddDays(-14), DetailType = DetailType.Property, OwnerId = guids[11]},

            };
            foreach (var item in detailList)
            {
                detailRepository.InsertDetail(item);
            }
            /* Detail TABLE END*/

            /* IncomeOrExpense TABLE */
            incomeOrExpenseRepository.DeleteAll();
            List<IncomeOrExpense> incomeAndExpensesList = new List<IncomeOrExpense>
            {
                new IncomeOrExpense{ Id = Guid.NewGuid(), Name = "Income 1", Cost = 100, IncomeFlag = true, Date = DateTime.UtcNow.AddDays(-10).AddHours(-5), UserId = guids[10] },
                new IncomeOrExpense{ Id = Guid.NewGuid(), Name = "Income 2", Cost = 50, IncomeFlag = true, Date = DateTime.UtcNow.AddDays(-7).AddHours(-12), UserId = guids[10] },
                new IncomeOrExpense{ Id = Guid.NewGuid(), Name = "Expense 1", Cost = 75, IncomeFlag = false, Date = DateTime.UtcNow.AddDays(-5).AddHours(-2), UserId = guids[10] },
                new IncomeOrExpense{ Id = Guid.NewGuid(), Name = "Income 3", Cost = 30, IncomeFlag = true, Date = DateTime.UtcNow.AddDays(-8).AddHours(-1), UserId = guids[10] },
                new IncomeOrExpense{ Id = Guid.NewGuid(), Name = "Expense 2", Cost = 55, IncomeFlag = false, Date = DateTime.UtcNow.AddDays(-2).AddHours(-2), UserId = guids[10] },
            };
            foreach (var item in incomeAndExpensesList)
            {
                incomeOrExpenseRepository.InsertIncomeOrExpense(item);
            }
            /* IncomeOrExpense TABLE END*/

            Preferences.Set("initialize", false);
        }
    }
}
