using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }
        [ForeignKey("user_id")]
        public User UserID { get; set; }
        [ForeignKey("BookID")]
        public Book BookID { get; set; }
        public int RatingValue { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
