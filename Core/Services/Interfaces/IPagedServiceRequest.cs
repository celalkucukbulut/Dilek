using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IPagedServiceRequest: IServiceRequest
    {
        int? PageSize { get; set; }
        int? PageIndex { get; set; }
    }
}
