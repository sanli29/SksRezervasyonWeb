using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Kutuphane;

namespace SksRezervasyon.Business.FluentValidation.Kutuphane
{
    public class KutuphaneRezervasyonListeleValidator : AbstractValidator<KutuphaneRezervasyonListeleRequestDTO>
    {

        public KutuphaneRezervasyonListeleValidator()
        {
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId boş olamaz");
        }
    }
}
