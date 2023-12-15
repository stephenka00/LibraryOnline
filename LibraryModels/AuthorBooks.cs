using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class AuthorBooks
    {
        [Key]
        public int AuthorID { get; set; }
        [Key]
        public int BookID { get; set; }
    }
}
