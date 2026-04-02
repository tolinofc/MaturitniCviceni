using ServisniProtokolCv.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisniProtokolCv.Models
{
    public class Protocol : IHtmlExportable
    {
        public string ProtocolNumber { get; set; }
        public DateTime MeasureDate { get; set; } = DateTime.Now;
        public Customer Customer { get; set; } = new Customer();
        public Device Device { get; set; } = new Device();
        public BindingList<Measure> MeasureList { get; set; } = new BindingList<Measure>();

        public bool IsOptimal()
        {
            foreach (Measure measure in MeasureList)
            {
                if (!measure.IsOptimal)
                {
                    return false;
                }
            }

            return true;
        }

        public string ExportHTML()
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<div id='protokol'>");
            html.AppendLine("<h1>Potvrzení o provedení měření</h1>");
            html.AppendLine($"<div id='datum'>Datum měření: {MeasureDate.ToShortDateString()}</div>");
            html.AppendLine($"<div id='cisloProtokolu'>Číslo protokolu: {ProtocolNumber}</div>");

            return html.ToString();
        }

        public string ExportCSS()
        {
            StringBuilder css = new StringBuilder();

            css.AppendLine("div#protokol { margin:2em; border:1px solid black; }");
            css.AppendLine("div#datum { float:left; margin:1em; width:40%;  }");
            css.AppendLine("div#cisloProtokolu { text-align:right; float:right; margin:1em; width:40%; }");

            return css.ToString();
        }

        public string GetResult()
        {
            return IsOptimal() ? "Zařízení je schopné dalšího provozu" : "Zařízení není schopné dalšího provozu";
        }
    }
}
