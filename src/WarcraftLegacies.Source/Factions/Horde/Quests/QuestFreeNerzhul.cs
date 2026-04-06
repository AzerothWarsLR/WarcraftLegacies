using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Scourge.Mechanics;
using WarcraftLegacies.Source.Objectives;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.Factions.Horde.Quests;

/// <summary>
/// Horde kills the Frozen Throne to get cool stuff for Thrall.
/// </summary>
public sealed class QuestFreeNerzhul : QuestData
{
  private readonly LegendaryHero _thrall;
  private readonly ObjectiveFrozenThroneState _objectiveFrozenThroneState;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestFreeNerzhul"/> class.
  /// </summary>
  public QuestFreeNerzhul(Capital theFrozenThrone, LegendaryHero thrall) : base("Jailor of the Damned",
    "Before he became the Lich King, Ner'zhul was the chieftain and elder shaman of the Shadowmoon Clan. Perhaps something of his former self still survives within the Frozen Throne.",
    @"ReplaceableTextures\CommandButtons\BTNShaman.blp")
  {
    _thrall = thrall;
    _objectiveFrozenThroneState = new ObjectiveFrozenThroneState(FrozenThroneState.Ruptured);
    AddObjective(new ObjectiveEitherOf(new ObjectiveCapitalDead(theFrozenThrone), _objectiveFrozenThroneState));
    AddObjective(new ObjectiveLegendInRect(thrall, Regions.Ice_Crown, "Icecrown"));
  }

  /// <inheritdoc/>
  public override string RewardFlavour => _objectiveFrozenThroneState.State == FrozenThroneState.Ruptured
    ? "The Frozen Throne has been ruptured beyond repair, but Ner'zhul's mangled soul remains imprisoned within. Perhaps the old Shaman will never know peace."
    : "It seems Ner'zhul is finally free from his tortured existence as the bearer of the Helm of Domination.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Thrall gains 10 Strength, 10 Dexterity, and 10 Intelligence";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    _thrall.Unit?.AddHeroAttributes(10, 10, 10);
  }
}
