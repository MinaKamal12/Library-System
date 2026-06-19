using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Entities
{
    public class Borrowing
    {
        public  int Id { get; set; }
        public required DateTime BorrowedDate { get; set; }
        public required DateTime ReturnDate { get; set; }
        public string UserName { get; set; }
        public string BookName { get; set; }
        public required int CopyId { get; set; }
        public required int UserId { get; set; }
        public required float BorrowPrice { get; set; }

        public Copy Copy { get; set; }
        public User User { get; set; }






    }
}

