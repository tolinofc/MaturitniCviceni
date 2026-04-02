using ServisniProtokolCv.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisniProtokolCv.Models
{
    public class Customer : IHtmlExportable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string ICO { get; set; }

        public string ExportHTML()
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<div id='zakaznik'>");
            html.AppendLine("<h2>Zákazník</h2>");
            html.AppendLine($"<div>Název: {Name}</div>");
            html.AppendLine($"<div>Adresa: {Address}</div>");
            html.AppendLine($"<div>PSČ: {PostalCode}</div>");
            html.AppendLine($"<div>IČ: {ICO}</div>");
            html.AppendLine($"</div>");

            return html.ToString();
        }
        public string ExportCSS()
        {
            return "div#zakaznik { border:1px solid black; margin:1em; padding:1em; width:40%; float:left; }";
        }

    }
}
