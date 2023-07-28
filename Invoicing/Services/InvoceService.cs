using Invoicing.DB;
using Invoicing.DTO;
using Invoicing.Models;
using System.Reflection.Metadata;

namespace Invoicing.Services
{
    public class InvoceService : IInvoce
    {
        private readonly ConnectMssql _connectMssql;

        public InvoceService(ConnectMssql connectMssql)
        {
            _connectMssql = connectMssql;
        }

        public InvoceDB addInvoceDB(InvoceDB invoceDB)
        {
            _connectMssql.invoceDBs.Add(invoceDB);
            _connectMssql.SaveChanges();
            return invoceDB;
        }
        public Invoce addInvoce(string InvoceNumber)
        {
            Invoce invoce = new Invoce();
             var result  = _connectMssql.invoceDBs.Where(x => x.InvoceNumber == InvoceNumber);
            //if(result is null)
            //{

            //}
            double sumVat = result.Select(x => x.Tax_Vat).Sum();
            double sumNetto = result.Select(x => x.Price_netto).Sum();
            double sumBrutto = result.Select(x => x.Price_Brutto).Sum();
            invoce.Id = Guid.NewGuid();
            invoce.dateTimeCreateInvoce = DateTime.Now;
            invoce.Tax_Vat = sumVat;
            invoce.Price_Brutto = sumBrutto;
            invoce.Price_netto = sumNetto;
            invoce.NIP_Customer = Convert.ToString(result.Select(x => x.NIP_Customer));
            invoce.InvoceNumber = result.Select(x => x.InvoceNumber).ToString();
            invoce.Payment_type = result.Select(x => x.Payment_type).ToString();
            invoce.NameConsument = "Test";
            _connectMssql.invoces.Add(invoce);
            _connectMssql.SaveChanges();
            return invoce;
        }
        public List<Invoce> SeekInvoce(string numberInvoce)
        {
            return _connectMssql.invoces.Where(x => x.InvoceNumber == numberInvoce).ToList();
        }
    }
}
