using Telegram.Bot.Types;

namespace LearningBot.Bot.Processors.Models;

internal class ProcessorParameters
{
    public Shared.Entities.User User { get; set; }

    public string Input { get; set; }

    public Chat Chat { get; set; }

    public string LanguageCode { get; set; }
}
