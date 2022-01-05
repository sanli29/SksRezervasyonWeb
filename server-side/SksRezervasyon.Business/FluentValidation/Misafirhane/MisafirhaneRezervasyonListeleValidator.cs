using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Misafirhane;

namespace SksRezervasyon.Business.FluentValidation.Misafirhane
{
    public class MisafirhaneRezervasyonListeleValidator : AbstractValidator<MisafirhaneRezervasyonListeleRequestDTO>
    {

        public MisafirhaneRezervasyonListeleValidator()
        {
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId boş olamaz");
        }
    }
}
