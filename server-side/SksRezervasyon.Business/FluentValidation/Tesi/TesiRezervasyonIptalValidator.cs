using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Tesi;

namespace SksRezervasyon.Business.FluentValidation.Tesi
{
    public class TesiRezervasyonIptalValidator : AbstractValidator<TesiRezervasyonIptalRequestDTO>
    {

        public TesiRezervasyonIptalValidator()
        {
          
            RuleFor(m => m.TesisId).NotEmpty().WithMessage("TesisId boş olamaz");
        }
    }
}
