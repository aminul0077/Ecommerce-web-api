using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project1.Models.DTOs
{
    public class CategoryReadDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
     
    }
}