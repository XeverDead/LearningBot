using LearningBot.UI.ViewModels;
using System;
using System.Windows.Controls;

namespace LearningBot.UI.Views;

public partial class UserListView : Page
{
    internal UserListView(UserListViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();
    }

    internal UserListViewModel ViewModel { get; set; }

    protected override async void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        await ViewModel.Init();
    }
}
