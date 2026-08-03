using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
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

    var message = $"\n|cffffcc00{Loc.Get("MAJOR EVENT")} - {whichPlayerData.Faction?.PrefixCol}{Loc.Get(questData.Title)}|r";
    var messageWithFlavour = $"\n{Loc.Get(questData.RewardFlavour)}\n";

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
      ? $"\n|cffffcc00{Loc.Get("QUEST FAILED")} - {Loc.Get(questData.Title)}|r\n{Loc.Get(questData.PenaltyFlavour)}\n"
      : $"\n|cffffcc00{Loc.Get("QUEST FAILED")} - {Loc.Get(questData.Title)}|r\n";

    if (faction.Player.GetPlayerSettings().ShowQuestText)
    {
      foreach (var objective in questData.Objectives)
      {
        if (objective.ShowsInPopups || objective.Progress == QuestProgress.Failed)
        {
          display = objective.Progress switch
          {
            QuestProgress.Complete => $"{display} - |cff808080{Loc.Get(objective.Description)} ({Loc.Get("Completed")})|r\n",
            QuestProgress.Failed => $"{display} - |cffCD5C5C{Loc.Get(objective.Description)} ({Loc.Get("Failed")})|r\n",
            _ => $"{display} - {Loc.Get(objective.Description)}\n"
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

    var display = $"\n|cffffcc00{Loc.Get("QUEST COMPLETED")} - {Loc.Get(questData.Title)}|r\n";

    if (faction.Player.GetPlayerSettings().ShowQuestText)
    {
      if (!string.IsNullOrEmpty(questData.RewardFlavour))
      {
        display += $"{Loc.Get(questData.RewardFlavour)}\n";
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

    var display = $"\n|cffffcc00{Loc.Get("QUEST DISCOVERED")} - {Loc.Get(questData.Title)}|r\n";

    if (faction.Player.GetPlayerSettings().ShowQuestText)
    {
      if (displayFlavour)
      {
        display += $"{Loc.Get(questData.Flavour)}\n";
      }

      foreach (var objective in questData.Objectives)
      {
        if (objective.ShowsInPopups)
        {
          display = objective.Progress == QuestProgress.Complete
            ? $"{display} - |cff808080{Loc.Get(objective.Description)} ({Loc.Get("Completed")})|r\n"
            : $"{display} - {Loc.Get(objective.Description)}\n";
        }
      }
    }

    faction.Player.DisplayTextTo(display);
    faction.Player.PlaySound(SoundLibrary.Discovered);
    faction.Player.FlashQuests();
  }
}
