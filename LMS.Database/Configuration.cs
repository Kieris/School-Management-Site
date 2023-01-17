using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using System.IO;

namespace LMS.Database;

internal static class Configuration
{
    private static readonly IConfigurationRoot provider;

    private static readonly string ConfigurationFilename = "database.appsettings.json";

    static Configuration()
    {
        var builder = new ConfigurationBuilder();
        var workingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if(workingDirectory != null)
        {
            var settingsPath = Path.Combine(workingDirectory, ConfigurationFilename);
            builder.AddJsonFile(settingsPath);
        }
        provider = builder.Build();
    }

    internal static string GetConnectionString(string connStringName)
    {
        if (string.IsNullOrWhiteSpace(connStringName))
        {
            throw new ArgumentException($"'{nameof(connStringName)}' cannot be null or whitespace.", nameof(connStringName));
        }
        return provider.GetConnectionString(connStringName);
    }

    internal static T GetValue<T>(string propertyName)
    {
        return provider.GetValue<T>(propertyName);
    }
}