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
    public class SkillAreaManager:ISkillAreaService
    {
        ISkillAreaDal _skillAreaDal;

        public SkillAreaManager(ISkillAreaDal skillAreaDal)
        {
            _skillAreaDal = skillAreaDal;
        }

        public SkillArea GetByIdSkillArea(int id)
        {
            return _skillAreaDal.Get(x => x.SkillAreaId == id);
        }

        public List<SkillArea> GetList()
        {
            return _skillAreaDal.List();
        }

        public void SkillAreaAdd(SkillArea skillArea)
        {
            _skillAreaDal.Insert(skillArea);
        }

        public void SkillAreaDelete(SkillArea skillArea)
        {
            _skillAreaDal.Delete(skillArea);
        }

        public void SkillAreaUpdate(SkillArea skillArea)
        {
            _skillAreaDal.Update(skillArea);
        }
    }
}
