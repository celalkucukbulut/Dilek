using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifm.Services.Filters
{
    public class ExportFilter : IExportFilter
    {
        public int? ID { get; set; }
        public int PageCount { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
