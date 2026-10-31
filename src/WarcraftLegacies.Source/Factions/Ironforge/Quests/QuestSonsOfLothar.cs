using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Bring down the Black Temple to make Kurdran a veteran of the Sons of Lothar.</summary>
public sealed class QuestSonsOfLothar : QuestData
{
  private const int BonusLevels = 2;
  private readonly LegendaryHero _kurdran;

  public QuestSonsOfLothar(Capital blackTemple, LegendaryHero kurdran) : base("Sons of Lothar",
    "Kurdran once flew through the Dark Portal with the Sons of Lothar to end the Horde's threat at its source. The Black Temple is the heart of that threat. Bring it down.",
    @"ReplaceableTextures\CommandButtons\BTNWildhammerSkymaster.blp")
  {
    _kurdran = kurdran;
    AddObjective(new ObjectiveCapitalDead(blackTemple));
    ResearchId = UPGRADE_R119_SONS_OF_LOTHAR_WILDHAMMER;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Black Temple has fallen. Kurdran returns from Outland a hardened veteran.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "{kurdran} gains 2 levels and the cooldown of Call of the Aerie is halved",
    ("{kurdran}", Loc.Get(_kurdran.Name)));

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var kurdran = _kurdran.Unit;
    if (kurdran != null)
    {
      kurdran.SetLevel(kurdran.HeroLevel + BonusLevels);
    }
  }
}
