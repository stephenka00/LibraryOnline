using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        [ForeignKey("user_id")]
        public User UserID { get; set; }
        [ForeignKey("BookID")]
        public Book BookID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
