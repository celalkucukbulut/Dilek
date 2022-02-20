using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifm.Services.Filters
{
    public interface IExportFilter : IPageFilter
    {
        int PageCount { get; set; }
    }
}
