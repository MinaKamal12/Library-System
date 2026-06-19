using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Domain.Dtos
{
    public class CopyDto
    {
        public required int NumberOfCopies { get; set; }
        public required int Status { get; set; }
        public required int BookId { get; set; }
        public required string BookName { get; set; }
    }
}
