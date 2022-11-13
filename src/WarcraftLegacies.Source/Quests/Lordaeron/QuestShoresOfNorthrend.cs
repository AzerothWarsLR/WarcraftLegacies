using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static MacroTools.Libraries.GeneralHelpers;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Research 'Northrend Expidition' to gain a base at the shores of Dragonblight.
  /// </summary>
  public sealed class QuestShoresOfNorthrend : QuestData
  {
    private new static readonly int ResearchId = Constants.UPGRADE_R06F_NORTHREND_EXPEDITION_LORDAERON;
    private Legend _arthas => LegendLordaeron.Arthas;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestShoresOfNorthrend"/> class.
    /// </summary>
    public QuestShoresOfNorthrend() : base("Shores of Northrend", "Mal'ganis' citadel lies somewhere within the arctic wastes of the north. In order to assault the Dreadlord, Arthas must first establish a base camp at the shores of Northrend.", "ReplaceableTextures\\CommandButtons\\BTNHumanTransport.blp")
    {
      AddObjective(new ObjectiveControlLegend(_arthas, true));
      AddObjective(new ObjectiveLegendDead(LegendForsaken.Scholomance));
      AddObjective(new ObjectiveResearch(ResearchId, Constants.UNIT_HSHY_ALLIANCE_SHIPYARD_LORDAERON));
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "Crown Prince Arthas, and what remains of his forces, have landed on the shores of Northrend and established a base camp.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "A new base near Dragonblight in Northrend, and Arthas revives there";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      KillNeutralHostileUnitsInRadius(-512, 15776, 2000);
      if (GetOwningPlayer(_arthas.Unit) == completingFaction.Player)
      {
        ReviveHero(_arthas.Unit, 400, 16102, true);
        BlzSetUnitFacingEx(_arthas.Unit, 112);
      }
      if(completingFaction.Player != null)
      {
        CreateStructureForced(completingFaction.Player, Constants.UNIT_H01C_HUNTSMAN_LORDAERON, -513, 16679, (float)(4757993 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_NMRK_MARKETPLACE_LORDAERON, 1280, 16064, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HCTW_CANNON_TOWER, -640, 16576, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HBAR_BARRACKS, -256, 16832, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HALT_ALTAR_OF_KINGS, 416, 16416, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, 8187402, 1686473, (float)(6156587 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, 6240182, 1672541, (float)(4578159 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HGTW_GUARD_TOWER_LORDAERON, -960, 15872, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HDES_DESTROYER_ALLIANCE, 582, 15512, (float)(43173 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HSHY_ALLIANCE_SHIPYARD_LORDAERON, 800, 15776, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HCAS_CASTLE, -512, 15744, (float)(4712389 * MathEx.DegToRad), 512);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HBLA_BLACKSMITH_LORDAERON, 672, 16928, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HFOO_FOOTMAN_LORDAERON, 771, 16064, (float)(06401012 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HGTW_GUARD_TOWER_LORDAERON, -448, 16128, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HWTW_SCOUT_TOWER_LORDAERON, 704, 17152, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HHOU_FARM, -1088, 16576, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_H035_CHAPEL_LORDAERON, -928, 16736, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HFOO_FOOTMAN_LORDAERON, -174, 16631, (float)(3987584 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HFOO_FOOTMAN_LORDAERON, -388, 16871, (float)(4113693 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HFOO_FOOTMAN_LORDAERON, -561, 16521, (float)(602386 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HDES_DESTROYER_ALLIANCE, 251, 15569, (float)(533097 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HBLA_BLACKSMITH_LORDAERON, 800, 16288, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HGTW_GUARD_TOWER_LORDAERON, 1472, 16384, (float)(4712389 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_HKNI_KNIGHT_LORDAERON, 893, 16175, (float)(4130178 * MathEx.DegToRad), 256);
        CreateStructureForced(completingFaction.Player, Constants.UNIT_NCHP_MAGE_LORDAERON, -931, 16554, (float)(5458206 * MathEx.DegToRad), 256);
      }
    
      completingFaction.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}