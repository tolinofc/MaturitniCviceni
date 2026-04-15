using System.ComponentModel.DataAnnotations.Schema;

namespace JizdniRad.Models
{
    [Table("LineStop")]
    public class LineStop
    {
        public int Id { get; set; }

        public int LineId { get; set; }
        public Line Line { get; set; }

        public int StopId { get; set; }
        public Stop Stop { get; set; }

        public int StopOrder { get; set; }
        public int TimeFromPrevious { get; set; }
    }
}
