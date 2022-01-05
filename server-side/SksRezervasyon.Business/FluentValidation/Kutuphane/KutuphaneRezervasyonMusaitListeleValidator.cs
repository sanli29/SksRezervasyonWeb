using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Kutuphane;

namespace SksRezervasyon.Business.FluentValidation.Kutuphane
{
    public class KutuphaneRezervasyonMusaitListeleValidator : AbstractValidator<KutuphaneRezervasyonMusaitListeleRequestDTO>
    {

        public KutuphaneRezervasyonMusaitListeleValidator()
        {
            RuleFor(m => m.OdaNo).NotEmpty().WithMessage("OdaNo boş olamaz");
            RuleFor(m => m.Tarih).NotEmpty().WithMessage("Tarih boş olamaz");
        }
    }
}
