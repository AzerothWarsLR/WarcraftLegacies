using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
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
    private readonly List<unit> _rescueUnits;
    private readonly unit _unitToMakeInvulnerable;


    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCapitalCity"/> class.
    /// </summary>
    /// <param name="rescueRect"></param>
    /// <param name="unitToMakeInvulnerable"></param>
    /// <param name="prequisites"></param>
    public QuestCapitalCity(Rectangle rescueRect, unit unitToMakeInvulnerable, IEnumerable<QuestData> prequisites) :
      base("Hearthlands",
        "The territories of Lordaeron are fragmented. Regain control of the old Alliance's hold to secure the kingdom.",
        "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Caerdarrow, false));
      foreach (var prequisite in prequisites)
        AddObjective(new ObjectiveCompleteQuest(prequisite));
      AddObjective(new ObjectiveExpire(1472));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R04Y_QUEST_COMPLETED_HEARTHLANDS;
      _unitToMakeInvulnerable = unitToMakeInvulnerable;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
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
      completingFaction.Player?.RescueGroup(_rescueUnits);
      SetUnitInvulnerable(_unitToMakeInvulnerable, true);
      if (GetLocalPlayer() == completingFaction.Player)
        PlayThematicMusic("war3mapImported\\CapitalCity.mp3");
      LegendLordaeron.Uther?.AddUnitDependency(LegendLordaeron.CapitalPalace.Unit);
    }
  }
}