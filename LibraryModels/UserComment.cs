using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class UserComment
    {
        [Key]
        public int CommentID { get; set; }
        [ForeignKey("user_id")]
        public User UserID { get; set; }
        [ForeignKey("user_id")]
        public User TargetUserID { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
