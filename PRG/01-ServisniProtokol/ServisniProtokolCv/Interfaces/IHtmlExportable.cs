using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisniProtokolCv.Interfaces
{
    public interface IHtmlExportable
    {
        string ExportHTML();
        string ExportCSS();
    }
}
