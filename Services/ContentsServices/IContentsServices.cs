using Core.Services.Interfaces;
using Domain.Domains;
using Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ContentsServices
{
    public interface IContentsServices : IService
    {
        IEnumerable<Contents> getAllContents();
        IEnumerable<Contents> getAllContentsByDBCode(int dbCode);
        ContactResult getAllContactContents();
        IEnumerable<Contents> getAllProductContents();
        bool UpdateContent(Contents content);
        bool DeleteContent(int id);
        bool AddText(string title, string text,int dbCode);
    }
}
