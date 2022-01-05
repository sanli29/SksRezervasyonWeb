using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Tesi;

namespace SksRezervasyon.Business.FluentValidation.Tesi
{

    public class TesiRezervasyonListeleValidator : AbstractValidator<TesiRezervasyonListeleRequestDTO>
    {

        public TesiRezervasyonListeleValidator()
        {
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId boş olamaz");
        }
    }
}
