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
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public Talent GetByID(int id)
        {
            return _talentDal.Get(x => x.SkillId == id);
        }

        public List<Talent> GetList()
        {
            return _talentDal.List();
        }

        public void TalentAdd(Talent talent)
        {
            _talentDal.Insert(talent);
        }

        public void TalentDelete(Talent talent)
        {
            _talentDal.Delete(talent);
        }

        public void TalentUpdate(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}
