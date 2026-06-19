using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Author { get; set; }
        public string Description { get; set; }
        public required double Price { get; set; }
        // public DateTime CreatedDate { get; set; }


        public List<Copy> Copies { get; set; } = new List<Copy>();


    }
}
