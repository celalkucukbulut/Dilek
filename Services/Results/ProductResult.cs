using Domain.Domains;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Results
{
    public class ProductResult
    {
        public IEnumerable<Images> Images { get; set; }
        public IEnumerable<Contents> Contents { get; set; }
        public Gender Gender { get; set; }
    }
}
