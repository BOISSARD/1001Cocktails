using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class User : IEquatable<User>
    {
        public string Pseudo { private set; get; }
        public string Mail { private set; get; }
        public string Password { private set; get; }

        public User(string pseudo, string password)
        {
            this.Pseudo = pseudo;
            this.Password = password;
        }

        public User(string pseudo, string mail, string password) : this(pseudo, password)
        {
            this.Mail = mail;
        }

        public override int GetHashCode()
        {
            return Pseudo.GetHashCode();
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
            return this.Pseudo.Equals(user.Pseudo);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Pseudo, Mail, Password);
        }
    }
}
