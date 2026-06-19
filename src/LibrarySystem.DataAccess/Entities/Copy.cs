using LibrarySystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Entities
{
    public class Copy
    {

            public  int Id { get; set; }
            public required int NumberOfCopies { get; set; }

            public required int Status { get; set; }


            public required int BookId { get; set; }
            public List<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
            public Book Book { get; set; }






        }
    
}
