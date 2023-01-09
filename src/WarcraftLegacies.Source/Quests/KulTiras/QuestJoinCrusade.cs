using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// The player join the Scarlet Crusade.
  /// </summary>
  public sealed class QuestJoinCrusade : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestJoinCrusade"/> class.
    /// </summary>
    public QuestJoinCrusade() : base("Join the Crusade",
      "Daelin Proudmoore sees the plight of the Scarlet Crusade. As fellow human survivors of horrible war, they should join forces with Kul'tiras",
      "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
    {
      AddObjective(new ObjectiveCastSpell(Constants.ABILITY_A0JB_JOIN_THE_CRUSADE_KULTIRASPATH, true));
      ResearchId = Constants.UPGRADE_R06U_QUEST_COMPLETED_JOIN_THE_CRUSADE;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "Kul'tiras has joined the Scarlet Crusade";

    /// <inheritdoc/>
    protected override string RewardDescription => "Unlock Order Inquisitor and join the Scarlet Crusade";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      UnitRemoveAbility(LegendKultiras.LegendAdmiral.Unit, Constants.ABILITY_A0JB_JOIN_THE_CRUSADE_KULTIRASPATH);
      completingFaction.Player?.SetTeam(TeamSetup.ScarletCrusade);
    }
  }
}