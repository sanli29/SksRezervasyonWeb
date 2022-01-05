using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Tesi;

namespace SksRezervasyon.Business.FluentValidation.Tesi
{
    public class TesiRezervasyonYapValidator : AbstractValidator<TesiRezervasyonYapRequestDTO>
    {

        public TesiRezervasyonYapValidator()
        {
            RuleFor(m => m.TesisTur).NotEmpty().WithMessage("TesisTur boş olamaz");
            RuleFor(m => m.Tarih).NotEmpty().WithMessage("Tarih boş olamaz");
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId No boş olamaz");
            RuleFor(m => m.BaslangicSaati).NotEmpty().WithMessage("BaslangicSaati boş olamaz");
        }
    }
}
