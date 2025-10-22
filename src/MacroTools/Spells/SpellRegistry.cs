using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace MacroTools.Spells;

/// <summary>
/// Provides a way to extend the functionality of existing Warcraft 3 spells and passive abilities
/// by adding extra code on top of their normal effects.
/// </summary>
public static class SpellRegistry
{
  private static readonly Dictionary<int, Spell> _spellsByAbilityId = new();

  /// <summary>
  /// Returns the registered <see cref="Spell"/> with the provided ability ID.
  /// </summary>
  /// <exception cref="Exception">Thrown if there is no ability with the provided ID.</exception>
  public static Spell GetSpellByAbilityId(int abilityId)
  {
    if (!_spellsByAbilityId.TryGetValue(abilityId, out var spell))
    {
      throw new Exception($"There is no Spell with abilityId {abilityId}.");
    }

    return spell;
  }

  public static bool TryGetSpellByAbilityId(int abilityId, [NotNullWhen(true)] out Spell? spell)
  {
    return _spellsByAbilityId.TryGetValue(abilityId, out spell);
  }

  /// <summary>
  ///   Registers the provided <see cref="Spell"/> to the <see cref="SpellRegistry"/>, causing its functionality
  /// to be invoked when a Warcraft 3 spell matching its IDs is used.
  /// </summary>
  public static void Register(Spell spell)
  {
    PlayerUnitEvents.Register(SpellEvent.Cast, OnStartCast, spell.Id);
    PlayerUnitEvents.Register(SpellEvent.Effect, OnCast, spell.Id);
    PlayerUnitEvents.Register(SpellEvent.EndCast, OnStop, spell.Id);
    switch (spell)
    {
      case IStartChannelEffect:
        PlayerUnitEvents.Register(SpellEvent.Channel, OnStartChannel, spell.Id);
        break;
      case IEffectOnLearn:
        PlayerUnitEvents.Register(SpellEvent.Learned, OnLearn, spell.Id);
        break;
    }

    _spellsByAbilityId.Add(spell.Id, spell);
  }

  private static void OnStartChannel()
  {
    var startChannelEffect = _spellsByAbilityId[@event.SpellAbilityId] as IStartChannelEffect;
    startChannelEffect!.OnStartChannel(@event.Unit, new Point(@event.SpellTargetX, @event.SpellTargetY));
  }

  private static void OnStop() =>
    _spellsByAbilityId[@event.SpellAbilityId]
      .OnStop(@event.Unit);

  private static void OnCast() =>
    _spellsByAbilityId[@event.SpellAbilityId]
      .OnCast(@event.Unit, @event.SpellTargetUnit, new Point(@event.SpellTargetX, @event.SpellTargetY));

  private static void OnStartCast() =>
    _spellsByAbilityId[@event.SpellAbilityId]
      .OnStartCast(@event.Unit, @event.SpellTargetUnit, new Point(@event.SpellTargetX, @event.SpellTargetY));

  private static void OnLearn()
  {
    var learnedSpell = _spellsByAbilityId[@event.LearnedSkill] as IEffectOnLearn;
    learnedSpell?.OnLearn(@event.Unit);
  }
}
