﻿using AuthDomain.Queries.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain
{
    public interface IAuthRepository
    {
        User? Registration(string login, string password);   
        User? Autification(string login, string password);
    }
}
