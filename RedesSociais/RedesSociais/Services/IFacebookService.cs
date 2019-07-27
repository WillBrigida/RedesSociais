using RedesSociais.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedesSociais.Services
{
    public interface IFacebookService
    {
        void Login(Action<FacebookUser, string> onLoginComplete);
        void Logout();
    }
}
