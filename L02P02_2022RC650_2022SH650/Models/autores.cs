using System.ComponentModel.DataAnnotations;

namespace L02P02_2022RC650_2022SH650.Models
{
    public class autores
    {
        [Key]
        public int id { get; set; }
        public string autor { get; set; }
    }
}
