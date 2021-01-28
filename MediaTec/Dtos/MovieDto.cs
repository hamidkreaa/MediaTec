using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaTec.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime AddDate { get; set; }

        [Range(1, 20)]
        public short NumberInStock { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}