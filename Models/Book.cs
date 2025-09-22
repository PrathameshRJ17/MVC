using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_core_empty_controler__Day_3_.Models
{
    public class Book
    {
        [Key]
        public int bookid { get; set; }

        public string title { get; set; }

        public decimal price { get; set; }

        public DateOnly Publicationyear { get; set; }

        public int authid { get; set; }
        //navigation property
        [ForeignKey("authid")]

        public Author author { get; set; }
        

    }
}
