using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Gilneas.Quests;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>Gilneas leaves the Alliance and shuts itself away behind the Greymane Wall.</summary>
public sealed class PathGilneasGreymaneWall : PathGilneas
{
  public PathGilneasGreymaneWall(GilneasTransformation transformation) : base(transformation)
  {
    Name = "Gilneas: The Greymane Wall Solo";
    Description = "Gilneas City is free, and Genn Greymane has bled enough for the Alliance's wars. He leaves the rest of Dalaran's lands to Lordaeron, seals the Greymane Wall and goes solo, trusting no one beyond it.";
    CanGoSolo = true;
    IntroTemplate =
      "You are now playing as the proud {faction}.\n\nGenn Greymane has sealed the Greymane Wall, and Gilneas trusts no one beyond it. Hold Gilneas City and Greymane's Gate against every army that comes.\n\nWhen night falls, the curse in your people's blood wakes, and your worgen fight harder still while Gilneas stands alone.";
  }

  /// <inheritdoc />
  protected override void OnFormed(Faction gilneas) =>
    gilneas.DisplayDiscovered(gilneas.AddQuest(new QuestBehindTheWall(AllLegends.Gilneas.GilneasCastle, false)), false);
}
