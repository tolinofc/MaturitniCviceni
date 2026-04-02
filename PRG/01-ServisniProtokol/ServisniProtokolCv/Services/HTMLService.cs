using ServisniProtokolCv.Interfaces;
using ServisniProtokolCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisniProtokolCv.Services
{
    /*
        cistsi reseni by podle me bylo, kdyby cele html sestavovala service a modely by v sobe nemely metody ExportHTML() a ExportCSS(). Chtel jsem ale dodrzet class diagram v zadani.
    */
    public class HTMLService : IHtmlExportable
    {
        private Protocol protocol;
        public HTMLService(Protocol protocol)
        {
            this.protocol = protocol;
        }
        public string ExportHTML()
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<html xmlns='http://www.w3.org/1999/xhtml' xml:lang='cs'>");
            html.AppendLine("<head>");
            html.AppendLine("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\">");
            html.AppendLine("<style type='text/css'>");
            html.AppendLine(ExportCSS());
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");

            html.AppendLine(protocol.ExportHTML());
            html.AppendLine(protocol.Customer.ExportHTML());
            html.AppendLine(protocol.Device.ExportHTML());

            html.AppendLine("<div id='mereni'>");
            html.AppendLine("<h2>Měření</h2>");
            html.AppendLine("<table>");
            html.AppendLine("<tr> <th>Parametr</th> <th>Naměřená hodnota</th> <th>Vyhovuje</th> </tr>");
            foreach (Measure measure in protocol.MeasureList)
            {
                html.AppendLine(measure.ExportHTML());
            }
            html.AppendLine("</table>");
            html.AppendLine("</div>");
            html.AppendLine($"<div id='zaver'>{protocol.GetResult()}</div>");
            html.AppendLine("</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }

        public string ExportCSS()
        {
            StringBuilder css = new StringBuilder();

            css.AppendLine("h1 { text-align:center; }");
            css.AppendLine("div#zaver { text-align:center; font-weight:bold; font-size:1.2em; }");
            css.AppendLine(protocol.ExportCSS());
            css.AppendLine(protocol.Device.ExportCSS());
            css.AppendLine(protocol.Customer.ExportCSS());
            if (protocol.MeasureList.Count > 0)
            {
                css.AppendLine(protocol.MeasureList[0].ExportCSS());
            }
            css.AppendLine("div#mereni table { width:100%; }");
            css.AppendLine("div#mereni table th { text-align:left; }");

            return css.ToString();
        }

    }
}
