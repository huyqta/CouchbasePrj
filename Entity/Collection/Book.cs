using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Collection
{
    public class Book : BaseEntity
    {
        public string collection = "book";
        public string title { get; set; }
        public string publisher { get; set; }
    }
}
