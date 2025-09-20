using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Sound;

namespace MacroTools.QuestSystem;

public static class FactionQuestExtensions
{
  /// <summary>
  ///   Displays a warning message to everyone except the player that completed the <see cref="QuestData" />.
  /// </summary>
  internal static void DisplayCompletedGlobal(this player whichPlayer, QuestData questData)
  {
    var soundCompleted = SoundLibrary.Completed;
    var soundFailed = SoundLibrary.Failed;
    StartSound(GetLocalPlayer().GetTeam()?.Contains(whichPlayer) == true
      ? soundCompleted
      : soundFailed);

    foreach (var enumPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      if (enumPlayer != whichPlayer)
      {
        if (PlayerData.ByHandle(whichPlayer).PlayerSettings.ShowQuestText)
        {
          DisplayTextToPlayer(enumPlayer, 0, 0,
            $"\n|cffffcc00MAJOR EVENT - {whichPlayer.GetFaction()?.PrefixCol}{questData.Title}|r\n{questData.RewardFlavour}\n");
        }
      }
    }
  }

  internal static void DisplayFailed(this Faction faction, QuestData questData)
  {
    var display = !string.IsNullOrEmpty(questData.PenaltyFlavour)
      ? $"\n|cffffcc00QUEST FAILED - {questData.Title}|r\n{questData.PenaltyFlavour}\n"
      : $"\n|cffffcc00QUEST FAILED - {questData.Title}|r\n";

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

    if (faction.Player != null && faction.Player.GetPlayerSettings().ShowQuestText)
    {
      DisplayTextToPlayer(faction.Player, 0, 0, display);
    }

    faction.Player?.PlaySound(SoundLibrary.Failed);
  }

  internal static void DisplayCompleted(this Faction faction, QuestData questData)
  {
    var display = $"\n|cffffcc00QUEST COMPLETED - {questData.Title}|r\n{questData.RewardFlavour}\n";
    foreach (var objective in questData.Objectives)
    {
      if (objective.ShowsInPopups)
      {
        display = $"{display} - |cff808080{objective.Description} (Completed)|r\n";
      }
    }

    if (faction.Player != null && faction.Player.GetPlayerSettings().ShowQuestText)
    {
      DisplayTextToPlayer(faction.Player, 0, 0, display);
    }

    faction.Player?.PlaySound(SoundLibrary.Completed);
  }

  /// <summary>
  /// Indicates to the provided question that the quest has been discovered.
  /// </summary>
  public static void DisplayDiscovered(this Faction faction, QuestData questData, bool displayFlavour)
  {
    var display = $"\n|cffffcc00QUEST DISCOVERED - {questData.Title}|r\n";

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

    if (faction.Player != null && faction.Player.GetPlayerSettings().ShowQuestText)
    {
      DisplayTextToPlayer(faction.Player, 0, 0, display);
    }

    var sound = SoundLibrary.Discovered;
    faction.Player?.PlaySound(sound);
    faction.Player?.FlashQuests();
  }
}
