using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Collection
{
    public class Publisher
    {
        const string collection = "publisher";
        string _id { get; set; }
        string name { get; set; }
        List<BookOnPublisher> books { get; set; }
    }

    public class BookOnPublisher
    {
        string title { get; set; }
    }
}
