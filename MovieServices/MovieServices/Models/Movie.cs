using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieServices.Models
{
    public class Movie
    {
      
       
        public string Name { get; set; }

       
        public int Rating { get; set; }

        public int Release_Year { get; set; }

       
        public string Movie_Img { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

       
        public string Movie_Trailer { get; set; }
    }
}