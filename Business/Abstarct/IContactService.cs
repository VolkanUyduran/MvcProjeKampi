using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IContactService
    {
        List<Contact> GetList();
        Contact GetById(int id);
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);

    }
}
