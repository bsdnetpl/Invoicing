﻿using Invoicing.DB;
using Invoicing.DTO;
using Invoicing.Models;

namespace Invoicing.Services
{
    public interface IInvoce
    {
        public InvoceDB addInvoceDB(InvoceDB invoceDB);

        public Invoce addInvoce(string InvoceNumber);

        public List<Invoce> SeekInvoce(string numberInvoce);

    }
}
