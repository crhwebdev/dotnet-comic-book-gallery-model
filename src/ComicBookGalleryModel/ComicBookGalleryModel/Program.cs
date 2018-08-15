using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

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

                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBookId = 1;

                //var comicBook1 = context.ComicBooks.Find(comicBookId);
                //var comicBook2 = context.ComicBooks.Find(comicBookId);

                var comicBook1 = context.ComicBooks
                    .Include(comicBook => comicBook.Series)
                    .Include(ComicBook => ComicBook.Artists.Select(artist => artist.Artist))
                    .Include(comicBook => comicBook.Artists.Select(artist => artist.Role))
                    .SingleOrDefault(cb => cb.Id == comicBookId); //FirstOrdDefault, Single, First


                Debug.WriteLine("Changing the Descirption property value.");
                comicBook1.Description = "New value!";

                var comicBook2 = context.ComicBooks
                    .SingleOrDefault(cb => cb.Id == comicBookId); //FirstOrdDefault, Single, First


                //var comicBooks = context.ComicBooks
                //    .Include(comicBook => comicBook.Series)
                //    .Include(ComicBook => ComicBook.Artists.Select(artist => artist.Artist))
                //    .Include(comicBook => comicBook.Artists.Select(artist => artist.Role))
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    if(comicBook.Series == null)
                //    {
                //        context.Entry(comicBook)
                //            .Reference(cb => cb.Series)
                //            .Load();                            
                //    }

                //    var artistRoleNames = comicBook.Artists
                //        .Select(artist => $"{artist.Artist.Name} - {artist.Role.Name}").ToList();
                //    var artistRolesDisplayText = string.Join(", ", artistRoleNames);
                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistRolesDisplayText);
                //}

                Console.ReadLine();
                
            } 

        }
    }
}
