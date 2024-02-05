using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Models
{
    public class AuthModel
    {
        public AuthModel() { }
        public AuthModel(bool isAuthenticated, string username, string email, List<string> roles, string token, DateTime expiresOn)
        {
            IsAuthenticated = isAuthenticated;
            Username = username;
            Email = email;
            Roles = roles;
            Token = token;
            ExpiresOn = expiresOn;
        }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Message {  get; set; }
    }

}
