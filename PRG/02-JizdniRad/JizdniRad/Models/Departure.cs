namespace JizdniRad.Models
{
    public class Departure
    {
        public int Id { get; set; }

        public int LineId { get; set; }
        public Line Line { get; set; }

        public TimeOnly DepartureTime { get; set; }
        public int DayType { get; set; }
    }
}
