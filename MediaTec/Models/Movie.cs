using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaTec.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddDate { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        public short NumberInStock { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}