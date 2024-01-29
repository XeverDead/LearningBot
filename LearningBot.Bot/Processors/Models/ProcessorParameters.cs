using Telegram.Bot.Types;
using User = LearningBot.Shared.Entities.User;

namespace LearningBot.Bot.Processors.Models;

internal class ProcessorParameters
{
    public User User { get; set; }

    public string Input { get; set; }

    public Chat Chat { get; set; }

    public string LanguageCode { get; set; }
}
