using PortalKsiazkowy.Models;

namespace PortalKsiazkowy.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!; // Może być null, gdy użytkownik jest usuwany
        public int BookId { get; set; }
        public Book Book { get; set; } = null!; // Może być null w przypadku usunięcia książki
        public string Content { get; set; } = string.Empty; // Treść recenzji
        public int Rating { get; set; } // Ocena książki
    }
}