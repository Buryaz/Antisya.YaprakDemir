using System;
using System.Collections.Generic;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class SiparisTable
    {
        public SiparisTable()
        {
            SiparisListesiTable = new HashSet<SiparisListesiTable>();
        }

        public int SiparisId { get; set; }
        public int? MusteriId { get; set; }
        public DateTime? Tarih { get; set; }
        public decimal? ToplamTutar { get; set; }
        public decimal? VergiTutari { get; set; }
        public decimal? IskontoYuzdesi { get; set; }

        public virtual MusteriTable Musteri { get; set; }
        public virtual ICollection<SiparisListesiTable> SiparisListesiTable { get; set; }
    }
}
