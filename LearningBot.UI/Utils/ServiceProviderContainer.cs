using Microsoft.Extensions.DependencyInjection;
using System;

namespace LearningBot.UI.Utils;

internal static class ServiceProviderContainer
{
    public static IServiceProvider ServiceProvider { private get; set; }

    public static T GetRequiredService<T>() => ServiceProvider.GetRequiredService<T>();
}
