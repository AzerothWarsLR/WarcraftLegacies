using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using System.Collections.Generic;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class BlackEmpireSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="BlackEmpireSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      PassiveAbilityManager.Register(new NoTargetSpellOnCast(UNIT_E01D_HARBINGER_OF_NY_ALOTHA_YOGG, ABILITY_AXK2_VOID_RIFT_ICON_XKORR)
      {
        DummyAbilityId = ABILITY_AXK1_VOIDBOLTDUMMY_X_KORR_DUMMY_SPELL,
        DummyOrderId = OrderId("fanofknives"),
        ProcChance = 1.0f,
        AbilityWhitelist = new List<int>
        {
          ABILITY_A032_ARCANE_BOMBARDMENT_ORANGE_ANTONIDAS_MEDIVH,
          ABILITY_A013_DEVOUR_MAGIC_GUL_DAN,
          ABILITY_A10U_MANA_BURN_DALARAN_YOGG,
          ABILITY_A11O_BLACK_HOLE_KHADGAR,

        }
      });
    }
  }
}