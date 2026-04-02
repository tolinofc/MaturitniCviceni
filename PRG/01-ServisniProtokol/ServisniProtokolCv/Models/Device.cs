using ServisniProtokolCv.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServisniProtokolCv.Models
{
    public class Device : IHtmlExportable
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public string ExportHTML()
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<div id='zarizeni'>");
            html.AppendLine("<h2>Zařízení</h2>");
            html.AppendLine($"<div>Výrobce: {Manufacturer}</div>");
            html.AppendLine($"<div>Model: {Model}</div>");
            html.AppendLine($"<div>Sériové číslo: {SerialNumber}</div>");
            html.AppendLine($"</div>");

            return html.ToString();
        }
        public string ExportCSS()
        {
            return "div#zarizeni { border:1px solid black; margin:1em; padding:1em; width:40%; float:right; }";
        }

    }
}
