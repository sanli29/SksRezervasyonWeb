using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SksRezervasyon.Business.DTO.Ogrenci;

namespace SksRezervasyon.Business.FluentValidation.Ogrenci
{
    public class OgrenciGetByIDValidator : AbstractValidator<OgrenciGetByIDRequestDTO>
    {

        public OgrenciGetByIDValidator()
        {
            RuleFor(m => m.OgrenciId).NotEmpty().WithMessage("OgrenciId hatalı");
        }
    }
}
