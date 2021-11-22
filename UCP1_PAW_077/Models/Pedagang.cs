using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_077.Models
{
    public partial class Pedagang
    {
        public Pedagang()
        {
            Produks = new HashSet<Produk>();
        }

        public int IdPedagang { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Produk> Produks { get; set; }
    }
}
