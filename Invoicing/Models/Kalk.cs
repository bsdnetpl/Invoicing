namespace Invoicing.DTO
{
    public class Kalk
    {
        
        public double AddProcent(double numeric, double procent)
        {
            procent = (procent / 100) + 1;
            return Math.Round(numeric * procent, 2);
        }
        public double SubtractProcent(double numeric, double procent)
        {
            procent = (procent / 100) + 1;
            return Math.Round(numeric / procent, 2);
        }
        public double DiffrentTax(double priceBruttoBay, double priceBruttoSell, double procent)
        {
            return Math.Round(SubtractProcent(priceBruttoSell, procent) - SubtractProcent(priceBruttoBay, procent), 2);
        }
    }
    public enum PTU
    { // tax vat %
        PTU_A = 23,
        PTU_B = 8,
        PTU_C = 5,
        PTU_D = 0,
        PTU_E = 0, // ZW
        PTU_F = -1, // used only when it is technical zero value is 0%
        PTU_G = -1 // not used
    }
  }
