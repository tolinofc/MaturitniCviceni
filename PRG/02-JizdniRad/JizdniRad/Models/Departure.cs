using System.ComponentModel.DataAnnotations.Schema;

namespace JizdniRad.Models
{
    [Table("Departure")]
    public class Departure
    {
        public int Id { get; set; }

        public int LineId { get; set; }
        public Line Line { get; set; }

        public DateTime DepartureTime { get; set; }
        public int DayType { get; set; }
    }
}
