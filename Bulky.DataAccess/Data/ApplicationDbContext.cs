using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id= 1 , Name = "Akcja" , DisplayOrder = 1},
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Historia", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Przygoda", DisplayOrder = 4 }
                );

            modelBuilder.Entity<Company>().HasData(
               new Company { Id = 1, Name = "Wydawnictwo Helion", StreetAddress = "ul. Kościuszki 1c", City= "Gliwice", PostalCode= "44-100", PhoneNumber= "032 230 98 63", State ="Śląskie" },
               new Company { Id = 2, Name = "OSDW Azymut (KI PWN)", StreetAddress = "Smolice 1H, Hala DE – DOK nr 3", City = "Stryków", PostalCode = "95-010", PhoneNumber = "+48 42 680 44 88", State = "Łódźkie" },
               new Company { Id = 3, Name = "Społeczny Instytut Wydawniczy ZNAK Sp. z o.o.", StreetAddress = "ul. Madalińskiego 9", City = "Kraków", PostalCode = "30-303", PhoneNumber = "(12) 324 97 75", State = "Małopolskie" }
               );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Paddington w Peru.",
                    Author = "Anna Wilson",
                    Description = @"Podróż do Peru to wielka sprawa dla małego niedźwiadka. Nawet dla Paddingtona, który mieszka przecież w wielkim mieście. 
                                    I choć jest już całkiem duży (od niedawna ma nawet prawdziwy paszport), to jednak nadal trzyma pod kapeluszem kanapki z marmoladą.\r\n\r\n
                                    Paddington dostaje list ze straszną wiadomością. Z ciocią Lucy dzieje się coś niedobrego! Pewnie staruszka tęskni za misiem… 
                                    Rodzina Brownów postanawia natychmiast wyruszyć do Peru.\r\n\r\nKto mógłby przypuszczać, że czeka ich podróż życia, pełna niebezpieczeństw, dzikich zwierząt, starych map,
                                    tajemniczych zagadek i niejasnych wskazówek. Bo na miejscu okazuje się, że ciocia Lucy… zniknęła w gąszczu amazońskiej dżungli.",
                    ISBN = "SWD9999001",
                    ListPrice = 58.48,
                    Price = 55,
                    Price50 = 49.5,
                    Price100 = 45,
                    CategoryId = 1,
                    ImageUrl=""
                },
                new Product
                {
                    Id = 2,
                    Title = "Święta z dziadkiem",
                    Author = "Michael Morpurgo",
                    Description = @"Ciepła i pełna nadziei opowieść o potrzebie troski o naszą planetę – nie tylko dla siebie samych, ale również dla następnych pokoleń.
                                    Co roku w święta Mia czyta z rodziną list od nieżyjącego już dziadka. W liście zawarł on wyjątkowe bożonarodzeniowe życzenia dla swojej wnuczki
                                    – żeby dziewczynka mogła żyć w lepszym, czystszym świecie. Czule wspomina wspólne chwile, które spędził z nią w ogrodzie, gdy cieszyli się darami przyrody,
                                    i smuci go, że niestety wszystko, co tak bardzo kochają, jest teraz w niebezpieczeństwie. Zadaniem Mii jest zrobić wszystko, aby dbać o Ziemię i ją chronić.
",
                    ISBN = "CAW777777701",
                    ListPrice = 23.74,
                    Price = 19.99,
                    Price50 = 15.99,
                    Price100 = 13.99,
                    CategoryId = 2,
                    ImageUrl = ""
                });
        }
    }
}
