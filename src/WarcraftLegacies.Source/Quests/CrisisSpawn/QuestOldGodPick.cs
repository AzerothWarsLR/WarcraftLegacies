using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using System;
using WCSharp.Shared.Data;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// Research 'Northrend Expidition' to gain a base at the shores of Dragonblight.
  /// </summary>
  public sealed class QuestOldGodPick : QuestData
  {
    private readonly unit _picker;
    private readonly unit _firstpick;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestOldGodPick"/> class.
    /// </summary>
    public QuestOldGodPick(PreplacedUnitSystem preplacedUnitSystem) : base("Pick Old'Gods team", "Enable selecting the Old God factions.", "ReplaceableTextures\\CommandButtons\\BTNHumanTransport.blp")
    {
      _picker = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DQ_CRISIS_TEAM_PICKER);
      _firstpick = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(13068, -29532));
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveResearch(Constants.UPGRADE_R07L_FORTIFIED_HULLS, Constants.UNIT_N0DQ_CRISIS_TEAM_PICKER),
        new ObjectiveTime(1560)));
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Pick the Old Gods team to be the crisis.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You will have the Old God factions to pick from when the Crisis happens";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      Console.WriteLine("DEBUG: OLD GOD PICK 1");
      RemoveUnit(_picker);
      SetUnitOwner(_firstpick, Player(19), true);
      Console.WriteLine("DEBUG: OLD GOD PICK 2 ");
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetPlayerTechResearched(player, Constants.UPGRADE_R06D_TEAM_PICKED_OLD_GODS, 1);
      }

    }
  }
 }