using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_077.Models
{
    public partial class Produk
    {
        public int KodeProduk { get; set; }
        public string NamaProduk { get; set; }
        public string Harga { get; set; }
        public int? IdPedagang { get; set; }

        public virtual Pedagang IdPedagangNavigation { get; set; }
        public virtual Testimoni Testimoni { get; set; }
    }
}
