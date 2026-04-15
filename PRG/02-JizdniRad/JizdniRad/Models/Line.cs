using System.ComponentModel.DataAnnotations.Schema;

namespace JizdniRad.Models
{
    [Table("Line")]
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
    }
}
