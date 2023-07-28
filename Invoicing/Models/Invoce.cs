namespace Invoicing.DTO
{
    public class Invoce
    {
        public Guid Id { get; set; }
        public string NameConsument { get; set; }
        public string NIP_Customer { get; set; }
        public double Price_netto { get; set; }
        public double Price_Brutto { get; set; }
        public double Tax_Vat { get; set; }
        public int Vat { get; set; }
        public string InvoceNumber { set; get; }
        public DateTime dateTimeCreateInvoce { get; set; }
        public string Payment_type { get; set; }
        public DateTime dateTimePayInvoce { get; set; }
    }
}
