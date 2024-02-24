using LearningBot.UI.ViewModels;
using System;
using System.Windows.Controls;

namespace LearningBot.UI.Views;

public partial class UserListView : Page
{
    public UserListView(UserListViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();
    }

    public UserListViewModel ViewModel { get; }

    protected override async void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        await ViewModel.Init();
    }
}
