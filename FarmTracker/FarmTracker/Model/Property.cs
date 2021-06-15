using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class Property
    {
        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public DateTime LastModifiedDate{ get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        
        public Category Category { get; set; }
        public User User { get; set; }
        public List<Entity> Entities { get; set; }


    }
}
