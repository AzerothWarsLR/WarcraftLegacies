using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Gilneas.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>Gilneas leaves the Alliance to stand with the Night Elves.</summary>
public sealed class PathGilneasNightElves : PathGilneas
{
  public PathGilneasNightElves(GilneasTransformation transformation) : base(transformation)
  {
    Name = "Gilneas: The Night Elves";
    Description = "Gilneas City is free, but a curse stirs among its people that no human priest can mend. Genn Greymane leaves the rest of Dalaran's lands to Lordaeron and turns from the Alliance to the night elves, whose druids may yet know a cure.";
    IntroTemplate =
      "You are now playing as the accursed {faction}.\n\nGenn Greymane has turned from the Alliance to the night elves, hoping their druids can tame the curse spreading through his people. Hold Gilneas City and Greymane's Gate, and fight beside your new allies.\n\nWhen night falls, the curse wakes, and your worgen and wolves fight harder.";
  }

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NightElves;

  /// <inheritdoc />
  protected override void OnFormed(Faction gilneas) =>
    gilneas.DisplayDiscovered(gilneas.AddQuest(new QuestBehindTheWall(AllLegends.Gilneas.GilneasCastle, true)), false);
}
