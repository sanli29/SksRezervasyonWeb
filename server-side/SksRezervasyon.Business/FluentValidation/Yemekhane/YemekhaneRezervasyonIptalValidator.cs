using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Yemekhane;

namespace SksRezervasyon.Business.FluentValidation.Yemekhane
{
    public class YemekhaneRezervasyonIptalValidator : AbstractValidator<YemekhaneRezervasyonIptalRequestDTO>
    {

        public YemekhaneRezervasyonIptalValidator()
        {
            RuleFor(m => m.YemekhaneId).NotEmpty().WithMessage("YemekhaneId boş olamaz");
        }
    }
}
