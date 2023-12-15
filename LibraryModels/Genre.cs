using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Genre
    {
        [Key] 
        public int GenreID { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
