using Core.Repositories.Dapper;
using Domain.Domains;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MessagesRepository : DapperRepositoryBase<Messages>, IMessagesRepository
    {
        public MessagesRepository(DapperHelper dapperHelper) : base(dapperHelper)
        {
        }
    }
}
