using FarmTracker.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Data
{
    public static class Repository
    {
        public static List<User> Users = new List<User>
        {
            new User {Id = Guid.NewGuid(), Username = "doguskar", Email = "dogus.kar@hotmail.com", Password = "123123", FullName = "Doğuş Kar", Image = "profil2.jpg", Phone = "+90 555 555 55 55"},
            new User {Id = Guid.NewGuid(), Username = "doguskar1", Email = "dogus.kar1@hotmail.com", Password = "123123", FullName = "Doğuş Kar", Image = "profil.jpg", Phone = "+90 555 555 55 55"},
        };
        public static List<Property> Properties = new List<Property>
        {
            new Property {Name = "Main Aquarium", Description="120x65x45 Tank", Image="animal_property2.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
            new Property {Name = "Plant Aquarium", Description="60x60x60 Tank", Image="plant_property2.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
            new Property {Name = "Ranch", Description="Ranch desc", Image="animal_property1.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
            new Property {Name = "Field", Description="My Field", Image="plant_property1.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
        };
        public static List<Product> Products = new List<Product>
        {
            new Product {Name = "2x Aquarium"},
            new Product {Name = "2x Airpump"},
            new Product {Name = "1x External Filter"},
            new Product {Name = "1x Tetra Discus"},
            new Product {Name = "2x Aquarium"},
            new Product {Name = "2x Airpump"},
            new Product {Name = "1x External Filter"},
            new Product {Name = "1x Tetra Discus"},
            new Product {Name = "2x Aquarium"},
            new Product {Name = "2x Airpump"},
            new Product {Name = "1x External Filter"},
            new Product {Name = "1x Tetra Discus"},
        };
        public static List<IncomeOrExpense> IncomeAndExpenses = new List<IncomeOrExpense>
        {
            new IncomeOrExpense {Name = "Patient", Cost="$35", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
            new IncomeOrExpense {Name = "Food", Cost="$150", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "Airpump", Cost="$70", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
            new IncomeOrExpense {Name = "Patient", Cost="$35", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
            new IncomeOrExpense {Name = "Food", Cost="$150", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "Airpump", Cost="$70", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
            new IncomeOrExpense {Name = "Patient", Cost="$35", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
            new IncomeOrExpense {Name = "Food", Cost="$150", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "Airpump", Cost="$70", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
            new IncomeOrExpense {Name = "Patient", Cost="$35", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
            new IncomeOrExpense {Name = "Food", Cost="$150", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "Airpump", Cost="$70", Image="moneybag2.jpg", IncomeFlag = false},
            new IncomeOrExpense {Name = "25x Babies sold", Cost="$25", Image="moneybag1.jpg", IncomeFlag = true},
        };
        public static List<Entity> Entities = new List<Entity>
        {
            new Entity {Name = "Blue Dolphine", Id="ID: 1", Image="blue_dolphin.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
            new Entity {Name = "Guppy", Id="ID: 2", Image="guppy.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
            new Entity {Name = "Chicken", Id="ID: 3", Image="animal1.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
            new Entity {Name = "Sheep", Id="ID: 4", Image="animal4.jpg", LastModifiedDate = "Last Modified: 2020-01-11 20:04"},
        };
        public static List<MyPropertyDetail> PropertyDetails = new List<MyPropertyDetail>
        {
            new MyPropertyDetail {Name = "Water Changes", Image="document.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Income", Image="moneybag1.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Expense", Image="moneybag2.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Alarm | 2021-01-20 07:00", Image="alarmclock.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Note", Image="document.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Water Changes", Image="document.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Income", Image="moneybag1.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Expense", Image="moneybag2.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Alarm | 2021-01-20 07:00", Image="alarmclock.jpg", Date = "Date: 2020-01-11 20:04"},
            new MyPropertyDetail {Name = "Note", Image="document.jpg", Date = "Date: 2020-01-11 20:04"},
        };


        static Repository()
        {
            
        }
    }
}
