using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
   public interface IAboutService
    {
        List<About> GetList();
        About GetById(int id);
        void Add(About about);
        void Delete(About about);
        void Update(About about);
    }
}
