using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class User
    {
        public string pseudo { set; get; }
        public string mail { set; get; }
        public string password { set; get; }

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
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as User);
        }

        public bool Equals(User user)
        {
            return this.pseudo.Equals(user.pseudo);
        }

        public override string ToString()
        {
            return pseudo + " " + mail + " " + password;
        }
    }
}
