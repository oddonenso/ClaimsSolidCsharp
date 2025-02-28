using AuthDomain;
using AuthDomain.Queries.Object;
using Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AuthRepository : IAuthRepository
    {

        private readonly Connection _connection;

        public AuthRepository(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection, nameof(connection));
            _connection = connection;
        }
        public User? Auntification(string login, string password)
        {
            var client = _connection.Clients.Include(row => row.Roles)
                                            .FirstOrDefault(row=>
                                             row.Login.ToLower() == login.ToLower() && 
                                             row.Password == password);   
            if(client != null)
            {
                User user = new User();
                user.login = login;
                user.Roles = client.Roles.Select(row=>row.Name).ToList();
                return user;
            }
            return null!;
        }

        public User? Registration(string login, string password)
        {
            bool any = _connection.Clients.Any(row=> row.Login.ToLower() == login.ToLower());  
            if(!any)
            {
                Client client = new Client();
                client.Login = login.ToLower();
                client.Password = password;

                var role = _connection.Roles.FirstOrDefault(row => row.Name == "User");
                client.Roles = new List<Roles>() { role };
                _connection.Add(client);
                if(_connection.SaveChanges()>0)
                {
                    User user = new User();
                    user.login = login;
                    user.Roles = new List<string>() { role.Name };
                    return user;
                }
            }
            return null;
        }
    }
}
