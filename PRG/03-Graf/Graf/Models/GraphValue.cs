using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf.Models
{
    public class GraphValue
    {
        public DateOnly Date { get; set; }
        public float Open { get; set; }
        public bool isOpenNegative { get; set; } = false;
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }

        public long Volume { get; set; }
    }
}
