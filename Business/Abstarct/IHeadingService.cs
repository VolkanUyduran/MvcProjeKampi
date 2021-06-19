using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
   public  interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter();
        Heading GetById(int id);
        void Active(Heading heading);
        void Add(Heading heading);
        void Delete(Heading heading);
        void Update(Heading heading);
    }
}
