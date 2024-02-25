using LearningBot.UI.ViewModels;
using System;
using System.Windows.Controls;

namespace LearningBot.UI.Views;

public partial class CourseListView : Page
{
    public CourseListView(CourseListViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();
    }

    public CourseListViewModel ViewModel { get; }

    protected override async void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        await ViewModel.Init();
    }
}
