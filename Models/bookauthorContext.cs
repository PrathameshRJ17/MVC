using Microsoft.EntityFrameworkCore;

namespace EF_core_empty_controler__Day_3_.Models
{
    public class bookauthorContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author>Authors { get; set; }

        //constructor
        public bookauthorContext(DbContextOptions<bookauthorContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            //connectionstring
            optionsBuilder.UseSqlServer("data source=DESKTOP-QU6AR53;database=Books&Author;integrated security=true;trustservercertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //model setup   (dummy data will be provided)
            modelBuilder.Entity<Author>()
                .HasData(
                
                new Author() { authid = 11,authname= "Prathamesh" },
                new Author() { authid = 12, authname = "Anna" },
                new Author() { authid = 13, authname = "shetty" }


                );  
            modelBuilder.Entity<Book>()
                .HasData(
                new Book() { bookid = 1, title = "swarg", price = 999, Publicationyear = new DateOnly(2025, 5, 6), authid = 11 },
                new Book() { bookid = 2, title = "shap", price = 500, Publicationyear = new DateOnly(2020, 4, 4), authid = 12 },
                new Book() { bookid = 3, title = "Ganpat", price = 150, Publicationyear = new DateOnly(2020, 5,7), authid = 13 }
                );

        }

    }
}
