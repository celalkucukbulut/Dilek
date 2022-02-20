using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifm.Services.Filters
{
    public interface IOrderFilter : IFilter
    {
        string OrderColumn { get; set; }
        string OrderDirection { get; set; }
    }
}
