using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
   public class TalentValidator:AbstractValidator<Talent>
    {
        public TalentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı alanı boş bırakılamaz");
            RuleFor(x => x.Name).NotNull().WithMessage("Yetenek adı alanı boş bırakılamaz");
            RuleFor(x => x.Percent).NotEmpty().WithMessage("Yetenek seviyesi alanı boş bırakılamaz.");
            RuleFor(x => x.Percent).NotNull().WithMessage("Yetenek seviyesi alanı boş bırakılamaz.");
        }
    }
}
