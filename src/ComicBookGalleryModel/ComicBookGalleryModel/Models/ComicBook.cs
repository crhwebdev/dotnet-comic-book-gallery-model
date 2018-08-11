using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        //This is the primary key for ComicBook
        public int Id { get; set; }
        //This property creates a link (relation) between the ComicBook table and the Series table
        public Series Series { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }
    }
}
