using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }
        //This is the primary key for ComicBook
        public int Id { get; set; }
        //This property creates a link (relation) between the ComicBook table and the Series table
        //[ForeignKey("SeriesRefId")]
        public int SeriesId { get; set; }       
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        //navigation property (to link ComicBook to Series using one-to-many)
        public Series Series { get; set; }

        //navigation property (to link ComicBook to Artist using for many-to-many) 
        public ICollection<ComicBookArtist> Artists { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }
    }
}
