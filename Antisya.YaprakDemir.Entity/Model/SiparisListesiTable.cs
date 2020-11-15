using System;
using System.Collections.Generic;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class SiparisListesiTable
    {
        public int SiparisListesiId { get; set; }
        public int? SiparisId { get; set; }
        public int? UrunId { get; set; }
        public decimal? Miktar { get; set; }
        public decimal? SatisFiyati { get; set; }
        public short? VergiId { get; set; }

        public virtual SiparisTable Siparis { get; set; }
        public virtual UrunTable Urun { get; set; }
        public virtual VergiTable Vergi { get; set; }
    }
}
