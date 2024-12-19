using Microsoft.AspNetCore.Identity;
using PortalKsiazkowy;
using PortalKsiazkowy.Models;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Tworzenie ról: Admin, User
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        // Dodanie administratora
        if (await userManager.FindByNameAsync("admin") == null)
        {
            var admin = new User
            {
                UserName = "admin",
                Email = "admin@example.com",
                FullName = "Administrator",
                Role = "Admin"
            };

            var result = await userManager.CreateAsync(admin, "Admin@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
                Console.WriteLine("Admin user created and added to role Admin"); // Debugowanie
            }

        }

        // Dodanie książek, jeśli baza jest pusta
        if (!context.Books.Any())
        {
            context.Books.AddRange(
                new Book { Title = "Władca Pierścieni", Author = "J.R.R. Tolkien", Genre = "Fantasy", PublishedDate = new DateTime(1954, 7, 29), ImageUrl = "https://fwcdn.pl/fpo/10/65/1065/8071180_1.10.webp" },
                new Book { Title = "Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", PublishedDate = new DateTime(1937, 9, 21) },
                new Book { Title = "Harry Potter i Kamień Filozoficzny", Author = "J.K. Rowling", Genre = "Fantasy", PublishedDate = new DateTime(1997, 6, 26) },
                new Book { Title = "Harry Potter i Komnata Tajemnic", Author = "J.K. Rowling", Genre = "Fantasy", PublishedDate = new DateTime(1998, 7, 2) },
                new Book { Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski", Genre = "Literatura klasyczna", PublishedDate = new DateTime(1866, 1, 1) },
                new Book { Title = "Duma i uprzedzenie", Author = "Jane Austen", Genre = "Romans", PublishedDate = new DateTime(1813, 1, 28) },
                new Book { Title = "Mistrz i Małgorzata", Author = "Michaił Bułhakow", Genre = "Literatura rosyjska", PublishedDate = new DateTime(1967, 1, 1) },
                new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopia", PublishedDate = new DateTime(1949, 6, 8) },
                new Book { Title = "Wielki Gatsby", Author = "F. Scott Fitzgerald", Genre = "Literatura amerykańska", PublishedDate = new DateTime(1925, 4, 10) },
                new Book { Title = "Sto lat samotności", Author = "Gabriel García Márquez", Genre = "Magiczny realizm", PublishedDate = new DateTime(1967, 5, 30) },
                new Book { Title = "Moby Dick", Author = "Herman Melville", Genre = "Literatura amerykańska", PublishedDate = new DateTime(1851, 11, 14) },
                new Book { Title = "Opowieść wigilijna", Author = "Charles Dickens", Genre = "Świąteczna", PublishedDate = new DateTime(1843, 12, 19) },
                new Book { Title = "Siddhartha", Author = "Hermann Hesse", Genre = "Filozoficzna", PublishedDate = new DateTime(1922, 1, 1) },
                new Book { Title = "Zielona mila", Author = "Stephen King", Genre = "Horror", PublishedDate = new DateTime(1996, 9, 30) },
                new Book { Title = "To", Author = "Stephen King", Genre = "Horror", PublishedDate = new DateTime(1986, 9, 15) },
                new Book { Title = "Dzieci z Bullerbyn", Author = "Astrid Lindgren", Genre = "Literatura dziecięca", PublishedDate = new DateTime(1947, 1, 1) },
                new Book { Title = "Pani Bovary", Author = "Gustave Flaubert", Genre = "Literatura francuska", PublishedDate = new DateTime(1857, 1, 1) },
                new Book { Title = "Czarnoksiężnik z Archipelagu", Author = "Ursula K. Le Guin", Genre = "Fantasy", PublishedDate = new DateTime(1968, 5, 1) },
                new Book { Title = "Pierwsza książka o Rzymie", Author = "Simone Biles", Genre = "Edukacja", PublishedDate = new DateTime(2020, 1, 1) },
                new Book { Title = "Pan Tadeusz", Author = "Adam Mickiewicz", Genre = "Literatura polska", PublishedDate = new DateTime(1834, 1, 1) },
                new Book { Title = "Złodziejka książek", Author = "Markus Zusak", Genre = "Dramat", PublishedDate = new DateTime(2005, 1, 1) },
                new Book { Title = "Zabić drozda", Author = "Harper Lee", Genre = "Literatura amerykańska", PublishedDate = new DateTime(1960, 7, 11) }
            );
            context.SaveChanges(); // Zapisz zmiany w bazie
        }
    }
}
