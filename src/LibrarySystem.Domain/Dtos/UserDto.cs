using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Domain.Dtos
{
    public class UserDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required int PhoneNumber { get; set; }
        public required double Balance { get; set; }

    }
}
