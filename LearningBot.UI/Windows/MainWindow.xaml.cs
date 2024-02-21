using LearningBot.UI.Utils;
using LearningBot.UI.ViewModels;
using LearningBot.UI.Views;
using System.Windows;
using System.Windows.Controls;

namespace LearningBot.UI.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var viewModel = ServiceProviderContainer.GetRequiredService<UserListViewModel>();
        var userListView = new UserListView(viewModel);
        var userListTab = new TabItem
        {
            Header = userListView.Title,
            Content = new Frame { Content = userListView },
        };

        Tabs.Items.Add(userListTab);
    }
}
