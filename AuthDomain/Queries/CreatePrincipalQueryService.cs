using AuthDomain.Queries.Object;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries
{
    public class CreatePrincipalQueryService : IQueryService<User, ClaimsPrincipal>
    {
        public ClaimsPrincipal Execute(User obj)
        {
            List<Claim> claims = new List<Claim>();
            foreach(var item in obj.Roles)
            {
                claims.Add(new Claim("role", item));
            }
            var identity = new ClaimsIdentity(claims, "RolesClaim", ClaimTypes.Name, ClaimTypes.Role);

            return new ClaimsPrincipal(identity);
        }
    }
}
