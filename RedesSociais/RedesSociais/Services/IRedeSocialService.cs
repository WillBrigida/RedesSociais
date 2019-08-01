using RedesSociais.Models;
using System;

namespace RedesSociais.Services
{
    public interface IRedeSocialService
    {
        void Login(Action<Users, string> OnLoginComplete, string redeSocial);
        void Logout();
    }
}
