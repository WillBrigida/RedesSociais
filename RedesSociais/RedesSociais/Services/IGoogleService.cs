using RedesSociais.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedesSociais.Services
{
    public interface IGoogleService
    {
        void Login(Action<Users, string> OnLoginComplete);
        void Logout();
    }
}
