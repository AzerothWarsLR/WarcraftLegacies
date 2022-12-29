using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <summary>
  /// Kill some Murlocs to take control of Southshore.
  /// </summary>
  public sealed class QuestSuramar : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestSuramar(Rectangle rescueRect) : base("The Ruins of Suramar",
      "A small remnant of Illidan's Naga have held on in the Broken Isles, we need to make contact with them",
      "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N08M_SOUTHSHORE_15GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1135));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "TO BE DONE";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in Suramar";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction) => 
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => 
      completingFaction.Player?.RescueGroup(_rescueUnits);
  }
}