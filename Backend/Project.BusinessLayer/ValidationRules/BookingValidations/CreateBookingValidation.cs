using FluentValidation;
using Project.DtoLayer.BookingDto;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
                RuleFor(x=>x.BookingName).NotEmpty().WithMessage("Bu alan boş geçilemez.");
                RuleFor(x=>x.BookingName).MinimumLength(5).WithMessage("Bu alan 5 Karakterden az olamaz.");
                RuleFor(x=>x.BookingName).MaximumLength(50).WithMessage("Bu alan 50 Karakterden fazla olamaz.");
                RuleFor(x=>x.BookingPhone).NotEmpty().WithMessage("Bu alan boş geçilemez.");
                RuleFor(x=>x.BookingEmail).NotEmpty().WithMessage("Bu alan boş geçilemez.");
                RuleFor(x=>x.BookingEmail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
                RuleFor(x=>x.BookingDate).NotEmpty().WithMessage("Bu alan boş geçilemez.");
                RuleFor(x=>x.BookingPersonCount).NotEmpty().WithMessage("Bu alan boş geçilemez.");
                RuleFor(x=>x.BookingDescription).MaximumLength(500).WithMessage("Bu alan 500 karakterden fazla geçilemez.");
        }
    }
}
