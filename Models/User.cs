using Microsoft.AspNetCore.Identity;

namespace PortalKsiazkowy.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty; // Pełne imię
        public string Role { get; set; } = "User"; // Domyślna rola
        public List<Book> Library { get; set; } = new List<Book>();
    }
}
