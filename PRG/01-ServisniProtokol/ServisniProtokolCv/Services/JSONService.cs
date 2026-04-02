using ServisniProtokolCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServisniProtokolCv.Services
{
    public class JSONService
    {
        public void Save(Protocol protocol, string path)
        {
            string data = JsonSerializer.Serialize(protocol);

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(data);
            }
        }

        public Protocol Load(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                Protocol loadedProtocol = JsonSerializer.Deserialize<Protocol>(reader.ReadToEnd());

                return loadedProtocol;
            }
        }
    }
}
