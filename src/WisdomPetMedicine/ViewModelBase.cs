﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WisdomPetMedicine;
public class ViewModelBase : INotifyPropertyChanged
{
    public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}