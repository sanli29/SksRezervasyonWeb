using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Misafirhane;

namespace SksRezervasyon.Business.FluentValidation.Misafirhane
{
    public class MisafirhaneRezervasyonIptalValidator : AbstractValidator<MisafirhaneRezervasyonIptalRequestDTO>
    {

        public MisafirhaneRezervasyonIptalValidator()
        {
            RuleFor(m => m.MisafirhaneId).NotEmpty().WithMessage("MisafirhaneId boş olamaz");
        }
    }
}
