using System;
using System.Collections.Generic;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class BirimTable
    {
        public BirimTable()
        {
            UrunTable = new HashSet<UrunTable>();
        }

        public short BirimId { get; set; }
        public string BirimAdi { get; set; }

        public virtual ICollection<UrunTable> UrunTable { get; set; }
    }
}
