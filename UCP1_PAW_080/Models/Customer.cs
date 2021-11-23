using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_080.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdCustomer { get; set; }
        public string NamaPembeli { get; set; }
        public string NoTelp { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
