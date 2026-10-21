using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Sentinels.Paths;

/// <summary>Lets the Sentinels leave the Night Elves once Illidan joins them. Declining loses Maiev.</summary>
public abstract class PathWardensVengeance : FactionPath
{
  protected PathWardensVengeance(ObjectiveTriggered illidanReturned)
  {
    IconName = "HeroWarden";
    DeclineDescription = "The Sentinels set aside their hatred and fight beside the Betrayer. Maiev will not, and leaves for good.";
    AddRequirement(illidanReturned);
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override void OnDeclined(Faction faction)
  {
    var maiev = AllLegends.Sentinels.Maiev;
    faction.ModObjectLimit(maiev.UnitType, -faction.GetObjectLimit(maiev.UnitType));
    if (maiev.Unit != null)
    {
      maiev.Unit = null;
    }
  }
}
