using System.Collections.Generic;
using MacroTools.Buffs;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells
{
  /// <summary>
  /// add specific abilities to the caster for a limited duration.
  /// </summary>
  public sealed class AddAbilityOnCast : Spell
  {
    public LeveledAbilityField<float> Duration { get; init; } = new();
    public int BuffApplicatorID { get; init; }
    public int BuffID { get; init; }
    public IEnumerable<int>? AbilitiesToAdd { get; init; }
    
    public AddAbilityOnCast(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {

      var addSpellonCastBuff = new AddSpellOnCastBuff(caster, caster, BuffApplicatorID, BuffID)
      {
        Duration = Duration.Base + Duration.PerLevel * GetAbilityLevel(caster),
        AbilitiesToAdd = AbilitiesToAdd
      };
      BuffSystem.Add(addSpellonCastBuff);
    }
  }
}