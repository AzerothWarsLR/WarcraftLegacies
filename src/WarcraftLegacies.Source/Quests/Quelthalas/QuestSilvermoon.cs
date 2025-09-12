using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  /// <summary>
  /// Kill the Trolls attacking Silvermoon.
  /// </summary>
  public sealed class QuestSilvermoon : QuestData
  {
    private readonly unit _elvenRunestone;
    private readonly Capital _silvermoon;
    private readonly Capital _sunwell;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestSilvermoon"/> class.
    /// </summary>
    public QuestSilvermoon(Rectangle rescueRect, unit elvenRunestone, Capital silvermoon, Capital sunwell) : base(
      "The Siege of Silvermoon",
      "The Amani Trolls have been harassing Silvermoon since its founding, but their defensive position within their jungle has made the prospect of an all-out assault too costly. Today, however, the Amani begins their largest siege yet. They leave us no choice; we must scour Zul'aman if the High Elves are to prosper.",
      @"ReplaceableTextures\CommandButtons\BTNForestTrollTrapper.blp")
    {
      _elvenRunestone = elvenRunestone;
      _silvermoon = silvermoon;
      _sunwell = sunwell;
      AddObjective(new ObjectiveControlPoint(UNIT_N01V_ZUL_AMAN));
      AddObjective(new ObjectiveControlPoint(UNIT_N01L_EVERSONG_WOODS));
      AddObjective(new ObjectiveUpgrade(UNIT_H03T_PALACE_QUEL_THALAS_T3, UNIT_H033_STEADING_QUEL_THALAS_T1));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_R02U_QUEST_COMPLETED_THE_SIEGE_OF_SILVERMOON;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      
      ResearchId = UPGRADE_R02U_QUEST_COMPLETED_THE_SIEGE_OF_SILVERMOON;
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "The Amani trolls have been eliminated, settling a racial feud that had persisted for millenia.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Silvermoon, unlock the Summon Mystic Defenders ability from Elven Runestones and enable Anasterian to be trained at the Altar";

    /// <inheritdoc />

    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
      if (UnitAlive(_elvenRunestone))
        if (_silvermoon.Unit != null) 
          SetUnitInvulnerable(_silvermoon.Unit, true);
      
      if (_sunwell.Unit != null) 
        SetUnitInvulnerable(_sunwell.Unit, true);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player
        .RescueGroup(_rescueUnits)
        .PlayMusicThematic("war3mapImported\\SilvermoonTheme.mp3");

      if (_silvermoon.Unit == null) 
        return;

      if (UnitAlive(_elvenRunestone)) 
        SetUnitInvulnerable(_silvermoon.Unit, true);
        
      SetUnitInvulnerable(_sunwell.Unit, true);
    }
  }
}
