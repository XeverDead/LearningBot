using LearningBot.UI.Utils;
using LearningBot.UI.Views;
using System.Windows;
using System.Windows.Controls;

namespace LearningBot.UI.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var view = ServiceProviderContainer.GetRequiredService<UserListView>();
        var userListTab = new TabItem
        {
            Header = view.Title,
            Content = new Frame { Content = view },
        };

        Tabs.Items.Add(userListTab);
    }
}
