using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Artifacts;
using MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace MacroTools.Legends;

/// <summary>
/// An important hero, such as Arthas or Illidan.
/// </summary>
public sealed class LegendaryHero : Legend
{
  private readonly playercolor? _playerColor;
  private readonly int _dummyDieswithout = FourCC("LEgn");
  private readonly int _dummyPermadies = FourCC("LEgo");
  private List<unit>? _diesWithout;
  private trigger? _castTrig;
  private trigger? _becomesRevivableTrig;
  private trigger? _ownerTrig;
  private readonly string? _name;
  private bool _permaDies;

  /// <summary>
  /// If true, the <see cref="Legend"/> has a custom <see cref="playercolor"/> rather than having its color based
  /// on its owning player.
  /// </summary>
  public bool HasCustomColor { get; private init; }

  /// <summary>
  ///   Fired when the <see cref="Legend" /> permanently dies.
  /// </summary>
  public event EventHandler<LegendDiedEventArgs>? Died;

  /// <summary>
  /// Invoked when the <see cref="LegendaryHero"/> deals damage.
  /// </summary>
  public event EventHandler? DealtDamage;

  /// <summary>
  ///   If true, the Legend is permanently removed from the game upon death.
  /// </summary>
  public bool PermaDies
  {
    set
    {
      _permaDies = value;
      RefreshDummy();
    }
  }

  /// <summary>
  /// A user-friendly name for the <see cref="Legend"/>.
  /// If this hasn't been set, the system will guess an appropriate name based on the <see cref="Legend"/> unit type.
  /// </summary>
  public string Name
  {
    get
    {
      if (!string.IsNullOrEmpty(_name))
      {
        return _name;
      }

      if (Unit == null && UnitType != 0)
      {
        return GetObjectName(UnitType);
      }

      return Unit?.GetProperName() ?? "";
    }
  }

  /// <summary>
  ///   The colour of the Legend's in-game model.
  /// </summary>
  public playercolor? PlayerColor
  {
    get => _playerColor;
    init
    {
      _playerColor = value;
      HasCustomColor = true;
      if (Unit != null)
      {
        Unit.SetColor(_playerColor);
      }
    }
  }

  /// <summary>
  /// How much experience a hero should not distribute when refunded. Must be set manually per hero.
  /// </summary>
  public int StartingXp { get; set; }

  /// <summary>
  /// The special effect that appears when this <see cref="Legend"/> dies permanently.
  /// </summary>
  public string DeathSfx { private get; init; } = @"Abilities\Spells\Demon\DarkPortal\DarkPortalTarget.mdl";

  /// <summary>
  /// The <see cref="LegendaryHero"/> will spawn with these <see cref="Artifact"/>s the first time they are created.
  /// </summary>
  public List<Artifact> StartingArtifacts { get; init; } = new();

  /// <summary>
  /// Initializes a new instance of the <see cref="LegendaryHero"/> class.
  /// </summary>
  public LegendaryHero(string name)
  {
    _name = name;
  }

  /// <summary>
  /// Forces the <see cref="Legend"/> to appear somewhere in the game world as a unit.
  /// <para>If the <see cref="Legend"/> is alive, it moves there. If it's dead, it revives as well. If it doesn't exist,
  /// it gets created.</para>
  /// </summary>
  /// <param name="owner">Which player should own the unit once it's spawned.</param>
  /// <param name="position">Where the unit should spawn.</param>
  /// <param name="facing">Which way the unit should face.</param>
  public void ForceCreate(player owner, Point position, float facing)
  {
    if (Unit == null)
    {
      Unit = unit.Create(owner, UnitType, position.X, position.Y, facing);
      OnChangeOwner(new LegendChangeOwnerEventArgs(this));
    }
    else if (!Unit.Alive)
    {
      Unit.Revive(position.X, position.Y, false);
    }
    else
    {
      Unit.X = position.X;
      Unit.Y = position.Y;
      Unit.SetFacing(facing);
    }
    if (Unit.Owner != owner)
    {
      Unit.SetOwner(owner);
    }

    RefreshDummy();
  }

  /// <summary>
  /// A <see cref="Legend"/> will die permanently if it dies while all of its dependencies are dead or captured.
  /// <para>This removes all of those dependencies.</para>
  /// </summary>
  public void ClearUnitDependencies()
  {
    _diesWithout = null;
    RefreshDummy();
  }

  /// <summary>
  ///   Add an additional unit dependency to this Legend.
  ///   If all of a Legend's unit dependencies are dead or owned by hostile forces,
  ///   the Legend permanently dies upon death.
  /// </summary>
  public void AddUnitDependency(unit whichUnit)
  {
    _diesWithout ??= new();
    _diesWithout.Add(whichUnit);
    RefreshDummy();
  }

  /// <summary>Permanently kills the <see cref="LegendaryHero"/>, preventing it from ever being revived.</summary>
  public void PermanentlyKill()
  {
    OnPermaDeath();
    Died?.Invoke(this, new LegendDiedEventArgs
    {
      LegendaryHero = this,
      Permanent = true
    });
  }

  private void OnBecomesUnrevivable()
  {
    if (_permaDies || AllDependenciesAreMissing())
    {
      PermanentlyKill();
    }
  }

  private void OnDeath()
  {
    Died?.Invoke(this, new LegendDiedEventArgs
    {
      LegendaryHero = this,
      Permanent = false
    });
  }

  private bool AllDependenciesAreMissing()
  {
    if (Unit == null || _diesWithout == null)
    {
      return false;
    }

    var owner = Unit.Owner;

    return !_diesWithout.Any(x => x.Owner == owner && x.Alive);
  }

  /// <inheritdoc />
  protected override void OnChangeUnit()
  {
    if (_becomesRevivableTrig != null)
    {
      _becomesRevivableTrig.Dispose();
    }

    if (_castTrig != null)
    {
      _castTrig.Dispose();
    }

    if (_ownerTrig != null)
    {
      _ownerTrig.Dispose();
    }

    PlayerUnitEvents.Unregister(UnitEvent.Dies, OnDeath, Unit);

    if (Unit == null)
    {
      return;
    }

    _becomesRevivableTrig = trigger.Create();
    _becomesRevivableTrig.RegisterUnitEvent(Unit, unitevent.HeroRevivable);
    _becomesRevivableTrig.AddAction(OnBecomesUnrevivable);

    PlayerUnitEvents.Register(UnitEvent.Dies, OnDeath, Unit);

    _castTrig = trigger.Create();
    _castTrig.RegisterUnitEvent(Unit, unitevent.SpellFinish);
    _castTrig.AddAction(OnCast);
    _ownerTrig = trigger.Create();
    _ownerTrig.RegisterUnitEvent(Unit, unitevent.ChangeOwner);
    _ownerTrig.AddAction(() =>
    {
      OnChangeOwner(new LegendChangeOwnerEventArgs(this, @event.ChangingUnitPrevOwner));
    });
    PlayerUnitEvents.Register(UnitEvent.Damaging, () =>
    {
      DealtDamage?.Invoke(this, EventArgs.Empty);
    }, Unit);
    Unit.SetColor(HasCustomColor ? _playerColor : Unit.Owner.Color);
    if (Unit.Experience < StartingXp)
    {
      Unit.SetExperience(StartingXp, true);
    }

    if (StartingArtifacts.Count != 0)
    {
      foreach (var artifact in StartingArtifacts)
      {
        ArtifactManager.Register(artifact);
        Unit.AddItemSafe(artifact.Item);
      }
      StartingArtifacts.Clear();
    }

    RefreshDummy();
  }

  private void OnPermaDeath()
  {
    if (Unit.IsUnitType(unittype.Hero))
    {
      var tempEffect = effect.Create(DeathSfx, Unit.X, Unit.Y);
      tempEffect.Scale = 2;
      tempEffect.Dispose();
      if (Unit != null)
      {
        Unit.DropAllItems();
        Unit.Dispose();
      }
    }

    if (string.IsNullOrEmpty(DeathMessage))
    {
      return;
    }

    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      player.DisplayTextTo(Unit.Owner == player.NeutralAggressive
          ? $"\n|cffffcc00LEGENDARY FOE SLAIN|r\n{DeathMessage}"
          : $"\n|cffffcc00HERO SLAIN|r\n{DeathMessage}");
    }
  }

  private void RefreshDummy()
  {
    if (_permaDies)
    {
      Unit.AddAbility(_dummyPermadies);
      return;
    }

    Unit.RemoveAbility(_dummyPermadies);
    if (_diesWithout != null)
    {
      var tooltip = "When this unit dies, it will be unrevivable unless any of the following capitals are under your control:\n";
      foreach (var unit in _diesWithout)
      {
        if (unit == null)
        {
          continue;
        }

        tooltip = tooltip + " - " + unit.Name + "|n";
      }

      tooltip += "\nUsing this ability pings each of these capitals on the minimap.";
      Unit.AddAbility(_dummyDieswithout);
      Unit.GetAbility(_dummyDieswithout).SetTooltipNormalExtended_aub1(0, tooltip);
      return;
    }

    Unit.RemoveAbility(_dummyDieswithout);
  }

  private void OnCast()
  {
    if (@event.SpellAbilityId != _dummyDieswithout)
    {
      return;
    }

    if (_diesWithout != null)
    {
      var triggerPlayer = @event.Player;

      foreach (var unit in _diesWithout)
      {
        if (unit == null)
        {
          continue;
        }

        triggerPlayer.PingMinimapSimple(unit.X, unit.Y, 5);
      }
    }
  }
}
