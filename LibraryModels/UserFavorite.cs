using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class UserFavorite
    {
        [Key]
        public int user_id { get; set; }
        [Key] 
        public int book_id { get; set; }
    }
}
