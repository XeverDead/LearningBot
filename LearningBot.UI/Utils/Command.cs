using System;
using System.Windows.Input;

namespace LearningBot.UI.Utils;

internal class Command : ICommand
{
    private readonly Action<object> _action;
    private readonly Predicate<object> _condition;

    public Command(Action<object> action, Predicate<object> condition = null)
    {
        _action = action;
        _condition = condition;
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter) => _condition == null || _condition(parameter);

    public void Execute(object parameter) => _action(parameter);
}
