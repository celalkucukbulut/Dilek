using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fifm.Services.Filters
{
    public interface ITableFilter : IPagedServiceRequest, IPageFilter, IOrderFilter
    {
        int DrawIndex { get; set; }
    }
}