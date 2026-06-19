namespace LibrarySystem.Domain.Dtos
{
    public class BorrowingDto
    {
        public required DateTime BorrowedDate { get; set; }
        public required DateTime ReturnDate { get; set; }
        public required string UserName { get; set; }
        public required string BookName { get; set; }
        public required int CopyId { get; set; }
        public required int UserId { get; set; }
        public required float BorrowPrice { get; set; }
        
    }
}