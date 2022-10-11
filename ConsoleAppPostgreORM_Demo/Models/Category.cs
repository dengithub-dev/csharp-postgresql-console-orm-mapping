using System;
using System.Collections.Generic;

namespace ConsoleAppPostgreORM_Demo.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime LastUpdate { get; set; }
    }
}
