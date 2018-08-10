using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            //must use a 'using' statement because Context inheriets from a class that implements IDisposable
            // and we need to release memory when done using it.  'using' statement is the easiest way to do this.
            using(var context = new Context())
            {
                context.ComicBooks.Add(new ComicBook()
                {
                    SeriesTitle = "The Amazing Spider-Man",
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });

                context.SaveChanges();

                var comicBooks = context.ComicBooks.ToList();

                foreach(var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.SeriesTitle);
                }

                Console.ReadLine();
                
            } 

        }
    }
}
