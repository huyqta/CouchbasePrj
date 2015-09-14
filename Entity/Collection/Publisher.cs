using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Collection
{
    public class Publisher : BaseEntity
    {
        const string collection = "publisher";
        string name { get; set; }
        List<BookOnPublisher> books { get; set; }
    }

    public class BookOnPublisher : BaseEntity
    {
        string title { get; set; }
    }
}
