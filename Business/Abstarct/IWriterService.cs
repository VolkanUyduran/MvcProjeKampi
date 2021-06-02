using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IWriterService
    {
        List<Writer> GetList();
        Writer GetById(int id);
        void Add(Writer writer);
        void Delete(Writer writer);
        void Update(Writer writer);
    }
}
