using System;
using System.Collections.Generic;
using System.Text;

namespace Antisya.YaprakDemir.Dto
{
    public class MusteriTableDto
    {
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string IletisimNumarasi { get; set; }
        public string VergiDairesi { get; set; }
        public int? VergiNo { get; set; }
        public string MusteriAdresi { get; set; }
    }
}
