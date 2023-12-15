using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CoverImage { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public int Length { get; set; }
        [ForeignKey("AuthorID")]
        public Author Authors { get; set; }
        [ForeignKey("GenreID")]
        public Genre Genres { get; set; }
        [ForeignKey("CategoryID")]
        public Category Categories { get; set; }
    }
}
