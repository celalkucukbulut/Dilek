using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Results
{
    public class ContactResult
    {
        public IEnumerable<Contents> Contents { get; set; }
        public IEnumerable<Messages> Messages { get; set; }
    }
}
