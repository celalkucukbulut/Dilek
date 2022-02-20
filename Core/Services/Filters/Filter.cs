using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fifm.Services.Filters
{
    public abstract class FilterBase : ITableFilter
    {
        public int? ID { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int DrawIndex { get; set; }
        public string OrderColumn { get; set; }
        public string OrderDirection { get; set; }
    }
}