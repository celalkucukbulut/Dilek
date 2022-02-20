using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domains;

namespace Services.ImagesServices
{
    public class ImagesServices : IImagesServices
    {
        #region .ctor
        private readonly IImagesRepository _imagesRepository;
        
        public ImagesServices(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }
        
        #endregion
        public IEnumerable<Images> getAllImages()
        {
            var images = _imagesRepository.GetList();
            return images;
        }
        public bool DeleteImage(int ID)
        {
            try
            {
                _imagesRepository.Delete(new Images { ID = ID });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Images> getAllProducts()
        {
            var images = _imagesRepository.getAllProducts();
            return images;
        }

        public Images getImage(int id)
        {
            var image = _imagesRepository.Get(id);
            return image;
        }
        public IEnumerable<Images> getImagesByDBCodes(int dbCode)
        {
            var images = _imagesRepository.GetByDBCodes(dbCode);
            return images;
        }

        public bool InsertSliderImage(string path,string text)
        {
            var Images = new Images();
            Images.CreatedDate = DateTime.Now;
            Images.DBCode = 8;
            Images.Text = text;
            Images.Code = "Slider" + path;
            path = "~/Images/" + path;
            Images.FilePath = path;
            try
            {
                _imagesRepository.Add(Images);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertImage(string path, string text,int dbCode)
        {
            var Images = new Images();
            Images.CreatedDate = DateTime.Now;
            Images.DBCode = dbCode;
            Images.Text = text;
            Images.Code = "Image" + path;
            path = "~/Images/" + path;
            Images.FilePath = path;
            try
            {
                _imagesRepository.Add(Images);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateImage(int ID, string text, DateTime CreatedDate, int DBCode,string Code,string FilePath)
        {
            try
            {
                _imagesRepository.Update(new Images
                {
                    CreatedDate = CreatedDate,
                    DBCode = DBCode,
                    Code = Code,
                    FilePath = FilePath,
                    ID = ID,
                    ModifyDate = DateTime.Now,
                    Text = text
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
