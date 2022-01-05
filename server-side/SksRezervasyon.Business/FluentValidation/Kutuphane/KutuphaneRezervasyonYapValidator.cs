using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Kutuphane;

namespace SksRezervasyon.Business.FluentValidation.Kutuphane
{
    public class KutuphaneRezervasyonYapValidator : AbstractValidator<KutuphaneRezervasyonYapRequestDTO>
    {

        public KutuphaneRezervasyonYapValidator()
        {
            RuleFor(m => m.Tarih).NotEmpty().WithMessage("Tarih boş olamaz");
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId boş olamaz");
            RuleFor(m => m.OdaNo).NotEmpty().WithMessage("OdaNo boş olamaz");
            RuleFor(m => m.BaslangicSaati).NotEmpty().WithMessage("BaslangicSaati boş olamaz");
        }
    }
}
