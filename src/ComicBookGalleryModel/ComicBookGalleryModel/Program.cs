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
                var series1 = new Series()
                {
                    Title = "The Amazing Spider-Man"
                };

                var series2 = new Series()
                {
                    Title = "The Invnicible Iron Man"
                };

                var artist1 = new Artist()
                {
                    Name = "Stan Lee"
                };


                var artist2 = new Artist()
                {
                    Name = "Steve Ditko"
                };

                var artist3 = new Artist()
                {
                    Name = "Jack Kirby"
                };

                var role1 = new Role()
                {
                    Name = "Script"
                };

                var role2 = new Role()
                {
                    Name = "Pencils"
                };

                var comicBook1 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                comicBook1.AddArtist(artist1, role1);
                comicBook1.AddArtist(artist2, role2);
               
                var comicBook2 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };

                comicBook2.AddArtist(artist1, role1);
                comicBook2.AddArtist(artist2, role2);
                              
                var comicBook3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                comicBook3.AddArtist(artist1, role1);
                comicBook3.AddArtist(artist3, role2);

                
                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);

                context.SaveChanges();

                var comicBooks = context.ComicBooks
                                        .Include(comicBook => comicBook.Series)
                                        .Include(ComicBook => ComicBook.Artists.Select(artist => artist.Artist))
                                        .Include(comicBook => comicBook.Artists.Select(artist => artist.Role))
                                        .ToList();

                foreach(var comicBook in comicBooks)
                {
                    var artistRoleNames = comicBook.Artists
                        .Select(artist => $"{artist.Artist.Name} - {artist.Role.Name}").ToList();
                    var artistRolesDisplayText = string.Join(", ", artistRoleNames);
                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }

                Console.ReadLine();
                
            } 

        }
    }
}
