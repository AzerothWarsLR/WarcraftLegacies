using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Paths;

/// <summary>Betrayed by the orcs, the tauren must find new allies or stand alone.</summary>
public abstract class PathFindNewAllies : FactionPath
{
  private const float ChoiceDuration = 120;

  private readonly ObjectiveTriggered _betrayed;

  protected PathFindNewAllies()
  {
    IconName = "HeroTaurenChieftain";
    OfferDuration = ChoiceDuration;
    _betrayed = new ObjectiveTriggered("The orcs have drunk the blood of Mannoroth") { ShowsInQuestLog = false };
    AddRequirement(_betrayed);
  }

  /// <summary>Offers the path, since the orcs have betrayed the tauren.</summary>
  public void Open() => _betrayed.Trigger();

  /// <inheritdoc />
  public override bool ChangesTeam => true;
}
