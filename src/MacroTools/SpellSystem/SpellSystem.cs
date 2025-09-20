using System;
using System.Collections.Generic;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace MacroTools.SpellSystem;

/// <summary>
/// Provides a way to extend the functionality of existing Warcraft 3 spells and passive abilities
/// by adding extra code on top of their normal effects.
/// </summary>
public static class SpellSystem
{
  private static readonly Dictionary<int, Spell> _spellsByAbilityId = new();

  /// <summary>
  /// Returns the registered <see cref="Spell"/> with the provided ability ID.
  /// </summary>
  /// <exception cref="Exception">Thrown if there is no ability with the provided ID.</exception>
  public static Spell GetSpellByAbilityId(int abilityId)
  {
    if (!_spellsByAbilityId.ContainsKey(abilityId))
    {
      throw new Exception($"There is no Spell with abilityId {abilityId}.");
    }

    return _spellsByAbilityId[abilityId];
  }

  /// <summary>
  ///   Registers the provided <see cref="Spell"/> to the <see cref="SpellSystem"/>, causing its functionality
  /// to be invoked when a Warcraft 3 spell matching its IDs is used.
  /// </summary>
  public static void Register(Spell spell)
  {
    PlayerUnitEvents.Register(SpellEvent.Cast, OnStartCast, spell.Id);
    PlayerUnitEvents.Register(SpellEvent.Effect, OnCast, spell.Id);
    PlayerUnitEvents.Register(SpellEvent.EndCast, OnStop, spell.Id);
    PlayerUnitEvents.Register(SpellEvent.Learned, OnLearn, spell.Id);
    if (spell is IStartChannelEffect)
    {
      PlayerUnitEvents.Register(SpellEvent.Channel, OnStartChannel, spell.Id);
    }

    _spellsByAbilityId.Add(spell.Id, spell);
  }

  private static void OnStartChannel()
  {
    var startChannelEffect = _spellsByAbilityId[GetSpellAbilityId()] as IStartChannelEffect;
    startChannelEffect!.OnStartChannel(GetTriggerUnit(), new Point(GetSpellTargetX(), GetSpellTargetY()));
  }

  private static void OnStop() =>
    _spellsByAbilityId[GetSpellAbilityId()]
      .OnStop(GetTriggerUnit());

  private static void OnCast() =>
    _spellsByAbilityId[GetSpellAbilityId()]
      .OnCast(GetTriggerUnit(), GetSpellTargetUnit(), new Point(GetSpellTargetX(), GetSpellTargetY()));

  private static void OnStartCast() =>
    _spellsByAbilityId[GetSpellAbilityId()]
      .OnStartCast(GetTriggerUnit(), GetSpellTargetUnit(), new Point(GetSpellTargetX(), GetSpellTargetY()));

  private static void OnLearn() => _spellsByAbilityId[GetLearnedSkill()].OnLearn(GetTriggerUnit());
}
