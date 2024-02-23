using LearningBot.UI.ViewModels;
using System.Windows.Controls;

namespace LearningBot.UI.Views;

public partial class UserView : Page
{
    internal UserView(UserViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();
    }

    internal UserViewModel ViewModel { get; set; }
}
