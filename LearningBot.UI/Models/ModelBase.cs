using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LearningBot.UI.Models;

public class ModelBase<T> : INotifyPropertyChanged
{
    public ModelBase()
    {
    }

    public ModelBase(T entity)
    {
        Entity = entity;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public T Entity { get; set; }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
