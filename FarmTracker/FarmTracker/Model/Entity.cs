using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public DateTime PurchasedDate { get; set; }
        public decimal Cost { get; set; }
        public bool SoldFlag { get; set; }
        public DateTime SoldDate { get; set; }
        public decimal SoldPrice { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public EntityType? EntityType { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
