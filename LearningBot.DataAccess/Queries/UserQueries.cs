namespace LearningBot.DataAccess.Queries;

internal static class UserQueries
{
    public const string GetByChatId = @"
        SELECT Id, ChatId, Forename, Surname, Email, Status, LanguageCode
        FROM User
        WHERE ChatId = @ChatId";

    public const string Add = @"
        INSERT INTO User (ChatId, Forename, Surname, Email, Status, LanguageCode)
        VALUES (@ChatId, @Forename, @Surname, @Email, @Status, @LanguageCode)";

    public const string Update = @"
        UPDATE User
        SET ChatId = @ChatId, Forename = @Forename, Surname = @Surname, Email = @Email, Status = @Status, LanguageCode = @LanguageCode
        WHERE Id = @Id";

    public const string DeleteById = "DELETE FROM User WHERE Id = @Id";
}
