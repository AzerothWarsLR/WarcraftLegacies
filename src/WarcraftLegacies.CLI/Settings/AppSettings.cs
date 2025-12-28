using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace WarcraftLegacies.CLI.Settings;

/// <summary>
/// Root application settings configurable via the default <c>appsettings.json</c>
/// and the user-specific override file (<c>appsettings.{Environment.UserName}.json</c>).
/// </summary>
public sealed class AppSettings
{
  /// <summary>
  /// Provides a singleton representing the currently loaded application settings.
  /// </summary>
  public static AppSettings Current { get; } = Load();

  /// <summary>
  /// Gets or sets compiler-related settings.
  /// </summary>
  public CompilerSettings CompilerSettings { get; init; }

  /// <summary>
  /// Gets or sets map-related settings.
  /// </summary>
  public MapSettings MapSettings { get; init; }

  /// <summary>
  /// Loads the application's settings by combining the default <c>appsettings.json</c>
  /// and the user-specific override file (<c>appsettings.{Environment.UserName}.json</c>).
  /// If the user-specific file does not exist, it is automatically created with default values.
  /// </summary>
  /// <returns>
  /// An <see cref="AppSettings"/> instance containing all application settings.
  /// </returns>
  /// <exception cref="InvalidOperationException">
  /// Thrown if the user-specific settings file path cannot be determined.
  /// </exception>
  public static AppSettings Load()
  {
    var appConfiguration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", false, true)
      .AddJsonFile(GetOrCreateUserAppSettingsPath(), false, true)
      .Build();

    var appSettings = new AppSettings();
    appConfiguration.Bind(appSettings);

    return appSettings;
  }

  private static string GetOrCreateUserAppSettingsPath()
  {
    // Navigate three levels up to reach the project directory from the app's base directory
    var projectDir = new DirectoryInfo(AppContext.BaseDirectory).Parent?.Parent?.Parent;
    if (projectDir == null)
    {
      throw new InvalidOperationException($"Failed to locate the project directory. Starting from '{AppContext.BaseDirectory}', traversing three levels up resulted in null.");
    }

    // Verify that the project root contains a known marker file to avoid writing to an incorrect directory
    const string markerFileName = "appsettings.json";
    if (!File.Exists(Path.Combine(projectDir.FullName, markerFileName)))
    {
      throw new InvalidOperationException($"Project directory at '{projectDir.FullName}' does not contain the expected marker file '{markerFileName}'.");
    }

    var userFileName = $"appsettings.{Environment.UserName}.json";
    var userFilePath = Path.Combine(projectDir.FullName, userFileName);

    if (!File.Exists(userFilePath))
    {
      CreateUserAppSettings(userFilePath);
    }

    return userFilePath;
  }

  private static void CreateUserAppSettings(string filePath)
  {
#pragma warning disable CA1869
    var options = new JsonSerializerOptions
#pragma warning restore CA1869
    {
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      WriteIndented = true
    };

    var defaultSettings = new AppSettings
    {
      CompilerSettings = new CompilerSettings
      {
        Warcraft3ExecutablePath = string.Empty
      }
    };

    File.WriteAllText(filePath, JsonSerializer.Serialize(defaultSettings, options));
  }
}
