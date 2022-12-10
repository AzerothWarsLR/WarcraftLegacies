using System;
using MacroTools.Extensions;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.LegendSystem
{
  /// <summary>
  /// An important hero, such as Arthas or Illidan.
  /// </summary>
  public sealed class LegendaryHero : Legend
  {
    private playercolor? _playerColor;
    private readonly int _dummyDieswithout = FourCC("LEgn");
    private readonly int _dummyPermadies = FourCC("LEgo");
    private group? _diesWithout;
    private trigger? _castTrig;
    private trigger? _deathTrig;
    private trigger? _ownerTrig;
    private readonly string? _name;
    private bool _permaDies;
    
    /// <summary>
    /// If true, the <see cref="Legend"/> has a custom <see cref="playercolor"/> rather than having its color based
    /// on its owning player.
    /// </summary>
    public bool HasCustomColor { get; private set; }

    /// <summary>
    /// Fired when the <see cref="Legend"/> permanently dies, after it is removed from the game.
    /// </summary>
    public event EventHandler<LegendaryHero>? OnLegendPermaDeath;
    
    /// <summary>
    ///   Fired when the <see cref="Legend" /> permanently dies.
    /// </summary>
    public event EventHandler<LegendaryHero>? PermanentlyDied;
    
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
        if (!string.IsNullOrEmpty(_name)) return _name;

        if (Unit == null && UnitType != 0) return GetObjectName(UnitType);

        return Unit?.GetProperName() ?? "";
      }
      init => _name = value;
    }
    
    /// <summary>
    ///   The colour of the Legend's in-game model.
    /// </summary>
    public playercolor? PlayerColor
    {
      get => _playerColor;
      set
      {
        _playerColor = value;
        HasCustomColor = true;
        if (Unit != null) 
          SetUnitColor(Unit, _playerColor);
      }
    }
    
    /// <summary>
    /// How much experience a hero should not distribute when refunded. Must be set manually per hero.
    /// </summary>
    public int StartingXp { get; set; }
    
    /// <summary>
    /// The special effect that appears when this <see cref="Legend"/> dies permanently.
    /// </summary>
    public string DeathSfx { private get; init; } = "Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl";

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
        Unit = CreateUnit(owner, UnitType, position.X, position.Y, facing);
        OnChangeOwner(new LegendChangeOwnerEventArgs(this));
      }
      else if (!UnitAlive(Unit))
        ReviveHero(Unit, position.X, position.Y, false);
      else
      {
        SetUnitX(Unit, position.X);
        SetUnitY(Unit, position.Y);
        SetUnitFacing(Unit, facing);
      }
      if (GetOwningPlayer(Unit) != owner) 
        SetUnitOwner(Unit, owner, true);

      RefreshDummy();
    }
    
    /// <summary>
    /// A <see cref="Legend"/> will die permanently if it dies while all of its dependencies are dead or captured.
    /// <para>This removes all of those dependencies.</para>
    /// </summary>
    public void ClearUnitDependencies()
    {
      DestroyGroup(_diesWithout);
      _diesWithout = null;
      RefreshDummy();
    }

    /// <summary>
    ///   Add an additional unit dependency to this Legend.
    ///   If all of a Legend's unit dependencies are dead or owned by hostile forces,
    ///   the Legend permanently dies upon death.
    /// </summary>
    public void AddUnitDependency(unit u)
    {
      _diesWithout ??= CreateGroup();
      GroupAddUnit(_diesWithout, u);
      RefreshDummy();
    }
    
    private void OnDeath()
    {
      if (GetOwningPlayer(Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE) && DeathMessage != "" &&
          !string.IsNullOrEmpty(DeathMessage) && !IsUnitType(Unit, UNIT_TYPE_STRUCTURE))
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, $"\n|cffffcc00LEGENDARY CREEP DEATH|r\n{DeathMessage}");

      if (_permaDies || !IsUnitType(Unit, UNIT_TYPE_HERO))
      {
        PermanentlyKill();
        return;
      }

      var anyOwned = false;
      if (_diesWithout == null) return;
      var tempGroup = CreateGroup();
      BlzGroupAddGroupFast(_diesWithout, tempGroup);
      while (true)
      {
        var u = FirstOfGroup(tempGroup);
        if (u == null) break;

        if (GetOwningPlayer(u) == GetOwningPlayer(Unit) && UnitAlive(u)) anyOwned = true;

        GroupRemoveUnit(tempGroup, u);
      }

      if (anyOwned == false) PermanentlyKill();

      DestroyGroup(tempGroup);
    }

    /// <inheritdoc />
    protected override void OnChangeUnit()
    {
      _deathTrig?.Destroy();
      _deathTrig = CreateTrigger()
        .RegisterUnitEvent(Unit, EVENT_UNIT_DEATH)
        .AddAction(OnDeath);

      _castTrig?.Destroy();
      _castTrig = CreateTrigger()
        .RegisterUnitEvent(Unit, EVENT_UNIT_SPELL_FINISH)
        .AddAction(OnCast);

      _ownerTrig?.Destroy();
      _ownerTrig = CreateTrigger()
        .RegisterUnitEvent(Unit, EVENT_UNIT_CHANGE_OWNER)
        .AddAction(() =>
        {
          OnChangeOwner(new LegendChangeOwnerEventArgs(this, GetChangingUnitPrevOwner()));
        });

      SetUnitColor(Unit, HasCustomColor ? _playerColor : GetPlayerColor(GetOwningPlayer(Unit)));
      if (GetHeroXP(Unit) < StartingXp) SetHeroXP(Unit, StartingXp, true);
      
      RefreshDummy();
    }
    
    private void OnPermaDeath()
    {
      if (IsUnitType(Unit, UNIT_TYPE_HERO))
      {
        var tempEffect = AddSpecialEffect(DeathSfx, GetUnitX(Unit), GetUnitY(Unit));
        BlzSetSpecialEffectScale(tempEffect, 2);
        DestroyEffect(tempEffect);
        if (Unit != null)
        {
          Unit.DropAllItems();
          RemoveUnit(Unit);
        }
      }

      if (string.IsNullOrEmpty(DeathMessage)) 
        return;
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, $"\n|cffffcc00HERO SLAIN|r\n{DeathMessage}");
    }

    private void PermanentlyKill()
    {
      if (Hivemind && OwningPlayer != null)
        OwningPlayer.GetFaction()?.Obliterate();

      OnPermaDeath();
      OnLegendPermaDeath?.Invoke(this, this);
      PermanentlyDied?.Invoke(this, this);
    }
    
    private void RefreshDummy()
    {
      if (_permaDies)
      {
        UnitAddAbility(Unit, _dummyPermadies);
        return;
      }

      UnitRemoveAbility(Unit, _dummyPermadies);
      if (_diesWithout != null)
      {
        var tempGroup = CreateGroup();
        var tooltip =
          "When this unit dies, it will be unrevivable unless any of the following capitals are under your control:\n";
        BlzGroupAddGroupFast(_diesWithout, tempGroup);
        while (true)
        {
          var u = FirstOfGroup(tempGroup);
          if (u == null) break;

          tooltip = tooltip + " - " + GetUnitName(u) + "|n";
          GroupRemoveUnit(tempGroup, u);
        }

        tooltip += "\nUsing this ability pings each of these capitals on the minimap.";
        UnitAddAbility(Unit, _dummyDieswithout);
        BlzSetAbilityStringLevelField(BlzGetUnitAbility(Unit, _dummyDieswithout),
          ABILITY_SLF_TOOLTIP_NORMAL_EXTENDED,
          0, tooltip);
        DestroyGroup(tempGroup);
        return;
      }

      UnitRemoveAbility(Unit, _dummyDieswithout);
    }
    
    private void OnCast()
    {
      if (GetSpellAbilityId() != _dummyDieswithout) return;
      var tempGroup = CreateGroup();
      BlzGroupAddGroupFast(_diesWithout, tempGroup);
      while (true)
      {
        var u = FirstOfGroup(tempGroup);
        if (u == null) break;

        if (GetLocalPlayer() == GetTriggerPlayer()) PingMinimap(GetUnitX(u), GetUnitY(u), 5);

        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
    }
  }
}