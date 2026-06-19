using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Domain.Dtos
{
    public class BookDto
    {
        public required string Name { get; set; }
        public required string Author { get; set; }
        public string Description { get; set; }
        public required double Price { get; set; }
    }
}
