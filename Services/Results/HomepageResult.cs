using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Results
{
    public class HomepageResult
    {
        public IEnumerable<Contents> Contents { get; set; }
        public IEnumerable<Images> Images { get; set; }

    }
}
