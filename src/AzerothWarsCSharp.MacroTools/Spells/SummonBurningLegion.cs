using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;
using AzerothWarsCSharp.MacroTools.SpellSystem;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class SummonBurningLegion : Spell
  {
    private readonly int _spellImmunityAbilityId;
    private readonly int _requiredResearchId;

    /// <summary>
    /// Summons the Burning Legion.
    /// </summary>
    /// <param name="id">The ID of the ability.</param>
    /// <param name="spellImmunityAbilityId">The ID of an ability that confers Spelll Immmunity passively.</param>
    /// <param name="requiredResearchId">The ID of a research which is required to cast this spell.
    /// This gets disabled for all players while the spell is being cast to ensure it can only be cast by one player at a time.</param>
    public SummonBurningLegion(int id, int spellImmunityAbilityId, int requiredResearchId) : base(id)
    {
      _spellImmunityAbilityId = spellImmunityAbilityId;
      _requiredResearchId = requiredResearchId;
    }

    public override void OnStop(unit caster)
    {
      UnitRemoveAbility(caster, _spellImmunityAbilityId);
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        SetPlayerTechResearched(player, _requiredResearchId, 1);
      }
    }

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      UnitAddAbility(caster, _spellImmunityAbilityId);
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        SetPlayerTechResearched(player, _requiredResearchId, 0);
      }
    }
  }
}