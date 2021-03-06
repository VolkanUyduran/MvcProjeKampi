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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Active(Heading heading)
        {
            //heading.sta = true;
            _headingDal.Update(heading);
        }

        public void Add(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void Delete(Heading heading)
        {
            
            _headingDal.Update(heading);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByCategory(int id)
        {
            return _headingDal.List(x => x.CategoryId == id);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId ==id);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

    }
}
