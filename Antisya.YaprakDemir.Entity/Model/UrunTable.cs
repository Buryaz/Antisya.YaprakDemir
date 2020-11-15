using System;
using System.Collections.Generic;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class UrunTable
    {
        public UrunTable()
        {
            AlisFaturaListesiTable = new HashSet<AlisFaturaListesiTable>();
            SiparisListesiTable = new HashSet<SiparisListesiTable>();
        }

        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public short? BirimId { get; set; }

        public virtual BirimTable Birim { get; set; }
        public virtual ICollection<AlisFaturaListesiTable> AlisFaturaListesiTable { get; set; }
        public virtual ICollection<SiparisListesiTable> SiparisListesiTable { get; set; }
    }
}
