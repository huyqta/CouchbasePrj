using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Collection
{
    public class Publisher : BaseEntity
    {
        public string collection = "publisher";
        public string name { get; set; }
        public List<string> books { get; set; }
    }

    public class BookOnPublisher : BaseEntity
    {
        public string title { get; set; }
    }
}
