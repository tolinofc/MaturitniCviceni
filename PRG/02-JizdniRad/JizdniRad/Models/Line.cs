namespace JizdniRad.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }

        public List<LineStop> LineStops { get; set; }
    }
}
