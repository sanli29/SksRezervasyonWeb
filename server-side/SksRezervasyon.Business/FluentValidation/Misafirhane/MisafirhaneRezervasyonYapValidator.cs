using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Misafirhane;

namespace SksRezervasyon.Business.FluentValidation.Misafirhane
{
    public class MisafirhaneRezervasyonYapValidator : AbstractValidator<MisafirhaneRezervasyonYapRequestDTO>
    {

        public MisafirhaneRezervasyonYapValidator()
        {
            RuleFor(m => m.GirisTarihi).NotEmpty().WithMessage("GirisTarihi boş olamaz");
            RuleFor(m => m.OdaTuru).NotEmpty().WithMessage("OdaTuru boş olamaz");
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId boş olamaz");
        }
    }
}
