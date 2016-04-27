using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class User
    {
        private string pseudo { set; get; }
        private string mail { set; get; }
        private string password { set; get; }

        public User(string pseudo, string password)
        {
            this.pseudo = pseudo;
            this.password = password;
        }

        public User(string pseudo, string mail, string password)
        {
            this.pseudo = pseudo;
            this.mail = mail;
            this.password = password;
        }

        public override int GetHashCode()
        {
            return pseudo.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null || obj.GetType() != this.GetType()) return false;
            User c = (User)obj;
            return this.pseudo.Equals(c.pseudo);
        }
    }
}
