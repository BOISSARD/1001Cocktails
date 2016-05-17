using System;

namespace ProjetLibrary
{
    public interface IUser
    {
        string Pseudo { get; }
        string Mail { get; }
        string Password { get; }
    }
}