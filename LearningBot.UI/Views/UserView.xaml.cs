using LearningBot.UI.ViewModels;
using System.Windows.Controls;

namespace LearningBot.UI.Views;

public partial class UserView : Page
{
    public UserView(UserViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();
    }

    internal UserViewModel ViewModel { get; }
}
