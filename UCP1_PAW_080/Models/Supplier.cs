using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_080.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Barangs = new HashSet<Barang>();
        }

        public int IdSupplier { get; set; }
        public string NamaSupplier { get; set; }
        public string NoTelp { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Barang> Barangs { get; set; }
    }
}
