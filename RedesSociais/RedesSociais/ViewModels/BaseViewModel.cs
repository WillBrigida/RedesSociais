﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RedesSociais.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void Notificar([CallerMemberName] string prop = null)

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string prop = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;

            Notificar(prop);

            return true;
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { SetProperty(ref _isLoggedIn, value); }
        }

        private bool _isLogedIn;
        public bool IsLogedIn
        {
            get { return _isLoggedIn; }
            set { SetProperty(ref _isLogedIn, value); }
        }
    }
}
