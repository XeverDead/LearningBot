using LearningBot.ApiClient.Resources.Interfaces;
using LearningBot.Shared.Enums;
using LearningBot.UI.Models;
using LearningBot.UI.Utils;
using System.Threading.Tasks;

namespace LearningBot.UI.ViewModels;

public class UserViewModel : ViewModelBase
{
    private readonly IUserResource _userResource;

    private UserModel _user;

    private Command _saveCommand;
    private Command _approveCommand;

    public UserViewModel(IUserResource userResource)
    {
        _userResource = userResource;
    }

    public UserModel User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged();
        }
    }

    public Command SaveCommand => _saveCommand ??= new Command(async x => await Save());

    public Command ApproveCommand => _approveCommand ??= new Command(async x => await Approve());

    private async Task Save()
    {
        await _userResource.Update(User.Entity);
    }

    private async Task Approve()
    {
        User.Status = UserStatus.Approved;
        await _userResource.Update(User.Entity);
    }
}
