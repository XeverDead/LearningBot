using LearningBot.Shared.Entities;

namespace LearningBot.UI.Models;

internal class UserModel : ModelBase<User>
{
    public UserModel() : base()
    {
    }

    public UserModel(User entity) : base(entity)
    {
    }

    public int Id => Entity.Id;

    public string Forename
    {
        get => Entity.Forename;
        set
        {
            Entity.Forename = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string Surname
    {
        get => Entity.Surname;
        set
        {
            Entity.Surname = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string Email
    {
        get => Entity.Email;
        set
        {
            Entity.Email = value;
            OnPropertyChanged();
        }
    }

    public string FullName => $"{Forename} {Surname}";
}
