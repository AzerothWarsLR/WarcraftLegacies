using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Zandalar
{
  /// <summary>
  /// Fully upgrade your main to unlock Zan
  /// </summary>
  public sealed class QuestZandalar : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestZandalar"/> class
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestZandalar(Rectangle rescueRect) : base("City of Gold", "We need to regain control of our land.",
      "ReplaceableTextures\\CommandButtons\\BTNBloodTrollMage.blp")
    {
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R04R_FORTIFIED_HULLS_UNIVERSAL_UPGRADE, Constants.UNIT_O03Z_FORTRESS_ZANDALAR));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_O03Z_FORTRESS_ZANDALAR, Constants.UNIT_O03Y_STRONGHOLD_ZANDALAR));
      AddObjective(new ObjectiveExpire(900));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R04W_QUEST_COMPLETED_CITY_OF_GOLD;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      Required = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The City of Gold is now yours to command and has joined the Zandalari";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Control of all units in Dazar'alor and enables the Golden Fleet to be built";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if(completingFaction.Player != null)
        completingFaction.Player.RescueGroup(_rescueUnits);
      
      if (GetLocalPlayer() == completingFaction.Player) 
        PlayThematicMusic("war3mapImported\\ZandalarTheme.mp3");
    }
  }
}