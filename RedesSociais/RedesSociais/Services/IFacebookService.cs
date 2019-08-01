using RedesSociais.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedesSociais.Services
{
    public interface IFacebookService
    {
        void Login(Action<Users, string> onLoginComplete);
        void Logout();
    }
}
