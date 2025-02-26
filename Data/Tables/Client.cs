﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class Client
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Login { get; set; } = null!;
        [MaxLength(20)]
        public string Password { get; set; } = null!;
        public ICollection<Roles> Roles { get; set; }
    }
}
