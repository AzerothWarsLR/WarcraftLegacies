using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.FactionMechanics.Scourge;
using WarcraftLegacies.Source.Objectives;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Dalaran;

public sealed class QuestTheNexus : QuestData
{
  private readonly LegendaryHero _jaina;

  public QuestTheNexus(Capital theFrozenThrone, LegendDalaran legendDalaran, Capital theNexus) : base("The Nexus",
    "The Nexus is a tower of powerful arcane energy, Jaina could absorb it to gain it's power",
    @"ReplaceableTextures\CommandButtons\BTNBlueDragonNexus.blp")
  {
    _jaina = legendDalaran.Jaina;
    AddObjective(new ObjectiveChannelRect(Regions.JainaChannel, "The Nexus", legendDalaran.Jaina, 60, 270, Title));
    AddObjective(new ObjectiveControlLegend(legendDalaran.Jaina, true));
    AddObjective(new ObjectiveEitherOf(new ObjectiveFrozenThroneState(FrozenThroneState.Ruptured), new ObjectiveCapitalDead(theFrozenThrone)));
    AddObjective(new ObjectiveCapitalDead(legendDalaran.Dalaran));
    AddObjective(new ObjectiveDontControlLegend(legendDalaran.Aegwynn));
    AddObjective(new ObjectiveControlCapital(theNexus, false));
    ResearchId = UPGRADE_R03Y_QUEST_COMPLETED_THE_NEXUS;
    Global = true;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Nexus powers have been absorbed by Jaina";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "You become the Nexus faction. You gain multiple new Dragonkin units.";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.ModObjectLimit(UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_H067_MANAFORGE_DALARAN_SPECIALIST, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_N096_EARTH_GOLEM_DALARAN, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_O02U_CRYSTAL_ARTILLERY_DALARAN, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_N0AD_CRYSTAL_GOLEM_DALARAN_HARD_CRYSTAL_CONSTRUCTS, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_H032_BATTLEMAGE_DALARAN, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_N007_KIRIN_TOR_DALARAN_ELITE, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_H022_FARMER_DALARAN_WORKER, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UPGRADE_R06O_IMPROVED_PHASE_BLADE_DALARAN, -Faction.Unlimited);
    completingFaction.ModObjectLimit(UPGRADE_R061_IMPROVED_FORKED_LIGHTNING_DALARAN, -Faction.Unlimited);

    completingFaction.ModObjectLimit(UNIT_U027_STEWARD_OF_MAGIC_NEXUS, 1);
    completingFaction.ModObjectLimit(UNIT_H04A_LORD_OF_THE_NEXUS_NEXUS, 1);
    completingFaction.ModObjectLimit(UNIT_H09N_MATRIARCH_OF_TIRISFAL_DALARAN, -1);

    completingFaction.ModObjectLimit(UNIT_N0A1_CRYSTAL_LORD_NEXUS, 6);
    completingFaction.ModObjectLimit(UNIT_H09C_WHELP_DALARAN, Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_H099_ZEALOT_NEXUS, Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_N0A4_BLUE_DRAGONSPAWN_NEXUS, Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_U025_ELEMENTALIST_NEXUS, 12);
    completingFaction.ModObjectLimit(UNIT_N09T_JUDICATOR_NEXUS, 6);
    completingFaction.ModObjectLimit(UNIT_H09A_DRACONIC_SPIRE_DALARAN_BARRACKS_ALTERNATE, Faction.Unlimited);
    completingFaction.ModObjectLimit(UNIT_H09B_BLUE_DRAGON_ROOST_DALARAN_SIEGE, Faction.Unlimited);

    _jaina.UnitType = UNIT_H04A_LORD_OF_THE_NEXUS_NEXUS;

    completingFaction.Name = "The Nexus";
    completingFaction.Icon = @"ReplaceableTextures\CommandButtons\BTNJaina_Archmage.blp";
    completingFaction.Player.SetState(playerstate.FoodCapCeiling, 250);
  }
}
