namespace PortalKsiazkowy.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }

        public double AverageRating { get; set; } // Średnia ocena
        public int RatingsCount { get; set; } // Liczba oddanych głosów
        public string? ImageUrl { get; set; }  // URL do zdjęcia książki
        // Relacja do recenzji
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}