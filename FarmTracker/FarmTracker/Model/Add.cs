using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTracker.Model
{
    public class Add
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Price { get; set; }
        public User Owner { get; set; }
    }
}
