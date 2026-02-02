using FluentValidation;
using PruebaAPI4.DTOs;

namespace PruebaAPI4.Validations
{
    public class UpdateContactValidation : AbstractValidator<ContactoUpdateDto>
    {
        public UpdateContactValidation() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25).WithMessage("Nombre muy largo o vacio");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Formato de Mail incorrecto");
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^\+?[1-9]\d{7,14}$").WithMessage("Numero de telefono invalido");
        }
    }
}
