using WCSharp.Events;
using AzerothWarsCSharp.Common;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Spells
{
  public class MassAnySpell
  {
    private readonly MassAnySpellEffectDefinition _definition;

    private void OnSpellEffect()
    {
      BJDebugMsg("a");
      BJDebugMsg(GetObjectName(_definition.RawCode));
    }

    public void Register()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, OnSpellEffect, _definition.RawCode);
    }

    public MassAnySpell(MassAnySpellEffectDefinition massAnySpellDefinition)
    {
      _definition = massAnySpellDefinition;
    }

    public static void Initialize()
    {
      BJDebugMsg("b");
      foreach (var massAnySpellDefinition in MassAnySpellEffectDefinition.All)
      {
        new MassAnySpell(massAnySpellDefinition).Register();
        BJDebugMsg("Z");
      }
      BJDebugMsg("c");
    }
  }

}