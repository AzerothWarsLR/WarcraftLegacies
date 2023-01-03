using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// Any player owns the rag pedestal, cast a spell on it, and has a high level hero.
  /// </summary>
  public sealed class QuestRagnaros : QuestData
  {
    private readonly unit _RagPedestal;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRagnaros"/> class.
    /// </summary>
    /// <param name="RagPedestal">The pedestal with the Skull.</param>
    /// 
    public QuestRagnaros(unit RagPedestal) : base("Lord of the Firelands",
      "Ragnaros is hiding in the Firelands, summoning him would enable us to claim Sulfuras, his mighty weapon.",
      "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp")
    {
        AddObjective(new ObjectiveHeroWithLevelInRect(12, Regions.RagnarosSummon, "The Portal to the Firelands")); 
        AddObjective(new ObjectiveControlLevel(
          ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N024_BLACKROCK_DEPTHS_20GOLD_MIN), 15));    
      _RagPedestal = RagPedestal;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Summoning Ragnaros to Blackrock";

    /// <inheritdoc/>
    protected override string CompletionPopup => $" Player has summoned Ragnaros to Blackrock";                 //TODO change this to the summoning player

    /// <inheritdoc/>
    protected override string FailurePopup => 
      "Another faction has summoned Ragnaros";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      LegendNeutral.Ragnaros.ForceCreate(Player(PLAYER_NEUTRAL_AGGRESSIVE), new Point(12332, -10597), 110);
                                                                                                                    //TODO remove pedestal
    }
  }
}