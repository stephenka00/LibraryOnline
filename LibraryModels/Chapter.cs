using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Chapter
    {
        [Key]
        public int ChapterID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string AudioFile { get; set; }
        [ForeignKey("BookID")]
        public Book Books { get; set; }
    }
}
