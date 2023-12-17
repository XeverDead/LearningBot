using LearningBot.Shared.Enums;

namespace LearningBot.Shared.Entities;

public class User
{
    public int Id { get; set; }

    public long ChatId { get; set; }

    public string Forename { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public UserStatus Status { get; set; }

    public string LanguageCode { get; set; }
}
