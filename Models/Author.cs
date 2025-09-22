using System.ComponentModel.DataAnnotations;

namespace EF_core_empty_controler__Day_3_.Models
{
    public class Author
    {
        [Key]
        public int authid { get; set; }

        public string? authname { get; set; }
        //navigation property(can show relation of models)
        public ICollection<Book> Books { get; set; }

    }
}
