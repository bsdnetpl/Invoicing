using FluentValidation;

namespace Invoicing.DTO
{
    public class Seller
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NIP { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Regon { get; set; }
        public string Invoce_created_Place { get; set; }
        public string Invoce_number { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }

    }
    public class SellerValidation : AbstractValidator<Seller>
    {
        public SellerValidation()
        {
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.NIP).MinimumLength(8).MaximumLength(11).WithMessage("Nip must be between 8 char to max 11 char !");
            RuleFor(r => r.PostalCode).MinimumLength(6).MaximumLength(7).WithMessage("Post Code must be between 6 char to max 7 char !");
            RuleFor(r => r.City).MinimumLength(3).WithMessage("City must be min 3 char !");
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage("The name is important it should contain some characters !");
        }

    }
}
