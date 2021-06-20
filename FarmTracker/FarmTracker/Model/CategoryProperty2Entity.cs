using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class CategoryProperty2Entity
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public Guid CategoryPropertyId { get; set; }
        public Guid EntityId { get; set; }
        public string Value { get; set; }
    }
}
