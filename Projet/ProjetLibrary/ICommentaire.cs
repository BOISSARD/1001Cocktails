using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public interface ICommentaire
    {
        string Titre { get; }
        string Texte { get; }
        short Note { get; }
    }
}
