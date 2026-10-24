using System.Linq;
using MacroTools.Commands;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.FelHorde.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Sets up the Dark Horde quest for the Fel Horde: Blackrock unified, Rend alive, then Stormwind Keep destroyed.
/// </summary>
public sealed class CheatTestDarkHorde : Command
{
  /// <inheritdoc />
  public override string CommandText => "testdarkhorde";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    "Unifies Blackrock, brings Rend to Blackrock Spire and destroys Stormwind Keep so the Fel Horde completes The Dark Horde.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (!FactionManager.TryGetFactionByType<FelHordeFaction>(out var felHorde) || felHorde.Player == null)
    {
      return "The Fel Horde isn't in the game.";
    }

    var quest = felHorde.GetAllQuests().OfType<QuestDarkHorde>().FirstOrDefault();
    if (quest == null)
    {
      return "The Fel Horde has no Dark Horde quest. Is this Roleplay mode?";
    }

    var blackrock = felHorde.GetQuestByType<QuestBlackrock>();
    if (blackrock.Progress != QuestProgress.Complete)
    {
      blackrock.SuppressCompletionDisplay = true;
      blackrock.Progress = QuestProgress.Complete;
    }

    var rend = AllLegends.FelHorde.Rend;
    var rendUnit = rend.Unit;
    if (rendUnit == null || !rendUnit.Alive)
    {
      var spire = AllLegends.FelHorde.BlackrockSpire.Unit;
      rend.ForceCreate(felHorde.Player, new Point(spire.X + 300f, spire.Y), 270);
    }

    var keep = AllLegends.Stormwind.StormwindKeep.Unit;
    if (keep != null && keep.Alive)
    {
      keep.Kill();
    }

    return "Blackrock is unified, Rend is at Blackrock Spire and Stormwind Keep is destroyed.";
  }
}
