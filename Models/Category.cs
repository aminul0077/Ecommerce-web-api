using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project1.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
     
    };
}