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
    }
}
