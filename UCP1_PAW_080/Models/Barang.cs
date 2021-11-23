using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_080.Models
{
    public partial class Barang
    {
        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int? Harga { get; set; }
        public int? Stok { get; set; }
        public int? IdSupplier { get; set; }

        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual Transaksi Transaksi { get; set; }
    }
}
