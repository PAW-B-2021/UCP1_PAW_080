using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_080.Models
{
    public partial class Pembayaran
    {
        public int IdPembayaran { get; set; }
        public DateTime? TglBayar { get; set; }
        public int? TotalBayar { get; set; }
        public int? IdTransaksi { get; set; }

        public virtual Transaksi IdTransaksiNavigation { get; set; }
    }
}
