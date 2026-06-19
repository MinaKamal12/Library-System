using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Entities
{
    public class User
    {
        public  int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required int PhoneNumber { get; set; }
        public required double Balance { get; set; }

        public List<Borrowing> Borrowings { get; set; } = new List<Borrowing>();


    }
}
