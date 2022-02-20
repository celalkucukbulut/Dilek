using System;
using System.Security.Principal;

namespace Dilek
{
    public class UserPrincipal : IPrincipal
    {
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Username { get; internal set; }
        public string Password { get; internal set; }
        public string MailAddress { get; internal set; }
        public IIdentity Identity { get; internal set; }
        public int ID { get; internal set; }

        public UserPrincipal(string identity)
        {
            this.Identity = new GenericIdentity(identity);
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}