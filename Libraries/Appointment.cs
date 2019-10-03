using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    // https://github.com/MikeWasson/BookService/
    // https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
    // https://www.codeproject.com/articles/1050468/data-transfer-object-design-pattern-in-csharp
    public class Appointment
    {
        public string appointment_id { get; set; }
        public string software_name { get; set; }
        public string appointment_on { get; set; }
        public string prospect_full_name { get; set; }
        public string prospect_email { get; set; }
        public string added_on { get; set; }
    }
}
