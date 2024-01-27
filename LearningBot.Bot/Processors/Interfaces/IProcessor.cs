using LearningBot.Bot.Processors.Models;
using LearningBot.Shared.Entities;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace LearningBot.Bot.Processors.Interfaces;

internal interface IProcessor
{
    bool IsApplicable(string input, User user, UpdateType updateType);

    Task Process(ProcessorParameters parameters);
}
