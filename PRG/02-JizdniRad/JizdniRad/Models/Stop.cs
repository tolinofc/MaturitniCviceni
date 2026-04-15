using System.ComponentModel.DataAnnotations.Schema;

namespace JizdniRad.Models
{
    [Table("Stop")]
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
