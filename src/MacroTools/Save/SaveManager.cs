using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Localization;
using WCSharp.SaveLoad;
using WCSharp.Shared;

namespace MacroTools.Save;

/// <summary>
/// Manager class for saving and loading player settings.
/// </summary>
public static class SaveManager
{
  internal static Dictionary<player, PlayerSettings> SavesByPlayer { get; } = new();
  private static SaveSystem<PlayerSettings>? _saveSystem;
  public static event Action? LocalPlayerSettingsLoaded;
  public static bool LocalPlayerSettingsReady { get; private set; }
  public static void RunWhenLocalPlayerSettingsReady(Action action)
  {
    if (LocalPlayerSettingsReady)
    {
      action();
    }
    else
    {
      LocalPlayerSettingsLoaded += action;
    }
  }

  public static void Initialize()
  {
    _saveSystem = new SaveSystem<PlayerSettings>(new SaveSystemOptions
    {
      Hash1 = 36653,
      Hash2 = 612319,
      Salt = "zCi5fkypenPpgukyoEW8H6YC",
      BindSavesToPlayerName = true,
      SaveFolder = "WarcraftLegacies"
    });

    _saveSystem.OnSaveLoaded += SaveManager_OnSaveLoaded;

    foreach (var player in Util.EnumeratePlayers())
    {
      _saveSystem.Load(player, 0);
    }
  }

  private static void SaveManager_OnSaveLoaded(PlayerSettings save, LoadResult loadResult)
  {
    SavesByPlayer[save.GetPlayer()] = save;

    if (save.GetPlayer() == player.LocalPlayer)
    {
      if (!save.LanguageIsManual)
      {
        save.Language = Loc.GetSystemLanguage();
      }

      LocalPlayerSettingsReady = true;

      if (LocalPlayerSettingsLoaded != null)
      {
        foreach (var action in LocalPlayerSettingsLoaded.GetInvocationList())
        {
          try
          {
            ((Action)action)();
          }
          catch (Exception ex)
          {
            Console.WriteLine($"A {nameof(RunWhenLocalPlayerSettingsReady)} action failed: {ex}");
          }
        }
      }
    }
    save.GetPlayer().ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, save.CamDistance, 1);

    if (loadResult == LoadResult.FailedHash)
    {
      Console.WriteLine($"Validating save file for {save.GetPlayer().Name} failed! The game should probably be restarted.");
    }

    if (loadResult.Failed())
    {
      Console.WriteLine("An existing save failed to load correctly!");
    }
  }

  /// <summary>
  /// Saves the player settings for the given player.
  /// </summary>
  /// <param name="save"></param>
  internal static void Save(PlayerSettings save)
  {
    _saveSystem?.Save(save);
  }
}
