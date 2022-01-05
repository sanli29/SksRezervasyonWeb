using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Tesi;

namespace SksRezervasyon.Business.FluentValidation.Tesi
{
    public class TesiRezervasyonMusaitListeleValidator : AbstractValidator<TesiRezervasyonMusaitListeleRequestDTO>
    {

        public TesiRezervasyonMusaitListeleValidator()
        {
            RuleFor(m => m.Tarih).NotEmpty().WithMessage("Tarih boş olamaz");
            RuleFor(m => m.TesisTur).NotEmpty().WithMessage("TesisTur boş olamaz");
        }
    }
}
