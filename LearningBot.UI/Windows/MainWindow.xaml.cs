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

        var userListView = ServiceProviderContainer.GetRequiredService<UserListView>();
        var courseListView = ServiceProviderContainer.GetRequiredService<CourseListView>();
        AddTab(userListView);
        AddTab(courseListView);
    }

    private void AddTab(Page page)
    {
        var tab = new TabItem
        {
            Header = page.Title,
            Content = new Frame { Content = page },
        };

        Tabs.Items.Add(tab);
    }
}
