using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name= "Date Watched")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WatchedDate { get; set; }
        public string Genre { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        public string userId { get; set; }

    }
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

    }
}