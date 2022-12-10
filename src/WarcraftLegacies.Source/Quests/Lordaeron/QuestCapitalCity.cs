using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Capture <see cref="LegendNeutral.Caerdarrow"/> to unlock the capital city of Lordaeron.
  /// </summary>
  public sealed class QuestCapitalCity : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _unitToMakeInvulnerable;
    private readonly LegendaryHero _uther;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCapitalCity"/> class.
    /// </summary>
    public QuestCapitalCity(Rectangle rescueRect, unit unitToMakeInvulnerable, LegendaryHero uther, IEnumerable<QuestData> prequisites) :
      base("Hearthlands",
        "The territories of Lordaeron are fragmented. Regain control of the old Alliance's hold to secure the kingdom.",
        "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendNeutral.Caerdarrow, false));
      foreach (var prequisite in prequisites)
        AddObjective(new ObjectiveCompleteQuest(prequisite));
      AddObjective(new ObjectiveExpire(1472));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R04Y_QUEST_COMPLETED_HEARTHLANDS;
      _unitToMakeInvulnerable = unitToMakeInvulnerable;
      _uther = uther;
      var rescueUnitFilter = (unit whichUnit) => GetUnitTypeId(whichUnit) != Constants.UNIT_N08F_UNDERCITY_ENTRANCE;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures, rescueUnitFilter);
      Required = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The Capital City of Lordaeron has been literated.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in the Capital City";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
        completingFaction.Player.RescueGroup(_rescueUnits);
      SetUnitInvulnerable(_unitToMakeInvulnerable, true);
      if (GetLocalPlayer() == completingFaction.Player)
        PlayThematicMusic("war3mapImported\\CapitalCity.mp3");
      _uther.AddUnitDependency(LegendLordaeron.CapitalPalace.Unit);
    }
  }
}