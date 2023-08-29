﻿namespace Invoicing.DTO
{
    public class Customer
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string NIP { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public string Regon { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
