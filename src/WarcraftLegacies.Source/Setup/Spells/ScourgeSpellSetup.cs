using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using System.Collections.Generic;
using WarcraftLegacies.Source.Mechanics.Scourge;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Scourge <see cref="Spell"/>s.
  /// </summary>
  public static class ScourgeSpellSetup
  {
    /// <summary>
    /// Sets up all Scourge <see cref="Spell"/>s.
    /// </summary>
    public static void Setup()
    {
      var unaffectedUnitIds = new List<int>
      {
        Constants.UNIT_O04E_BONESEER_TROLL,
        Constants.UNIT_N03F_KOR_KRON_ELITE_WARSONG_ELITE,
        Constants.UNIT_H05F_STORMWIND_CHAMPION_STORMWIND_ELITE,
        Constants.UNIT_H04L_PRIESTESS_OF_THE_MOON_SENTINELS_ELITE,
        Constants.UNIT_H00H_DEATH_KNIGHT_SCOURGE_ELITE,
        Constants.UNIT_H06B_TEMPLAR_LORDAERON,
        Constants.UNIT_N09N_BISHOP_OF_THE_LIGHT_SCARLET,
        Constants.UNIT_O00X_ARCHANGEL_SCARLET,
        Constants.UNIT_N00A_FARSTRIDER_QUEL_THALAS_ELITE,
        Constants.UNIT_H00F_PALADIN_LORDAERON,
        Constants.UNIT_U007_DREADLORD_LEGION_ELITE,
        Constants.UNIT_N04O_DOOM_LORD_LEGION,
        Constants.UNIT_N07G_MUSKETEER_KUL_TIRAS,
        Constants.UNIT_H01L_THANE_IRONFORGE_ELITE,
        Constants.UNIT_NNRG_ROYAL_GUARD_ILLIDARI,
        Constants.UNIT_H0AC_NAGA_SEA_WITCH_ILLIDARI_ELITE,
        Constants.UNIT_H08W_DEMON_HUNTER_LIGHT_BLUE,
        Constants.UNIT_O04Q_TINKER_GOBLIN,
        Constants.UNIT_O01V_GREYGUARD_GILNEAS,
        Constants.UNIT_O00A_FAR_SEER_FROSTWOLF_ELITE,
        Constants.UNIT_O01L_EXECUTIONER_FEL_HORDE_ELITE,
        Constants.UNIT_E00N_KEEPER_OF_THE_GROVE_DRUIDS_ELITE,
        Constants.UNIT_O04I_BATTLEMASTER_TWILIGHT,
        Constants.UNIT_N09O_ORCISH_DEATH_KNIGHT_TWILIGHT,
        Constants.UNIT_H09R_VINDICATOR_DRAENEI,
        Constants.UNIT_N007_KIRIN_TOR_DALARAN_ELITE,
        Constants.UNIT_N096_EARTH_GOLEM_DALARAN,
        Constants.UNIT_N0A1_CRYSTAL_LORD_NEXUS
      };

      SpellSystem.Register(new SingleTargetRecall(Constants.ABILITY_A0W8_RECALL_FROZEN_THRONE));

      PassiveAbilityManager.Register(new PersistentSoul(Constants.UNIT_N009_REVENANT_SCOURGE,
        Constants.ABILITY_A05L_PERSISTENT_SOUL_SCOURGE_REVENANT, unaffectedUnitIds)
      {
        ReanimationCountLevel = 1,
        Duration = 40,
        BuffId = Constants.BUFF_B069_PERSISTENT_SOUL_FORSAKEN_PLAGUE_REVENANT,
        Radius = 700
      });
      Plagueling.Setup(); //Todo: convert this into being a proper passive ability


      var massUnholyFrenzy = new MassAnySpell(Constants.ABILITY_A02W_MASS_UNHOLY_FRENZY_SCOURGE)
      {
        DummyAbilityId = Constants.ABILITY_ACUF_UNHOLY_FRENZY_DUMMY,
        DummyAbilityOrderString = "unholyfrenzy",
        Radius = 250,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massUnholyFrenzy);
    }
  }
}