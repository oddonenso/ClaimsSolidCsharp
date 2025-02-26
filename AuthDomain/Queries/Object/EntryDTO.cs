using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries.Object
{
    public class EntryDTO : IQuery
    {
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;   
    }
}
