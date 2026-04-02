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
        public double Open { get; set; }
        public long Volume { get; set; }
    }
}
