using Core.Services.Interfaces;
using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MessagesServices
{
    public interface IMessagesServices : IService
    {
        bool InsertMessage(Messages message);
        IEnumerable<Messages> ShowMessages();
    }
}
