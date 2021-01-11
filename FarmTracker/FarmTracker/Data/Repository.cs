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
            new User {Id = 0 , Username = "doguskar", Email = "dogus.kar@hotmail.com", Password = "123123", Name = "Doğuş", Surname = "Kar", Phone = "+90 555 555 55 55"},
            new User {Id = 1 , Username = "doguskar1", Email = "dogus.kar1@hotmail.com", Password = "123123", Name = "Doğuş", Surname = "Kar", Phone = "+90 555 555 55 55"},
        };
        public static List<Add> Adds = new List<Add>
        {
            new Add { Id = 0, Name = "Blue Dolphine", Image1="bd.jpg", Price="$100", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 1, Name = "Elecric Yellow", Image1="ey.jpg", Price="$200", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 2, Name = "Tetra Discus", Image1="td.jpg", Price="$150", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
            new Add { Id = 4, Name = "Airpump", Image1="ap.jpg", Price="$75", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, deleniti laborum eius suscipit fugit voluptatibus omnis. Aspernatur animi numquam corporis autem saepe minus perferendis voluptatem illo. Tempora doloremque, minima quas libero dolor quisquam maiores doloribus, impedit ipsa facere quia provident, repellat veritatis asperiores quibusdam dolore distinctio quod molestias suscipit nostrum nobis voluptatibus! Voluptatum porro repellat, consequatur modi sit autem nisi, maxime aperiam est assumenda perspiciatis iusto iure ea veritatis molestiae voluptate voluptas. Optio exercitationem ullam eligendi animi incidunt voluptas commodi nemo aliquam vel tempora ad voluptatum, voluptatibus quis rem culpa provident, rerum officiis, quos eaque praesentium fugit debitis sequi blanditiis.", Owner =  Users.Find(e => e.Username == "doguskar")},
        };

        static Repository()
        {
            
        }
    }
}
