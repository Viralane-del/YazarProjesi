using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmını boş geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj kısmını boş geçemezsiniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");
        }
    }
}
