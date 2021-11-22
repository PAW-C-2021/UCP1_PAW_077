using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_077.Models
{
    public partial class JenisProduk
    {
        public JenisProduk()
        {
            Testimonis = new HashSet<Testimoni>();
        }

        public int KodeJenisProduk { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Testimoni> Testimonis { get; set; }
    }
}
