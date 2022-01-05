using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Yemekhane;

namespace SksRezervasyon.Business.FluentValidation.Yemekhane
{
    public class YemekhaneRezervasyonYapValidator : AbstractValidator<YemekhaneRezervasyonYapRequestDTO>
    {

        public YemekhaneRezervasyonYapValidator()
        {
            RuleFor(m => m.Tarih).NotEmpty().WithMessage("Tarih boş olamaz");
            RuleFor(m => m.Ogun).NotEmpty().WithMessage("Ogun boş olamaz");
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId boş olamaz");
            RuleFor(m => m.IsRandevu).NotEmpty().WithMessage("IsRandevu boş olamaz");
            RuleFor(m => m.Fiyat).NotEmpty().WithMessage("Fiyat boş olamaz");
        }
    }
}
