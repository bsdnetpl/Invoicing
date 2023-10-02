using Invoicing.DB;
using Invoicing.DTO;
using Invoicing.Models;
using System.Reflection.Metadata;

namespace Invoicing.Services
{
    public class InvoceService : IInvoceService
    {
        private readonly ConnectMssql _connectMssql;

        public InvoceService(ConnectMssql connectMssql)
        {
            _connectMssql = connectMssql;
        }

        public InvoceDB addInvoceDB(InvoceDB invoceDB)
        {
            invoceDB.Id = Guid.NewGuid();
            Kalk kalk = new Kalk();
            if (invoceDB.Price_netto == 0)
            {
                invoceDB.Price_netto = kalk.SubtractProcent(invoceDB.Price_Brutto, Convert.ToDouble(invoceDB.Vat));
                invoceDB.Tax_Vat = Math.Round(invoceDB.Price_Brutto - invoceDB.Price_netto, 2);
            }
            if (invoceDB.Price_Brutto == 0)
            {
                invoceDB.Price_Brutto = kalk.AddProcent(invoceDB.Price_netto, Convert.ToDouble(invoceDB.Vat));
                invoceDB.Tax_Vat = Math.Round(invoceDB.Price_Brutto - invoceDB.Price_netto, 2);
            }
            _connectMssql.invoceDBs.Add(invoceDB);
            _connectMssql.SaveChanges();
            return invoceDB;
        }
        public string addInvoce(string InvoceNumber)
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
                invoce.Tax_Vat = Math.Round(sumVat, 2);
                invoce.Vat = 0;
                invoce.Price_Brutto = sumBrutto;
                invoce.Price_netto = sumNetto;
                invoce.NIP_Customer = Convert.ToString(result.Select(x => x.NIP_Customer).First());
                invoce.InvoceNumber = InvoceNumber;
                invoce.Payment_type = Convert.ToString(result.Select(x => x.Payment_type).First());
                invoce.NameConsument = "Test";
                _connectMssql.invoces.Add(invoce);
                _connectMssql.SaveChanges();
             
            
     
            return "Invoce add to DB";
        }
        public List<Invoce> SeekInvoce(string numberInvoce)
        {
            return _connectMssql.invoces.Where(x => x.InvoceNumber == numberInvoce).ToList();
        }

        public string InvoceIncrement()
        {
            var result = _connectMssql.sellers.FirstOrDefault();
            int increment = Int32.Parse(result.Invoce_number);
            result.Invoce_number = Convert.ToString(increment+=1);
            _connectMssql.SaveChanges();
            return increment.ToString();
        }
    }
}
