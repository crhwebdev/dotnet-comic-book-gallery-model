using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    //This class interacts with Entity Framework.
    public class Context : DbContext
    {
        //add a DbSet property for each model in the database to create a table for that model
        public DbSet<ComicBook> ComicBooks { get; set; }

        // can place a connection string as an argument to Context base class constructor or configure in in the App.config file.
        // We will use the App.config file, but syntax would look like
        // public Context() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComicBookGalleryConnectionString;Integrated Security=True;MultipleActiveResultSets=True"){}              
    }
}
