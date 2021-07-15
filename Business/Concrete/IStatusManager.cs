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
    public class IStatusManager:IStatusService
    {
        IStatusDal _statusDal;

        public IStatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }

        public List<Status> GetList()
        {
            return _statusDal.List();
        }
    }
}
