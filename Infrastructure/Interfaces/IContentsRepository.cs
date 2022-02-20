using Core.Repositories;
using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IContentsRepository : IRepository<Contents>
    {
        IEnumerable<Contents> getAllContentsByDBCode(int dbCode);
        IEnumerable<Contents> getAllContactContents();
        IEnumerable<Contents> getAllProductContents();
    }
}
