using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
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
    /// <param name="feathermoon"></param>
    /// <param name="rescueRect"></param>
    public QuestZandalar(Capital feathermoon, Rectangle rescueRect) : base("City of Gold", "We need to regain control of our land.",
      "ReplaceableTextures\\CommandButtons\\BTNBloodTrollMage.blp")
    {
      AddObjective(new ObjectiveCapitalDead(feathermoon));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_O03Z_FORTRESS_ZANDALARI_T3, Constants.UNIT_O03Y_STRONGHOLD_ZANDALARI_T2));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R04W_QUEST_COMPLETED_CITY_OF_GOLD;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The City of Gold is now yours to command and has joined the Zandalari";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Control of all units in Dazar'alor and enables the Rasthakan to be trained";

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