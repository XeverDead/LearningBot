using LearningBot.UI.Windows;
using System.Windows.Controls;

namespace LearningBot.UI.Utils;

internal static class Dialog
{
    public static void ShowDialog(Page page)
    {
        var dialogWindow = new DialogWindow
        {
            Content = page,
            Title = page.Title,
        };

        dialogWindow.ShowDialog();
    }
}
