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
            new User {Id = 0 , Username = "doguskar", Email = "dogus.kar@hotmail.com", Password = "123123", FullName = "Doğuş Kar", Image = "profil2.jpg", Phone = "+90 555 555 55 55"},
            new User {Id = 1 , Username = "doguskar1", Email = "dogus.kar1@hotmail.com", Password = "123123", FullName = "Doğuş Kar", Image = "profil.jpg", Phone = "+90 555 555 55 55"},
        };
        public static List<Add> Adds = new List<Add>
        {
            new Add { Id = 0, Name = "Angle", Image1="bd.jpg", Price="$100", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 1, Name = "Elecric Yellow", Image1="ey.jpg", Price="$200", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 2, Name = "Tetra Discus", Image1="td.jpg", Price="$150", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 4, Name = "Airpump", Image1="ap.jpg", Price="$75", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 0, Name = "Blue Dolphine", Image1="bd.jpg", Price="$100", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 1, Name = "Elecric Yellow", Image1="ey.jpg", Price="$200", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 2, Name = "Tetra Discus", Image1="td.jpg", Price="$150", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 4, Name = "Airpump", Image1="ap.jpg", Price="$75", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
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
        public static List<Collaborator> Collaborators = new List<Collaborator>
        {
            new Collaborator { User = Users.Find(e => e.Id == 0), RoleName = "Manager"},
            new Collaborator { User = Users.Find(e => e.Id == 1), RoleName = "Formen"},
            new Collaborator { User = Users.Find(e => e.Id == 0), RoleName = "Manager"},
            new Collaborator { User = Users.Find(e => e.Id == 1), RoleName = "Formen"},
            new Collaborator { User = Users.Find(e => e.Id == 0), RoleName = "Manager"},
            new Collaborator { User = Users.Find(e => e.Id == 1), RoleName = "Formen"},
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
