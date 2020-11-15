using System;
using System.Collections.Generic;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class VergiTable
    {
        public VergiTable()
        {
            AlisFaturaListesiTable = new HashSet<AlisFaturaListesiTable>();
            SiparisListesiTable = new HashSet<SiparisListesiTable>();
        }

        public short VergiId { get; set; }
        public decimal? VergiOrani { get; set; }
        public string VergiAdi { get; set; }

        public virtual ICollection<AlisFaturaListesiTable> AlisFaturaListesiTable { get; set; }
        public virtual ICollection<SiparisListesiTable> SiparisListesiTable { get; set; }
    }
}
