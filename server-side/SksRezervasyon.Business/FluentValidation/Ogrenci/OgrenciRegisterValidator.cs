using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Ogrenci;

namespace SksRezervasyon.Business.FluentValidation.Ogrenci
{
    public class OgrenciRegisterValidator : AbstractValidator<OgrenciRegisterRequestDTO>
    {

        public OgrenciRegisterValidator()
        {
            RuleFor(m => m.Sifre).NotEmpty().WithMessage("Sifre boş olamaz");
            RuleFor(m => m.Email).EmailAddress().WithMessage("Email hatalı");
            RuleFor(m => m.Adi).NotEmpty().WithMessage("Adi boş olamaz");
        }
    }
}
