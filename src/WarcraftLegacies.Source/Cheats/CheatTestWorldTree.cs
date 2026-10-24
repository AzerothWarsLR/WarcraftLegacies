using MacroTools.Commands;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Sends Archimonde to the World Tree so his channel there can be tested.</summary>
public sealed class CheatTestWorldTree : Command
{
  private const float StartDistance = 600;

  /// <inheritdoc />
  public override string CommandText => "testworldtree";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Puts Archimonde next to the World Tree and walks him in to start channeling.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (!FactionManager.TryGetFactionByType<LegionFaction>(out var legion) || legion.Player == null)
    {
      return "Nobody is playing the Burning Legion.";
    }

    var target = Regions.ArchimondeChannel.Rect;
    var archimonde = AllLegends.Legion.Archimonde;
    archimonde.ForceCreate(legion.Player, new Point(target.CenterX - StartDistance, target.CenterY), 0);
    archimonde.Unit?.IssueOrder(ORDER_MOVE, target.CenterX, target.CenterY);

    var progress = legion.GetQuestByType<QuestConsumeTree>().Progress;
    return $"Archimonde is walking to the World Tree. Twilight of the Gods is {progress}.";
  }
}
