using FluentValidation;

namespace Invoicing.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; } = string.Empty;
        public string ?Description { get; set; }
        public string NIP { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ? Region { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ? Phone { get; set; }
        public string ? Regon { get; set; }
        public string ? email { get; set; }
    }
    public class CustomerDTOValistion: AbstractValidator<CustomerDTO>
    {
        public CustomerDTOValistion()
        {
            RuleFor(r => r.email).EmailAddress().Null();
            RuleFor(r => r.NIP).MinimumLength(8).MaximumLength(11).WithMessage("Nip must be between 8 char to max 11 char !");
            RuleFor(r => r.PostalCode).MinimumLength(6).MaximumLength(7).WithMessage("Post Code must be between 6 char to max 7 char !");
            RuleFor(r => r.City).MinimumLength(3).WithMessage("City must be min 3 char !");
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage("The name is important it should contain some characters !");

        }
    }
}
