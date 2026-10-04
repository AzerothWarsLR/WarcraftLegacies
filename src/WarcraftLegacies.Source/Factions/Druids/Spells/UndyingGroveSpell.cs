using System.Collections.Generic;
using MacroTools.Channels;
using MacroTools.Spells;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Druids.Spells;

public sealed class UndyingGroveSpell : Spell
{
  public required float HealFraction { get; init; }
  public required string AreaEffectPath { get; init; }
  public required string SaveEffectPath { get; init; }

  public UndyingGroveSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, UndyingGroveChannel.OnAnyUnitDamaged);
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    ChannelManager.Add(new UndyingGroveChannel(caster, Id)
    {
      Center = targetPoint,
      Radius = caster.GetAbility(Id).GetAreaOfEffect_aare(0),
      HealFraction = HealFraction,
      AreaEffectPath = AreaEffectPath,
      SaveEffectPath = SaveEffectPath
    });
  }
}

public sealed class UndyingGroveChannel : Channel
{
  private static readonly List<UndyingGroveChannel> _activeChannels = new();
  private readonly HashSet<unit> _savedUnits = new();
  private effect? _areaEffect;

  public required Point Center { get; init; }
  public required float Radius { get; init; }
  public required float HealFraction { get; init; }
  public required string AreaEffectPath { get; init; }
  public required string SaveEffectPath { get; init; }

  public UndyingGroveChannel(unit caster, int spellId) : base(caster, spellId)
  {
  }

  public override void OnCreate()
  {
    _activeChannels.Add(this);
    _areaEffect = effect.Create(AreaEffectPath, Center.X, Center.Y);
  }

  protected override void OnDispose()
  {
    _activeChannels.Remove(this);
    _areaEffect?.Dispose();
    _areaEffect = null;
  }

  public static void OnAnyUnitDamaged()
  {
    if (_activeChannels.Count == 0)
    {
      return;
    }

    var damagedUnit = @event.Unit;
    if (@event.Damage < damagedUnit.Life || damagedUnit.IsUnitType(unittype.Hero) ||
        damagedUnit.IsUnitType(unittype.Structure) || damagedUnit.IsUnitType(unittype.Mechanical) ||
        damagedUnit.IsIllusion)
    {
      return;
    }

    foreach (var channel in _activeChannels.ToArray())
    {
      if (channel.TrySave(damagedUnit))
      {
        return;
      }
    }
  }

  private bool TrySave(unit target)
  {
    if (!Active || target == Caster || _savedUnits.Contains(target) || !target.IsAllyTo(Caster.Owner))
    {
      return false;
    }

    var dx = target.X - Center.X;
    var dy = target.Y - Center.Y;
    if (dx * dx + dy * dy > Radius * Radius)
    {
      return false;
    }

    var heal = target.MaxLife * HealFraction;
    if (Caster.Mana < heal)
    {
      EndChannel();
      return false;
    }

    Caster.Mana -= heal;
    @event.Damage = 0;
    target.Life = heal;
    _savedUnits.Add(target);
    EffectSystem.Add(effect.Create(SaveEffectPath, target, "origin"), 1);
    if (Caster.Mana < 1)
    {
      EndChannel();
    }

    return true;
  }

  private void EndChannel()
  {
    Active = false;
    Caster.IssueOrder("stop");
  }
}
