using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Yemekhane;

namespace SksRezervasyon.Business.FluentValidation.Yemekhane
{
    public class YemekhaneRezervasyonListeleValidator : AbstractValidator<YemekhaneRezervasyonListeleRequestDTO>
    {

        public YemekhaneRezervasyonListeleValidator()
        {
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId boş olamaz");
        }
    }
}
