using FluentValidation;
using SksRezervasyon.Business.DTO.Kutuphane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.FluentValidation.Kutuphane
{
    public class KutuphaneRezervasyonIptalValidator : AbstractValidator<KutuphaneRezervasyonIptalRequestDTO>
    {

        public KutuphaneRezervasyonIptalValidator()
        {
            RuleFor(m => m.KutuphaneId).NotEmpty().WithMessage("KutuphaneId boş olamaz");
        }
    }
}
