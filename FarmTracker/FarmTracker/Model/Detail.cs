﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class Detail
    {

        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public decimal Cost { get; set; }
        public DateTime? RemainderDate { get; set; }
        public DateTime? RemainderCompletedDate { get; set; }
        public DetailType? DetailType { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid OwnerId { get; set; }

        public string Image { get; set; }
        public bool IncomeFlag { get; set; }
        public bool AddIncomeOrExpenseFlag { get; set; }

    }
}
