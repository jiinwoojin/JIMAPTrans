using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIMapTrans.GdalManager.Models
{
    public class GdalRasterFileFormat
    {
        public GdalRasterFileFormat()
        {

        }

        public GdalRasterFileFormat(string longName, string extensions)
        {
            LongName = longName;
            Extensions = extensions;
        }

        public string LongName { get; set; }
        public string Extensions { get; set; }
    }
}
