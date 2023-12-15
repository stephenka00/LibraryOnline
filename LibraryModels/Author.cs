using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required] 
        public string Name { get; set;}
        [Required]
        public string Biography { get; set;}
        [Required]
        public string ProfileImage { get; set;}
    }
}
