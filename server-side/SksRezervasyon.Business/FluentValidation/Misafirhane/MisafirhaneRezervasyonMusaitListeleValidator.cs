using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Misafirhane;

namespace SksRezervasyon.Business.FluentValidation.Misafirhane
{
    public class MisafirhaneRezervasyonMusaitListeleValidator : AbstractValidator<MisafirhaneRezervasyonMusaitListeleRequestDTO>
    {

        public MisafirhaneRezervasyonMusaitListeleValidator()
        {
            RuleFor(m => m.GirisTarihi).NotEmpty().WithMessage("GirisTarihi boş olamaz");
        }
    }
}
