using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifm.Services.Filters
{
    public interface IPageFilter : IFilter
    {
        int? PageIndex { get; set; }
        int? PageSize { get; set; }
    }
}
