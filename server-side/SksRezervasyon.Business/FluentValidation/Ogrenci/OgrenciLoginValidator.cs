using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Ogrenci;

namespace SksRezervasyon.Business.FluentValidation.Ogrenci
{
    public class OgrenciLoginValidator : AbstractValidator<OgrenciLoginRequestDTO>
    {

        public OgrenciLoginValidator()
        {
            RuleFor(m => m.Email).EmailAddress().WithMessage("Email hatalı");
            RuleFor(m => m.Sifre).NotEmpty().WithMessage("Sifre boş olamaz");
        }
    }
}
