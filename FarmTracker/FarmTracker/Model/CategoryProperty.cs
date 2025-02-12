﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class CategoryProperty
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
