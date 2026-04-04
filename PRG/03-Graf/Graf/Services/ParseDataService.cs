using Graf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf.Services
{
    public class ParseDataService
    {
        public static List<GraphValue> ParseData(string path)
        {
            List<GraphValue> values = new List<GraphValue>();
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine(); // first line
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');
                    GraphValue value = new GraphValue()
                    {
                        Date = DateOnly.Parse(line[0]),
                        Open = float.Parse(line[1].Replace(".", ",")),
                        High = float.Parse(line[2].Replace(".", ",")),
                        Low = float.Parse(line[3].Replace(".", ",")),
                        Close = float.Parse(line[4].Replace(".", ",")),
                        Volume = long.Parse(line[6].Replace(".", ","))
                    };
                    values.Add(value);
                }
            }

            for (int i = 1; i < values.Count; i++)
            {
                values[i].isOpenNegative = values[i - 1].Open > values[i].Open;
            }

            return values;
        }
    }
}
