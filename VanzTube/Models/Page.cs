using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VanzTube.Models
{
    public class Page
    {   
        [Key]
        public int PageId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
