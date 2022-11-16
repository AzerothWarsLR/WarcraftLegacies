using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// The Militia become the Scarlet Crusade, becoming much stronger but leaving the Alliance.
  /// </summary>
  public sealed class QuestScarletCrusade : QuestData
  {
    private const int UnleashTheCrusadeResearchId = Constants.UPGRADE_R03P_FORTIFIED_HULLS_SCARLET_CRUSADE;
    private readonly List<unit> _rescueUnits;
    private readonly unit _scarletMonasteryEntrance;
    private readonly QuestData _sequel;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestScarletCrusade"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    /// <param name="scarletMonasteryEntrance">This waygate starts hidden and is revealed when the quest is complete.</param>
    /// <param name="sequel">This quest shows when the <see cref="QuestScarletCrusade"/> is completed.</param>
    public QuestScarletCrusade(Rectangle rescueRect, unit scarletMonasteryEntrance, QuestData sequel) : base(
      "The Secret Cloister",
      "The Scarlet Monastery is the perfect place for the secret base of the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
    {
      _scarletMonasteryEntrance = scarletMonasteryEntrance.Show(false);
      AddObjective(new ObjectiveResearch(UnleashTheCrusadeResearchId, Constants.UNIT_H00T_SCARLET_MONASTERY_LORDAERON));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03F_QUEST_COMPLETED_UNLEASH_THE_CRUSADE;
      Global = true;
      _sequel = sequel;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    }

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The Scarlet Monastery Hand is complete and ready to join the Alliance.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in the Scarlet Monastery and you will unally the alliance";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction) => 
      completingFaction.Player?.RescueGroup(_rescueUnits);

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(KultirasSetup.Kultiras.Player,
        Constants.UPGRADE_R06V_SCARLET_CRUSADE_IS_UNLEASHED, 1);
      SetPlayerTechResearched(LordaeronSetup.Lordaeron.Player,
        Constants.UPGRADE_R06V_SCARLET_CRUSADE_IS_UNLEASHED, 1);
      SetPlayerTechResearched(ScarletSetup.ScarletCrusade.Player, Constants.UPGRADE_R086_PATH_CHOSEN, 1);
      _scarletMonasteryEntrance
        .Show(true)
        .SetWaygateDestination(Regions.Scarlet_Monastery_Interior.Center);
      completingFaction.Player?.RescueGroup(_rescueUnits);
      completingFaction.Player?.SetTeam(TeamSetup.ScarletCrusade);
      completingFaction.Name = "Scarlet";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNSaidan Dathrohan.blp";
      PlayThematicMusic("war3mapImported\\ScarletTheme.mp3");
      SetPlayerState(completingFaction.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
      completingFaction.AddQuest(_sequel);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction) => 
      whichFaction.ModObjectLimit(UnleashTheCrusadeResearchId, 1);
  }
}