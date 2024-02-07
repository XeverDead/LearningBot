﻿using LearningBot.ApiClient.DependencyInjection;
using LearningBot.ApiClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Threading;

namespace LearningBot.UI;

public partial class App : Application
{
    public App()
    {
        SetupServiceProvider();
        Current.DispatcherUnhandledException += OnUnhandledException;
    }

    private void SetupServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddResources(GetApiSettings());
        serviceCollection.BuildServiceProvider();
    }

    private ApiSettings GetApiSettings()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var apiSettingsSection = config.GetRequiredSection(nameof(ApiSettings));
        var apiSettings = new ApiSettings
        {
            BaseUrl = apiSettingsSection[nameof(ApiSettings.BaseUrl)],
        };

        return apiSettings;
    }

    private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.Message, "Error");
        e.Handled = true;
    }
}
