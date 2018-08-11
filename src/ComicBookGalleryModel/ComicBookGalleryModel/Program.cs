using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
                var series = new Series()
                {
                    Title = "The Amazing Spider-Man"
                };
                

                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });

                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                });

                context.SaveChanges();

                var comicBooks = context.ComicBooks
                                        .Include(comicBook => comicBook.Series)
                                        .ToList();

                foreach(var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }

                Console.ReadLine();
                
            } 

        }
    }
}
