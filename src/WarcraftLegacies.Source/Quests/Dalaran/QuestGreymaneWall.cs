using System.Collections.Generic;
using System.IO;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
  /// <summary>
  /// Dalaran unlocks and takes control of Gilneas.
  /// </summary>
  public sealed class QuestGreymaneWall : QuestData
  {
    private readonly unit _gilneasDoor;
    private readonly ObjectiveAnyUnitInRect _enterGilneasGateRegion;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGreymaneWall"/> class.
    /// </summary>
    /// /// <param name="gilneasDoor">This unit will be transferred to the completeing player.</param>
    public QuestGreymaneWall(unit gilneasDoor) : base("Greymane Wall",
      "The Gilneans, fearful of a potential invasion from the frozen north, sealed themselves behind the Greymane Wall. If we are to survive the coming storm, we must force our neighbour back out into the open.",
      @"ReplaceableTextures\CommandButtons\BTNGate.blp")
    {
      _gilneasDoor = gilneasDoor;
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01D_SILVERPINE_FOREST)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01B_DALARAN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_H068_OBSERVATORY_DALARAN_T3, Constants.UNIT_H065_REFUGE_DALARAN_T1));
      AddObjective(_enterGilneasGateRegion = new ObjectiveAnyUnitInRect(Regions.GilneasUnlock5, "Gilneas Gate", true));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_RD03_QUEST_COMPLETED_INVESTIGATE_GILNEAS;
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      $"{_enterGilneasGateRegion.CompletingUnitName} smashes down the gate to Gilneas. What lies behind the Greymane Wall reveals a tragic history: the Gilneans have already fallen to the Worgen curse. There is nothing more to be done, other than to put them out of their misery.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Gain control of Gilneas gate.";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player == null)
        return;
      _gilneasDoor
        .SetInvulnerable(false);
      SetUnitOwner(_gilneasDoor, completingFaction.Player, true);

      completingFaction.Player
        .PlayMusicThematic("war3mapImported\\DalaranTheme.mp3");

      AddSpecialEffect("Abilities\\Spells\\Human\\DispelMagic\\DispelMagicTarget.mdl", GetUnitX(_gilneasDoor), GetUnitY(_gilneasDoor))
        .SetScale(3)
        .SetLifespan();

      AddSpecialEffect("Units\\NightElf\\Wisp\\WispExplode.mdl", GetUnitX(_gilneasDoor), GetUnitY(_gilneasDoor))
        .SetScale(3)
        .SetLifespan();
    }
  }
}