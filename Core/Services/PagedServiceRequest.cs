using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PagedServiceRequest : IPagedServiceRequest
    {
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
    }
}
