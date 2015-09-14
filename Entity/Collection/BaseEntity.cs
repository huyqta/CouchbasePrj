using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Collection
{
    public class BaseEntity
    {
        public string _id { get; set; }
        public DateTime CREDate { get; set; }
        public DateTime UPDDate { get; set; }
    }
}
