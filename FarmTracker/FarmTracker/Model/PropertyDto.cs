using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    class PropertyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
