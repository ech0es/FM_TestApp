using System.ComponentModel;

namespace MauiApp1.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertChanged(PropertyChangedEventArgs propertyChangedEventArgs)
    {
        PropertyChanged?.Invoke(this, propertyChangedEventArgs);
    }
}