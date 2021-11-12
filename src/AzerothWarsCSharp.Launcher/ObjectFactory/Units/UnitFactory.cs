using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using War3Api.Object;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class UnitFactory : IObjectFactory<Unit>
  {
    private void GenerateTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.Append($"{Flavor}|n|n");
      tooltipBuilder.Append($"|c006969FFHit points|r: {unit.StatsHitPointsMaximumBase}|n");
      tooltipBuilder.Append($"|c006969FFAttack damage|r: {unit.DamageRangeString()}|n");
      tooltipBuilder.Append($"|c006969FFAbilities|r: ");
      foreach (var ability in unit.AbilitiesNormal)
      {
        tooltipBuilder.Append($"{ability.TextName}");
      }
      unit.TextTooltipExtended = tooltipBuilder.ToString();
    }

    /// <summary>
    /// Apply non-tooltip information from the factory to a unit being generated.
    /// </summary>
    /// <param name="unit"></param>
    protected void GenerateCore(Unit unit)
    {
#pragma warning disable CS0618 // Type or member is obsolete
      unit.TechtreeStructuresBuilt = StructuresBuilt;
      unit.StatsBuildTime = BuildTime;
      unit.ArtScalingValue = ScalingValue;
      unit.PathingCollisionSize = CollisionSize;
      unit.ArtButtonPositionX = ButtonPosition.X;
      unit.ArtButtonPositionY = ButtonPosition.Y;
      unit.CombatAttack1DamageBase = DamageBase1;
      unit.CombatAttack2DamageBase = DamageBase2;
      unit.CombatAttack1DamageNumberOfDice = DamageNumberOfDice1;
      unit.CombatAttack2DamageNumberOfDice = DamageNumberOfDice2;
      unit.StatsHitPointsMaximumBase = HitPoints;
      unit.TextName = Name;
      unit.ArtModelFile = Model;
      unit.ArtIconGameInterface = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
      unit.AbilitiesNormal = AbilitiesNormal;
      unit.ArtRequiredAnimationNames = RequiredAnimationNames;
      unit.CombatDefenseBase = Armor;
      unit.StatsGoldCost = GoldCost;
      unit.StatsFoodProduced = FoodProduced;
      unit.TechtreeUpgradesUsedRaw = ResearchesUsedRaw;
      unit.TechtreeUpgradesUsed = ResearchesUsed;
      unit.StatsUnitClassification = Classification;
      unit.StatsFoodCost = FoodCost;
      unit.CombatAttack1DamageBase = DamageBase1;
      unit.CombatAttack1DamageSidesPerDie = DamageSidesPerDie1;
      unit.CombatAttack2DamageSidesPerDie = DamageSidesPerDie2;
      unit.StatsManaInitialAmount = StartingMana;
      unit.StatsManaMaximum = Mana;
      unit.TechtreeRevivesDeadHeroes = RevivesDeadHeroes;
      unit.PathingPlacementPreventedBy = PlacementPreventedBy;
      unit.PathingPlacementRequires = PlacementRequires;
      unit.ArtTintingColor1Red = TintRed;
      unit.ArtTintingColor2Green = TintGreen;
      unit.ArtTintingColor3Blue = TintBlue;
      unit.CombatAttack1ProjectileSpeed = MissileSpeed1;
      unit.CombatAttack2ProjectileSpeed = MissileSpeed2;
      unit.AbilitiesDefaultActiveAbilityRaw = DefaultActiveAbilityRaw;
      unit.StatsManaRegeneration = ManaRegeneration;
      unit.CombatAttack1AnimationBackswingPoint = AnimationBackswingPoint1;
      unit.CombatAttack2AnimationBackswingPoint = AnimationBackswingPoint2;
      //Calculated
      unit.StatsRepairGoldCost = GoldCost;
      unit.StatsRepairLumberCost = LumberCost;
#pragma warning restore CS0618 // Type or member is obsolete
    }

    /// <summary>
    /// Generate a unit instance.
    /// </summary>
    public Unit Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newUnit = new Unit(BaseType, newRawCode, objectDatabase);
      GenerateCore(newUnit);
      GenerateTooltip(newUnit);
      return newUnit;
    }

    private IEnumerable<Unit> _structuresBuilt;
    public IEnumerable<Unit> StructuresBuilt
    {
      get
      {
        return _structuresBuilt ?? Parent?.StructuresBuilt ?? System.Array.Empty<Unit>();
      }
      set
      {
        _structuresBuilt = value;
      }
    }

    private int? _buildTime;
    public int BuildTime
    {
      get
      {
        return _buildTime ?? Parent?.BuildTime ?? 5;
      }
      set
      {
        _buildTime = value;
      }
    }

    private float? _scalingValue;
    public float ScalingValue
    {
      get
      {
        return _scalingValue ?? Parent?.ScalingValue ?? 1;
      }
      set
      {
        _scalingValue = value;
      }
    }

    private float? _collisionSize;
    /// <summary>
    /// How large the unit is in terms of pathing.
    /// </summary>
    public float CollisionSize
    {
      get
      {
        return _collisionSize ?? Parent?.CollisionSize ?? 1;
      }
      set
      {
        _collisionSize = value;
      }
    }

    private Point? _buttonPosition;
    public Point ButtonPosition
    {
      get
      {
        return _buttonPosition ?? Parent?.ButtonPosition ?? new Point(0, 0);
      }
      set
      {
        _buttonPosition = value;
      }
    }

    private string _flavor;
    public string Flavor
    {
      get
      {
        return _flavor ?? Parent?.Flavor ?? "PLACEHOLDERFLAVOR";
      }
      set
      {
        _flavor = value;
      }
    }

    private int? _damageBase;
    public int DamageBase
    {
      get
      {
        return _damageBase ?? Parent?.DamageBase ?? 0;
      }
      set
      {
        _damageBase = value;
      }
    }

    private int? _damageNumberOfDice1;
    public int DamageNumberOfDice1
    {
      get
      {
        return _damageNumberOfDice1 ?? Parent?.DamageNumberOfDice1 ?? 0;
      }
      set
      {
        _damageNumberOfDice1 = value;
      }
    }

    private int? _damageNumberOfDice2;
    public int DamageNumberOfDice2
    {
      get
      {
        return _damageNumberOfDice2 ?? Parent?.DamageNumberOfDice2 ?? 0;
      }
      set
      {
        _damageNumberOfDice2 = value;
      }
    }

    private int? _damageSidesPerDie1;
    public int DamageSidesPerDie1
    {
      get
      {
        return _damageSidesPerDie1 ?? Parent?.DamageSidesPerDie1 ?? 0;
      }
      set
      {
        _damageSidesPerDie1 = value;
      }
    }

    private int? _damageSidesPerDie2;
    public int DamageSidesPerDie2
    {
      get
      {
        return _damageSidesPerDie2 ?? Parent?.DamageSidesPerDie2 ?? 0;
      }
      set
      {
        _damageSidesPerDie2 = value;
      }
    }

    private int? _hitPoints;
    public int HitPoints
    {
      get
      {
        return _hitPoints ?? Parent?.HitPoints ?? 1;
      }
      set
      {
        _hitPoints = value;
      }
    }

    private int? _mana;
    /// <summary>
    /// How much maximum mana the unit has with which to cast abilities.
    /// </summary>
    public int Mana
    {
      get
      {
        return _mana ?? Parent?.Mana ?? 0;
      }
      set
      {
        _mana = value;
      }
    }

    private int? _startingMana;
    /// <summary>
    /// How much mana the unit has when it enters the map.
    /// </summary>
    public int StartingMana
    {
      get
      {
        return _startingMana ?? Parent?.StartingMana ?? 0;
      }
      set
      {
        _startingMana = value;
      }
    }

    private string _name;
    public string Name
    {
      get
      {
        return _name ?? Parent?.Name ?? "PLACEHOLDERNAME";
      }
      set
      {
        _name = value;
      }
    }

    private string _model;
    public string Model
    {
      get
      {
        return _model ?? Parent?.Model ?? @"units\human\Peasant\Peasant";
      }
      set
      {
        _model = value;
      }
    }

    private string _icon;
    public string Icon
    {
      get
      {
        return _icon ?? Parent?.Icon ?? @"Peasant";
      }
      set
      {
        _icon = value;
      }
    }

    private UnitType? _baseType;
    public UnitType BaseType
    {
      get
      {
        return _baseType ?? Parent?.BaseType ?? UnitType.Peasant_hpea;
      }
      set
      {
        _baseType = value;
      }
    }

    private IEnumerable<Ability> _abilitiesNormal;
    public IEnumerable<Ability> AbilitiesNormal
    {
      get
      {
        return _abilitiesNormal ?? Parent?.AbilitiesNormal ?? System.Array.Empty<Ability>();
      }
      set
      {
        _abilitiesNormal = value;
      }
    }

    private string _abilitiesNormalRaw;
    [Obsolete("This property is obsolete. Use AbilitiesNormal instead.", false)]
    public string AbilitiesNormalRaw
    {
      get
      {
        return _abilitiesNormalRaw ?? Parent?.AbilitiesNormalRaw ?? null;
      }
      set
      {
        _abilitiesNormalRaw = value;
      }
    }

    private string _upgradesToRaw;
    [Obsolete("This property is obsolete. Use UpgradesTo instead.", false)]
    public string UpgradesToRaw
    {
      get => _upgradesToRaw ?? Parent?.UpgradesToRaw ?? null;
      set => _upgradesToRaw = value;
    }

    private IEnumerable<Upgrade> _researchesUsed;
    public IEnumerable<Upgrade> ResearchesUsed
    {
      get => _researchesUsed ?? Parent?.ResearchesUsed ?? System.Array.Empty<Upgrade>();
      set => _researchesUsed = value;
    }

    private string _researchesUsedRaw;
    [Obsolete("This property is obsolete. Use ResearchesUsed instead.", false)]
    public string ResearchesUsedRaw
    {
      get => _researchesUsedRaw ?? Parent?.ResearchesUsedRaw ?? "";
      set => _researchesUsedRaw = value;
    }

    private IEnumerable<string> _requiredAnimationNames;
    public IEnumerable<string> RequiredAnimationNames
    {
      get
      {
        return _requiredAnimationNames ?? Parent?.RequiredAnimationNames ?? System.Array.Empty<string>();
      }
      set
      {
        _requiredAnimationNames = value;
      }
    }

    private int? _armor;
    public int Armor
    {
      get => _armor ?? Parent?.Armor ?? 0;
      set => _armor = value;
    }

    private int? _foodProduced;
    public int FoodProduced
    {
      get => _foodProduced ?? Parent?.FoodProduced ?? 0;
      set => _foodProduced = value;
    }

    private int? _goldCost;
    public int GoldCost
    {
      get => _goldCost ?? Parent?.GoldCost ?? 0;
      set => _goldCost = value;
    }

    private int? _lumberCost;
    public int LumberCost
    {
      get => _lumberCost ?? Parent?.LumberCost ?? 0;
      set => _lumberCost = value;
    }

    private string _pathTexture;
    public string PathTexture
    {
      get => _pathTexture ?? Parent?.PathTexture ?? "";
      set => _pathTexture = value;
    }

    private int? _level;
    /// <summary>
    /// The unit's level. Affects experience gained and gold bounty.
    /// </summary>
    public int Level
    {
      get => _level ?? Parent?.Level ?? 0;
      set => _level = value;
    }

    private IEnumerable<UnitClassification> _classification;
    /// <summary>
    /// Which unit classications the unit has; e.g. Ancient, Tauren.
    /// </summary>
    public IEnumerable<UnitClassification> Classification
    {
      get => _classification ?? Parent?.Classification ?? System.Array.Empty<UnitClassification>();
      set => _classification = value;
    }

    private int? _foodCost;
    /// <summary>
    /// How much food this unit occupies.
    /// </summary>
    public int FoodCost
    {
      get => _foodCost ?? Parent?.FoodCost ?? 0;
      set => _foodCost = value;
    }

    private int? _damageBase1;
    /// <summary>
    /// The base damage of the unit's first attack.
    /// </summary>
    public int DamageBase1
    {
      get => _damageBase1 ?? Parent?.DamageBase1 ?? 0;
      set => _damageBase1 = value;
    }

    private int? _damageBase2;
    /// <summary>
    /// The base damage of the unit's second attack.
    /// </summary>
    public int DamageBase2
    {
      get => _damageBase2 ?? Parent?.DamageBase2 ?? 0;
      set => _damageBase2 = value;
    }

    private int? _cargoSize;
    /// <summary>
    /// How much space the unit takes when it gets into a unit that can transport other units.
    /// </summary>
    public int CargoSize
    {
      get => _cargoSize ?? Parent?.CargoSize ?? 1;
      set => _cargoSize = value;
    }

    private IEnumerable<PathingType> _placementRequires;
    public IEnumerable<PathingType> PlacementRequires
    {
      get => _placementRequires ?? Parent?.PlacementRequires ?? Array.Empty<PathingType>();
      set => _placementRequires = value;
    }

    private IEnumerable<PathingType> _placementPreventedBy;
    public IEnumerable<PathingType> PlacementPreventedBy
    {
      get => _placementPreventedBy ?? Parent?.PlacementPreventedBy ?? Array.Empty<PathingType>();
      set => _placementPreventedBy = value;
    }

    private bool? _revivesDeadHeroes;
    /// <summary>
    /// Whether the unit can revive dead heroes.
    /// </summary>
    public bool RevivesDeadHeroes
    {
      get => _revivesDeadHeroes ?? Parent?.RevivesDeadHeroes ?? false;
      set => _revivesDeadHeroes = value;
    }

    private RegenType? _regenType;
    /// <summary>
    /// In which circumstances the unit regenerates hit points.
    /// </summary>
    public RegenType RegenType
    {
      get => _regenType ?? Parent?.RegenType ?? RegenType.Always;
      set => _regenType = value;
    }

    private IEnumerable<Target> _targets1;
    /// <summary>
    /// Which targets the units first attack can can be used against.
    /// </summary>
    public IEnumerable<Target> Targets1
    {
      get => _targets1 ?? Parent?.Targets1 ?? Array.Empty<Target>();
      set => _targets1 = value;
    }

    private IEnumerable<Target> _targets2;
    /// <summary>
    /// Which targets the units second attack can can be used against.
    /// </summary>
    public IEnumerable<Target> Targets2
    {
      get => _targets2 ?? Parent?.Targets2 ?? Array.Empty<Target>();
      set => _targets2 = value;
    }

    private IEnumerable<Target> _areaOfEffectTargets1;
    public IEnumerable<Target> AreaOfEffectTargets1
    {
      get => _areaOfEffectTargets1 ?? Parent?.AreaOfEffectTargets1 ?? Array.Empty<Target>();
      set => _areaOfEffectTargets1 = value;
    }

    private IEnumerable<Target> _areaOfEffectTargets2;
    public IEnumerable<Target> AreaOfEffectTargets2
    {
      get => _areaOfEffectTargets2 ?? Parent?.AreaOfEffectTargets2 ?? Array.Empty<Target>();
      set => _areaOfEffectTargets2 = value;
    }

    private AttackType? _attackType1;
    public AttackType AttackType1
    {
      get => _attackType1 ?? Parent?.AttackType1 ?? AttackType.Normal;
      set => _attackType1 = value;
    }

    private AttackType? _attackType2;
    public AttackType AttackType2
    {
      get => _attackType2 ?? Parent?.AttackType2 ?? AttackType.Normal;
      set => _attackType2 = value;
    }

    private DefenseType? _defenseType;
    public DefenseType DefenseType
    {
      get => _defenseType ?? Parent?.DefenseType ?? DefenseType.Normal;
      set => _defenseType = value;
    }

    private string _defaultActiveAbilityRaw;
    [Obsolete("This property is obsolete. Use DefaultActiveAbility instead.", false)]
    public string DefaultActiveAbilityRaw
    {
      get => _defaultActiveAbilityRaw ?? Parent?.DefaultActiveAbilityRaw ?? "";
      set => _defaultActiveAbilityRaw = value;
    }

    private int? _tintRed;
    public int TintRed
    {
      get => _tintRed ?? Parent?.TintRed ?? 255;
      set => _tintRed = value;
    }

    private int? _tintGreen;
    public int TintGreen
    {
      get => _tintGreen ?? Parent?.TintGreen ?? 255;
      set => _tintGreen = value;
    }

    private int? _tintBlue;
    public int TintBlue
    {
      get => _tintBlue ?? Parent?.TintBlue ?? 255;
      set => _tintBlue = value;
    }

    private int? _missileSpeed1;
    public int MissileSpeed1
    {
      get => _missileSpeed1 ?? Parent?.MissileSpeed1 ?? 0;
      set => _missileSpeed1 = value;
    }

    private int? _missileSpeed2;
    public int MissileSpeed2
    {
      get => _missileSpeed2 ?? Parent?.MissileSpeed2 ?? 0;
      set => _missileSpeed2 = value;
    }

    private float? _modelScale;
    public float ModelScale
    {
      get => _modelScale ?? Parent?.ModelScale ?? 1;
      set => _modelScale = value;
    }

    private float? _attackCooldown1;
    public float AttackCooldown1
    {
      get => _attackCooldown1 ?? Parent?.AttackCooldown1 ?? 1;
      set => _attackCooldown1 = value;
    }

    private float? _attackCooldown2;
    public float AttackCooldown2
    {
      get => _attackCooldown2 ?? Parent?.AttackCooldown2 ?? 1;
      set => _attackCooldown2 = value;
    }

    private float? _manaRegeneration;
    /// <summary>
    /// The amount of mana the unit regenerates per second.
    /// </summary>
    public float ManaRegeneration
    {
      get => _manaRegeneration ?? Parent?.ManaRegeneration ?? 0;
      set => _manaRegeneration = value;
    }

    private float? _hitPointRegeneration;
    /// <summary>
    /// The amount of hit points the unit regenerates per second.
    /// </summary>
    public float HitPointRegeneration
    {
      get => _hitPointRegeneration ?? Parent?.HitPointRegeneration ?? 0;
      set => _hitPointRegeneration = value;
    }

    private float? _animationBackswingPoint1;
    public float AnimationBackswingPoint1
    {
      get => _animationBackswingPoint1 ?? Parent?.AnimationBackswingPoint1 ?? 0;
      set => _animationBackswingPoint1 = value;
    }

    private float? _animationBackswingPoint2;
    public float AnimationBackswingPoint2
    {
      get => _animationBackswingPoint2 ?? Parent?.AnimationBackswingPoint2 ?? 0;
      set => _animationBackswingPoint2 = value;
    }

    private float? _movementSpeed;
    /// <summary>
    /// How fast the unit can move across the map.
    /// </summary>
    public float MovementSpeed
    {
      get => _movementSpeed ?? Parent?.MovementSpeed ?? 220;
      set => _movementSpeed = value;
    }

    private float? _splashAreaFull1;
    public float SplashAreaFull1
    {
      get => _splashAreaFull1 ?? Parent?.SplashAreaFull1 ?? 0;
      set => _splashAreaFull1 = value;
    }

    private float? _splashAreaFull2;
    public float SplashAreaFull2
    {
      get => _splashAreaFull2 ?? Parent?.SplashAreaFull2 ?? 0;
      set => _splashAreaFull2 = value;
    }

    private string _missileArt1;
    public string MissileArt1
    {
      get => _missileArt1 ?? Parent?.MissileArt1 ?? "";
      set => _missileArt1 = value;
    }

    private string _missileArt2;
    public string MissileArt2
    {
      get => _missileArt2 ?? Parent?.MissileArt2 ?? "";
      set => _missileArt2 = value;
    }

    private float? _range1;
    /// <summary>
    /// How far the unit's first attack can reach.
    /// </summary>
    public float Range1
    {
      get => _range1 ?? Parent?.Range1 ?? 0;
      set => _range1 = value;
    }

    private float? _range2;
    /// <summary>
    /// How far the unit's second attack can reach.
    /// </summary>
    public float Range2
    {
      get => _range2 ?? Parent?.Range2 ?? 0;
      set => _range2 = value;
    }

    private IEnumerable<Upgrade> _researches;
    /// <summary>
    /// Which researches the unit can research.
    /// </summary>
    public IEnumerable<Upgrade> Researches
    {
      get => _researches ?? Parent?.Researches ?? Array.Empty<Upgrade>();
      set => _researches = value;
    }

    private string _researchesRaw;
    [Obsolete("This property is obsolete. Use Researches instead.", false)]
    public string ResearchesRaw
    {
      get => _researchesRaw ?? Parent?.ResearchesRaw ?? "";
      set => _researchesRaw = value;
    }

    private IEnumerable<Unit> _trains;
    /// <summary>
    /// Which units the unit can train.
    /// </summary>
    public IEnumerable<Unit> Trains
    {
      get => _trains ?? Parent?.Trains ?? Array.Empty<Unit>();
      set => _trains = value;
    }

    private string _trainsRaw;
    [Obsolete("This property is obsolete. Use Trains instead.", false)]
    public string TrainsRaw
    {
      get => _trainsRaw ?? Parent?.TrainsRaw ?? "";
      set => _trainsRaw = value;
    }

    private int? _stockMaximum;
    /// <summary>
    /// The maximum number of stock the unit can have when being sold as a mercenary at a shop.
    /// </summary>
    public int StockMaximum
    {
      get => _stockMaximum ?? Parent?.StockMaximum ?? 1;
      set => _stockMaximum = value;
    }

    private int? _stockReplenishInterval;
    /// <summary>
    /// The time between when this unit restocks when sold at a shop.
    /// </summary>
    public int StockReplenishInterval
    {
      get => _stockReplenishInterval ?? Parent?.StockReplenishInterval ?? 1;
      set => _stockReplenishInterval = value;
    }

    private WeaponType? _weaponType1;
    public WeaponType WeaponType1
    {
      get => _weaponType1 ?? Parent?.WeaponType1 ?? WeaponType.Normal;
      set => _weaponType1 = value;
    }

    private WeaponType? _weaponType2;
    public WeaponType WeaponType2
    {
      get => _weaponType2 ?? Parent?.WeaponType2 ?? WeaponType.Normal;
      set => _weaponType2 = value;
    }

    private float? _missileArc1;
    public float MissileArc1
    {
      get => _missileArc1 ?? Parent?.MissileArc1 ?? 0;
      set => _missileArc1 = value;
    }

    private float? _missileArc2;
    public float MissileArc2
    {
      get => _missileArc2 ?? Parent?.MissileArc2 ?? 0;
      set => _missileArc2 = value;
    }

    public UnitFactory Parent { get; set; }

    public UnitFactory(UnitType baseType)
    {
      BaseType = baseType;
    }
  }
}