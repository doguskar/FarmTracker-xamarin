using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Pic { get; set; }
        public bool EndPointFlag { get; set; }
        public Guid SuperCategoryId{ get; set; }
    }
}
