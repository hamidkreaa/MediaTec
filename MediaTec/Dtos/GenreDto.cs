﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaTec.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}