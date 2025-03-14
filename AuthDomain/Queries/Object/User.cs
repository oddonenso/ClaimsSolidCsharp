﻿using Service;
using System.Collections.Generic;

namespace AuthDomain.Queries.Object
{
    public class User:IQuery
    {
        public string login { get; set; } = null!;
        public IEnumerable<string> Roles { get; set; } = null!;
    }
}
