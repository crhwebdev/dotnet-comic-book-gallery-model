using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    //This class interacts with Entity Framework.
    public class Context : DbContext
    {
        public Context()
        {
            //drops and initializes the database everytime the model changes
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());

            Database.SetInitializer(new DatabaseInitializer());
        }

        //add a DbSet property for each model in the database to create a table for that model
        public DbSet<ComicBook> ComicBooks { get; set; }

        // can place a connection string as an argument to Context base class constructor or configure in in the App.config file.
        // We will use the App.config file, but syntax would look like
        // public Context() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComicBookGalleryConnectionString;Integrated Security=True;MultipleActiveResultSets=True"){}
            
        //override method on base class to change some conventions used by modelBuilder
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove convention that uses plural names of classes to create tables
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //change decimal precision used by ComicBook.AverageRating
            modelBuilder.Entity<ComicBook>()
                        .Property(comicBook => comicBook.AverageRating)
                        .HasPrecision(5, 2);
        }
    }
}
