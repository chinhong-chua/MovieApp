using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Release")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [MinNumInStocks]
        //[Range(1, 20)]
        public int NumberInStock { get; set; }
        public Genre Genre{ get; set; }
        [Required]
        public int GenreId { get; set; }


    }
}