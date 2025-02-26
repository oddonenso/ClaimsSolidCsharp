using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class Roles
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Client> clients { get; set; } = null!;
    }
}
