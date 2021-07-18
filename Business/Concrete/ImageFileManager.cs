using Business.Abstarct;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ımageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }

        public ImageFile GetByIdImageFile(int id)
        {
            return _ımageFileDal.Get(x => x.ImageID == id);
        }

        public List<ImageFile> GetList()
        {
            return _ımageFileDal.List();
        }

        public void ImageAdd(ImageFile imageFile)
        {
            _ımageFileDal.Insert(imageFile);
        }

        public void ImageDelete(ImageFile imageFile)
        {
            _ımageFileDal.Delete(imageFile);
        }

        public void ImageUpdate(ImageFile imageFile)
        {
            _ımageFileDal.Update(imageFile);
        }
    }
}
