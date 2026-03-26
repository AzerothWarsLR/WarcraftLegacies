using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Sounds;
namespace MacroTools.Quests;

public static class FactionQuestExtensions
{
  /// <summary>
  ///   Displays a warning message to everyone except the player that completed the <see cref="QuestData" />.
  /// </summary>
  internal static void DisplayCompletedGlobal(this player whichPlayer, QuestData questData)
  {
    var whichPlayerData = whichPlayer.GetPlayerData();
    var localPlayerData = player.LocalPlayer.GetPlayerData();
    var localPlayerIsAlly = localPlayerData.Team?.Contains(whichPlayer) == true;

    var sound = localPlayerIsAlly ? SoundLibrary.Completed : SoundLibrary.Failed;
    sound.Start();

    var message = $"\n|cffffcc00MAJOR EVENT - {whichPlayerData.Faction?.PrefixCol}{questData.Title}|r";
    var messageWithFlavour = $"\n{questData.RewardFlavour}\n";

    if (player.LocalPlayer != whichPlayer)
    {
      player.LocalPlayer.DisplayTextTo(localPlayerData.PlayerSettings.ShowQuestText ? messageWithFlavour : message);
    }
  }

  internal static void DisplayFailed(this Faction faction, QuestData questData)
  {
    if (faction.Player == null)
    {
      return;
    }

    var display = !string.IsNullOrEmpty(questData.PenaltyFlavour)
      ? $"\n|cffffcc00QUEST FAILED - {questData.Title}|r\n{questData.PenaltyFlavour}\n"
      : $"\n|cffffcc00QUEST FAILED - {questData.Title}|r\n";

    if (faction.Player.GetPlayerSettings().ShowQuestText)
    {
      foreach (var objective in questData.Objectives)
      {
        if (objective.ShowsInPopups || objective.Progress == QuestProgress.Failed)
        {
          display = objective.Progress switch
          {
            QuestProgress.Complete => $"{display} - |cff808080{objective.Description} (Completed)|r\n",
            QuestProgress.Failed => $"{display} - |cffCD5C5C{objective.Description} (Failed)|r\n",
            _ => $"{display} - {objective.Description}\n"
          };
        }
      }
    }

    faction.Player.DisplayTextTo(display);
    faction.Player.PlaySound(SoundLibrary.Failed);
  }

  internal static void DisplayCompleted(this Faction faction, QuestData questData)
  {
    if (faction.Player == null)
    {
      return;
    }

    var display = $"\n|cffffcc00QUEST COMPLETED - {questData.Title}|r\n";

    if (faction.Player.GetPlayerSettings().ShowQuestText)
    {
      if (!string.IsNullOrEmpty(questData.RewardFlavour))
      {
        display += $"{questData.RewardFlavour}\n";
      }
    }

    faction.Player.DisplayTextTo(display);
    faction.Player.PlaySound(SoundLibrary.Completed);
  }

  /// <summary>
  /// Indicates to the provided question that the quest has been discovered.
  /// </summary>
  public static void DisplayDiscovered(this Faction faction, QuestData questData, bool displayFlavour)
  {
    if (faction.Player == null)
    {
      return;
    }

    var display = $"\n|cffffcc00QUEST DISCOVERED - {questData.Title}|r\n";

    if (faction.Player.GetPlayerSettings().ShowQuestText)
    {
      if (displayFlavour)
      {
        display += $"{questData.Flavour}\n";
      }

      foreach (var objective in questData.Objectives)
      {
        if (objective.ShowsInPopups)
        {
          display = objective.Progress == QuestProgress.Complete
            ? $"{display} - |cff808080{objective.Description} (Completed)|r\n"
            : $"{display} - {objective.Description}\n";
        }
      }
    }

    faction.Player.DisplayTextTo(display);
    faction.Player.PlaySound(SoundLibrary.Discovered);
    faction.Player.FlashQuests();
  }
}
