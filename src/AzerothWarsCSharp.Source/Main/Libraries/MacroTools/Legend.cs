using System;
using System.Collections.Generic;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  /// <summary>
  /// A Legend is a wrapper for unique heroes. A Legend can continue to exist even if the unit it describes does not.
  /// A Legend might have other units it relies on to survive. If so, when it dies, it gets removed if those units are not under control.
  /// There is a dummy ability to represent this.
  /// </summary>
  public sealed class Legend
  {
    private readonly int _dummyDieswithout = FourCC("LEgn");
    private readonly int _dummyPermadies = FourCC("LEgo");
    private readonly int _dummyCapital = FourCC("LEca");

    private static readonly Dictionary<unit, Legend> ByUnit = new();
    private static readonly List<Legend> AllLegends = new();

    private unit? _unit;
    private int _unitType;
    private bool _permaDies;
    private group? _diesWithout;
    private trigger? _ownerTrig;
    private trigger? _deathTrig;
    private trigger? _castTrig;
    private trigger? _damageTrig;
    private playercolor? _playerColor;
    private bool _isCapital;
    private string? _name;

    public static event EventHandler<LegendChangeOwnerEventArgs>? OnLegendChangeOwner;

    /// <summary>
    /// Fires when a Legend permanently dies, but before it is removed from the game.
    /// </summary>
    public static event EventHandler<Legend>? OnLegendPrePermaDeath;

    public static event EventHandler<Legend>? OnLegendPermaDeath;

    public static event EventHandler<Legend>? OnLegendDeath;

    public bool Essential { get; set; }

    public bool EnableMessages { get; set; }

    public string Name
    {
      get
      {
        if (!string.IsNullOrEmpty(_name))
        {
          return _name;
        }

        if (_unit == null && _unitType != 0)
        {
          return GetObjectName(_unitType);
        }

        return IsUnitType(_unit, UNIT_TYPE_HERO) ? GetHeroProperName(_unit) : GetUnitName(_unit);
      }
      set => _name = value;
    }

    /// <summary>
    /// Whether or not this Legend counts as a capital building.
    /// </summary>
    public bool IsCapital
    {
      get => _isCapital;
      set
      {
        _isCapital = value;
        RefreshDummy();
      }
    }

    public bool HasCustomColor { get; private set; }

    /// <summary>
    /// The colour of the Legend's in-game model.
    /// </summary>
    public playercolor PlayerColor
    {
      get => _playerColor;
      set
      {
        _playerColor = value;
        HasCustomColor = true;
        if (_unit != null)
        {
          SetUnitColor(_unit, _playerColor);
        }
      }
    }

    /// <summary>
    /// //A value indicating how much experience a hero should not distribute when refunded. Must be set manually per hero.
    /// </summary>
    public int StartingXp { get; set; }

    /// <summary>
    /// If true, the Legend is permanently removed from the game upon death.
    /// </summary>
    public bool PermaDies
    {
      set
      {
        _permaDies = value;
        RefreshDummy();
      }
    }

    public string DeathSfx { private get; set; } = "Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl";

    public string DeathMessage { private get; set; }

    /// <summary>
    /// Whether or not the unit changes ownership to its attacker when its hitpoints are reduced past a threshold.
    /// </summary>
    public bool Capturable { get; set; }

    public unit? Unit
    {
      get => GetOwningPlayer(_unit) == null ? null : _unit;
      set
      {
        if (Unit != null)
        {
          ByUnit.Remove(Unit);
          GeneralHelpers.UnitDropAllItems(Unit);
          RemoveUnit(_unit);
        }

        _unit = value;

        if (Unit != null)
        {
          _unitType = GetUnitTypeId(_unit);
          //Death trig
          DestroyTrigger(_deathTrig);
          _deathTrig = CreateTrigger();
          TriggerRegisterUnitEvent(_deathTrig, _unit, EVENT_UNIT_DEATH);
          TriggerAddAction(_deathTrig, OnUnitDeath);
          //Cast trig
          DestroyTrigger(_castTrig);
          _castTrig = CreateTrigger();
          TriggerRegisterUnitEvent(_castTrig, _unit, EVENT_UNIT_SPELL_FINISH);
          TriggerAddAction(_castTrig, OnUnitCast);
          //Damage trig
          DestroyTrigger(_damageTrig);
          _damageTrig = CreateTrigger();
          TriggerRegisterUnitEvent(_damageTrig, _unit, EVENT_UNIT_DAMAGED);
          TriggerAddAction(_damageTrig, OnUnitDamaged);
          //Ownership change trig
          DestroyTrigger(_ownerTrig);
          _ownerTrig = CreateTrigger();
          TriggerRegisterUnitEvent(_ownerTrig, _unit, EVENT_UNIT_CHANGE_OWNER);
          TriggerAddAction(_ownerTrig, OnUnitChangeOwner);
          //Color
          SetUnitColor(_unit, HasCustomColor ? _playerColor : GetPlayerColor(GetOwningPlayer(_unit)));
          //Set XP to starting XP
          if (GetHeroXP(_unit) < StartingXp)
          {
            SetHeroXP(_unit, StartingXp, true);
          }

          ByUnit[Unit] = this;
          RefreshDummy();
        }
      }
    }

    public void ClearUnitDependencies()
    {
      DestroyGroup(_diesWithout);
      _diesWithout = null;
      RefreshDummy();
    }

    /// <summary>
    /// Add an additional unit dependency to this Legend.
    /// If all of a Legend's unit dependencies are dead or owned by hostile forces,
    /// the Legend permanently dies upon death.
    /// </summary>
    public void AddUnitDependency(unit u)
    {
      _diesWithout ??= CreateGroup();
      GroupAddUnit(_diesWithout, u);
      RefreshDummy();
    }

    /// <summary>
    /// If true, when the Legend dies, its parent faction is defeated.
    /// </summary>
    public bool Hivemind { private get; init; }

    /// <summary>
    /// The current unit type of the Legend. Can be changed at any time, even if the Legend is already in the game world.
    /// </summary>
    public int UnitType
    {
      get => _unitType;
      set
      {
        if (_unit != null)
        {
          unit newUnit = CreateUnit(OwningPlayer, value, GetUnitX(_unit), GetUnitY(_unit), GetUnitFacing(_unit));
          SetUnitState(newUnit, UNIT_STATE_LIFE, GetUnitState(_unit, UNIT_STATE_LIFE));
          SetUnitState(newUnit, UNIT_STATE_MANA, GetUnitState(_unit, UNIT_STATE_MANA));
          SetHeroXP(newUnit, GetHeroXP(_unit), false);
          GeneralHelpers.UnitTransferItems(_unit, newUnit);
          var oldX = GetUnitX(_unit);
          var oldY = GetUnitY(_unit);
          RemoveUnit(_unit);
          Unit = newUnit;
          SetUnitPosition(_unit, oldX, oldY);
        }

        _unitType = value;
      }
    }

    public Faction? OwningFaction => OwningPerson?.Faction;

    public Person? OwningPerson => Person.ByHandle(GetOwningPlayer(_unit));

    public player OwningPlayer => GetOwningPlayer(_unit);

    public void Spawn(player owner, float x, float y, float face)
    {
      if (Unit == null)
      {
        Unit = CreateUnit(owner, _unitType, x, y, face);
        OnLegendChangeOwner?.Invoke(this, new LegendChangeOwnerEventArgs(this, null));
      }
      else if (!UnitAlive(Unit))
      {
        ReviveHero(Unit, x, y, false);
      }
      else
      {
        SetUnitX(Unit, x);
        SetUnitY(Unit, y);
        SetUnitFacing(Unit, face);
      }

      if (GetOwningPlayer(_unit) != owner)
      {
        SetUnitOwner(Unit, owner, true);
      }

      RefreshDummy();
    }

    private void RefreshDummy()
    {
      if (_permaDies)
      {
        UnitAddAbility(_unit, _dummyPermadies);
      }
      else
      {
        UnitRemoveAbility(_unit, _dummyPermadies);
        if (_diesWithout != null)
        {
          group tempGroup = CreateGroup();
          string tooltip =
            "When this unit dies, it will be unrevivable unless any of the following capitals are under your control:\n";
          BlzGroupAddGroupFast(_diesWithout, tempGroup);
          while (true)
          {
            unit u = FirstOfGroup(tempGroup);
            if (u == null)
            {
              break;
            }

            tooltip = tooltip + " - " + GetUnitName(u) + "|n";
            GroupRemoveUnit(tempGroup, u);
          }

          tooltip += "\nUsing this ability pings each of these capitals on the minimap.";
          UnitAddAbility(_unit, _dummyDieswithout);
          BlzSetAbilityStringLevelField(BlzGetUnitAbility(_unit, _dummyDieswithout),
            ABILITY_SLF_TOOLTIP_NORMAL_EXTENDED,
            0, tooltip);
          DestroyGroup(tempGroup);
        }
        else
        {
          UnitRemoveAbility(_unit, _dummyDieswithout);
        }
      }

      if (_isCapital)
      {
        UnitAddAbility(_unit, _dummyCapital);
      }
      else
      {
        UnitRemoveAbility(_unit, _dummyCapital);
      }
    }

    private void PermaDeath()
    {
      OnLegendPrePermaDeath?.Invoke(this, this);
      if (IsUnitType(_unit, UNIT_TYPE_HERO))
      {
        effect tempEffect = AddSpecialEffect(DeathSfx, GetUnitX(_unit), GetUnitY(_unit));
        BlzSetSpecialEffectScale(tempEffect, 20);
        DestroyEffect(tempEffect);
        if (_unit != null)
        {
          GeneralHelpers.UnitDropAllItems(_unit);
          RemoveUnit(_unit);
        }
      }

      if (!string.IsNullOrEmpty(DeathMessage) && EnableMessages)
      {
        string displayString = IsUnitType(_unit, UNIT_TYPE_STRUCTURE)
          ? "\n|cffffcc00CAPITAL DESTROYED|r\n"
          : "\n|cffffcc00HERO SLAIN|r\n";
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, displayString + DeathMessage);
      }

      if (Hivemind && OwningPerson != null)
      {
        OwningPerson.Faction.Obliterate();
      }

      OnLegendPermaDeath?.Invoke(this, this);
    }

    private void OnChangeOwner()
    {
      OnLegendChangeOwner?.Invoke(this, new LegendChangeOwnerEventArgs(this, GetChangingUnitPrevOwner()));
    }

    private void OnDamaging()
    {
      if (Capturable && GetEventDamage() + 1 >= GetUnitState(_unit, UNIT_STATE_LIFE))
      {
        SetUnitOwner(_unit, GetOwningPlayer(GetEventDamageSource()), true);
        BlzSetEventDamage(0);
        SetUnitState(_unit, UNIT_STATE_LIFE, GetUnitState(_unit, UNIT_STATE_MAX_LIFE));
      }
    }

    private void onCast()
    {
      group tempGroup;
      unit u;
      if (GetSpellAbilityId() == _dummyDieswithout)
      {
        tempGroup = CreateGroup();
        BlzGroupAddGroupFast(_diesWithout, tempGroup);
        while (true)
        {
          u = FirstOfGroup(tempGroup);
          if (u == null)
          {
            break;
          }

          if (GetLocalPlayer() == GetTriggerPlayer())
          {
            PingMinimap(GetUnitX(u), GetUnitY(u), 5);
          }

          GroupRemoveUnit(tempGroup, u);
        }

        DestroyGroup(tempGroup);
        tempGroup = null;
      }
    }

    private void OnDeath()
    {
      OnLegendDeath?.Invoke(this, this);

      if (GetOwningPlayer(_unit) == Player(PLAYER_NEUTRAL_PASSIVE) ||
          GetOwningPlayer(_unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE) && DeathMessage != "" &&
          !string.IsNullOrEmpty(DeathMessage))
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "\n|cffffcc00LEGENDARY CREEP DEATH|r\n" + DeathMessage);
      }

      if (_permaDies || !IsUnitType(_unit, UNIT_TYPE_HERO))
      {
        PermaDeath();
        return;
      }

      var anyOwned = false;
      if (_diesWithout != null)
      {
        group tempGroup = CreateGroup();
        BlzGroupAddGroupFast(_diesWithout, tempGroup);
        while (true)
        {
          unit u = FirstOfGroup(tempGroup);
          if (u == null)
          {
            break;
          }

          if (GetOwningPlayer(u) == GetOwningPlayer(_unit) && UnitAlive(u))
          {
            anyOwned = true;
          }

          GroupRemoveUnit(tempGroup, u);
        }

        if (anyOwned == false)
        {
          PermaDeath();
        }

        DestroyGroup(tempGroup);
      }
    }

    /// <summary>
    /// Returns the Legend represented by a particular unit.
    /// </summary>
    public static Legend? GetFromUnit(unit whichUnit)
    {
      return ByUnit.ContainsKey(whichUnit) ? ByUnit[whichUnit] : null;
    }

    private static void OnUnitChangeOwner()
    {
      var triggerLegend = GetFromUnit(GetTriggerUnit());
      triggerLegend?.OnChangeOwner();
    }

    private static void OnUnitDamaged()
    {
      GetFromUnit(GetTriggerUnit())?.OnDamaging();
    }

    private static void OnUnitDeath()
    {
      GetFromUnit(GetTriggerUnit())?.OnDeath();
    }

    private static void OnUnitCast()
    {
      GetFromUnit(GetTriggerUnit())?.onCast();
    }

    //When any unit is trained, check if it has the unittype of a Legend, and assign it to that Legend if so
    private static void OnUnitTrain()
    {
      unit trainedUnit = GetTrainedUnit();
      foreach (var legend in AllLegends)
      {
        if (legend.UnitType == GetUnitTypeId(trainedUnit))
        {
          legend.Unit = trainedUnit;
          OnLegendChangeOwner?.Invoke(legend, null);
        }
      }
    }

    ~Legend()
    {
      DestroyGroup(_diesWithout);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining, OnUnitTrain);
    }

    /// <summary>
    /// Register a Legend to the Legend system, causing it to be tracked for <see cref="QuestData"/>
    /// and <see cref="Legend"/> purposes.
    /// </summary>
    /// <param name="legend"></param>
    public static void Register(Legend legend)
    {
      AllLegends.Add(legend);
    }
  }
}