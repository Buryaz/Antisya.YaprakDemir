using System;
using System.Collections.Generic;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class MusteriTable
    {
        public MusteriTable()
        {
            SiparisTable = new HashSet<SiparisTable>();
        }

        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string IletisimNumarasi { get; set; }
        public string VergiDairesi { get; set; }
        public int? VergiNo { get; set; }
        public string MusteriAdresi { get; set; }

        public virtual ICollection<SiparisTable> SiparisTable { get; set; }
    }
}
