using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_077.Models
{
    public partial class Testimoni
    {
        public int IdTestimoni { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public int? KodeJenisProduk { get; set; }
        public int? KodeProduk { get; set; }

        public virtual Produk IdTestimoniNavigation { get; set; }
        public virtual JenisProduk KodeJenisProdukNavigation { get; set; }
    }
}
