using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        ImageFile GetByIdImageFile(int id);
        void ImageAdd(ImageFile imageFile);
        void ImageDelete(ImageFile imageFile);
        void ImageUpdate(ImageFile imageFile);
    }
}
