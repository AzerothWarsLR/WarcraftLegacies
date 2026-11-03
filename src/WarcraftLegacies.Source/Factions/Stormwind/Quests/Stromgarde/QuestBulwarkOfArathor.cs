using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;

namespace WarcraftLegacies.Source.Factions.Stormwind.Quests.Stromgarde;

/// <summary>Hold the highlands from Stromgarde to Alterac, as Thoradin's wall once did.</summary>
public sealed class QuestBulwarkOfArathor : QuestData
{
  private const int GoldReward = 300;

  public QuestBulwarkOfArathor() : base("Bulwark of Arathor",
    "King Thoradin once walled off the Arathi Highlands against all comers. Secure the highlands from Stromgarde to the mountains of Alterac and stand as his wall did.",
    @"ReplaceableTextures\CommandButtons\BTNStromgardeCastle.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01K_STROMGARDE, 0));
    AddObjective(new ObjectiveControlPoint(UNIT_N01Z_ARATHI_HIGHLANDS, 0));
    AddObjective(new ObjectiveControlPoint(UNIT_N019_ALTERAC_MOUNTAINS));
    ResearchId = UPGRADE_R11X_BULWARK_OF_ARATHOR_STROMGARDE;
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "The highlands are held from Stromgarde to Alterac. Thoradin's wall stands again in the hearts of his people.";

  /// <inheritdoc/>
  protected override string RewardDescription => "300 gold, and all of your units gain 50 hit points";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner != null)
    {
      owner.Gold += GoldReward;
    }
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
