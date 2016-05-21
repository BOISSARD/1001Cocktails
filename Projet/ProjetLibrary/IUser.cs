using System;

namespace ProjetLibrary
{
    /// <summary>
    /// Interface pour la façade immuable du type User.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Getter Pseudo.
        /// </summary>
        string Pseudo { get; }
        /// <summary>
        /// Getter Mail.
        /// </summary>
        string Mail { get; }
        /// <summary>
        /// Getter Password.
        /// </summary>
        string Password { get; }
    }
}