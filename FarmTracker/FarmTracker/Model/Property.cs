﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class Property
    {
        [PrimaryKey]
        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public DateTime LastModifiedDate{ get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public string Image { get; set; }

    }
}
