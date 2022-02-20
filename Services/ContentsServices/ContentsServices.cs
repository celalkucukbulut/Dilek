using AutoMapper;
using Core.Services.Interfaces;
using Domain.Domains;
using Infrastructure.Interfaces;
using Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ContentsServices
{
    public class ContentsServices : IContentsServices
    {
        private readonly IContentsRepository _contentsRepository;

        public ContentsServices(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }

      

        public ContactResult getAllContactContents()
        {
            var contents = _contentsRepository.getAllContactContents();
            
            Mapper.Initialize(config => { config.CreateMap<IEnumerable<Contents>, ContactResult>().ForMember(x => x.Contents, y => y.MapFrom(z => z)); });
            var result = Mapper.Map<IEnumerable<Contents>, ContactResult>(contents);

            return result;
        }

        public IEnumerable<Contents> getAllContents()
        {
            var contents = _contentsRepository.GetList();
            return contents;
        }

        public IEnumerable<Contents> getAllContentsByDBCode(int dbCode)
        {
            var contents = _contentsRepository.getAllContentsByDBCode(dbCode);
            return contents;
        }

        public IEnumerable<Contents> getAllProductContents()
        {
            var contents = _contentsRepository.getAllProductContents();
            return contents;
        }

        public bool UpdateContent(Contents content)
        {
            try
            {
                content.ModifyDate = DateTime.Now;
                _contentsRepository.Update(content);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool DeleteContent(int id)
        {
            try
            {
                _contentsRepository.Delete(new Contents { ID = id });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddText(string title, string text,int dbCode)
        {
            Contents newContent = new Contents();
            newContent.CreatedDate = DateTime.Now;
            newContent.DBCode = dbCode;
            newContent.Text = text;
            newContent.Title = title;
            try
            {
                _contentsRepository.Add(newContent);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
