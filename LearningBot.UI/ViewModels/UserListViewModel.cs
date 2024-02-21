using LearningBot.ApiClient.Resources.Interfaces;
using LearningBot.Shared.Enums;
using LearningBot.UI.Models;
using LearningBot.UI.Utils;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace LearningBot.UI.ViewModels;

internal class UserListViewModel : ViewModelBase
{
    private readonly IUserResource _userResource;

    private UserModel _selectedUser;

    private Command _editUserCommand;

    public UserListViewModel(IUserResource userResource)
    {
        _userResource = userResource;
    }

    public ObservableCollection<UserModel> AppliedUsers { get; set; } = new ObservableCollection<UserModel>();

    public ObservableCollection<UserModel> ApprovedUsers { get; set; } = new ObservableCollection<UserModel>();

    public UserModel SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            OnPropertyChanged();
        }
    }

    public Command EditUserCommand => _editUserCommand ??= new Command(x => ShowUserView(), x => SelectedUser != null);

    public async Task Init()
    {
        AppliedUsers.Clear();
        ApprovedUsers.Clear();

        var users = await _userResource.GetAllExceptNew();
        foreach (var user in users)
        {
            var userModel = new UserModel(user);
            if (user.Status == UserStatus.Applied)
            {
                AppliedUsers.Add(userModel);
            }
            else
            {
                ApprovedUsers.Add(userModel);
            }
        }
    }

    private void ShowUserView()
    {
        MessageBox.Show("Not implemented yet");
    }
}
