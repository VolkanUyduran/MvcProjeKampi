using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface ISkillAreaService
    {
        SkillArea GetByIdSkillArea(int id);
        List<SkillArea> GetList();
        void SkillAreaAdd(SkillArea skillArea);
        void SkillAreaDelete(SkillArea skillArea);
        void SkillAreaUpdate(SkillArea skillArea);
    }
}
