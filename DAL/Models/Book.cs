using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BookCover { get; set; }

        public string YearPublication { get; set; }
        public int NumberPages { get; set; }
        public long Isbn { get; set; }


        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public string UploadBook { get; set; }
        public int DownloadNumber { get; set; } 
        public int ReadingNumber { get; set; } 
    }
}