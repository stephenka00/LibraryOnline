using LibraryModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Models.BookViewModel
{
    public class BookViewModel
    {
       
        public int BookID { get; set; }
        
        public string Title { get; set; }
       
        public string Description { get; set; }
       
        public string CoverImage { get; set; }
        
        public string Language { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        public int Length { get; set; }
        
        public string CategoryName { get; set; }
    }
}
