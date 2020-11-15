using System;
using System.Collections.Generic;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class AlisFaturaListesiTable
    {
        public int AlisFaturaListesiId { get; set; }
        public int? AlisFaturasiId { get; set; }
        public int? UrunId { get; set; }
        public decimal? AlisMiktari { get; set; }
        public decimal? AlisFiyati { get; set; }
        public short? VergiId { get; set; }

        public virtual UrunTable Urun { get; set; }
        public virtual VergiTable Vergi { get; set; }
    }
}
