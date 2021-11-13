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
      unit.TechtreeStructuresBuilt = StructuresBuilt;
      unit.StatsBuildTime = BuildTime;
      unit.PathingCollisionSize = CollisionSize;
      unit.ArtButtonPositionX = ButtonPosition.X;
      unit.ArtButtonPositionY = ButtonPosition.Y;
      unit.StatsHitPointsMaximumBase = HitPoints;
      unit.TextName = Name;
      unit.ArtModelFile = Model.Path;
      unit.ArtIconGameInterface = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
      unit.AbilitiesNormal = AbilitiesNormal;
      unit.ArtRequiredAnimationNames = RequiredAnimationNames;
      unit.CombatDefenseBase = Armor;
      unit.StatsGoldCost = GoldCost;
      unit.StatsFoodProduced = FoodProduced;
      unit.TechtreeUpgradesUsed = ResearchesUsed;
      unit.StatsUnitClassification = Classification;
      unit.StatsFoodCost = FoodCost;
      unit.StatsManaInitialAmount = StartingMana;
      unit.StatsManaMaximum = Mana;
      unit.TechtreeRevivesDeadHeroes = RevivesDeadHeroes;
      unit.PathingPlacementPreventedBy = PlacementPreventedBy;
      unit.PathingPlacementRequires = PlacementRequires;
      unit.StatsManaRegeneration = ManaRegeneration;
      //Calculated
      unit.StatsRepairGoldCost = GoldCost;
      unit.StatsRepairLumberCost = LumberCost;
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
      get => _structuresBuilt ?? Parent?.StructuresBuilt ?? System.Array.Empty<Unit>();
      set => _structuresBuilt = value;
    }

    private int? _buildTime;
    public int BuildTime
    {
      get => _buildTime ?? Parent?.BuildTime ?? 5;
      set => _buildTime = value;
    }

    private float? _collisionSize;
    /// <summary>
    /// How large the unit is in terms of pathing.
    /// </summary>
    public float CollisionSize
    {
      get => _collisionSize ?? Parent?.CollisionSize ?? 1;
      set => _collisionSize = value;
    }

    private Point? _buttonPosition;
    public Point ButtonPosition
    {
      get => _buttonPosition ?? Parent?.ButtonPosition ?? new Point(0, 0);
      set => _buttonPosition = value;
    }

    private string _flavor;
    public string Flavor
    {
      get => _flavor ?? Parent?.Flavor ?? "PLACEHOLDERFLAVOR";
      set => _flavor = value;
    }

    private int? _hitPoints;
    public int HitPoints
    {
      get => _hitPoints ?? Parent?.HitPoints ?? 1;
      set => _hitPoints = value;
    }

    private int? _mana;
    /// <summary>
    /// How much maximum mana the unit has with which to cast abilities.
    /// </summary>
    public int Mana
    {
      get => _mana ?? Parent?.Mana ?? 0;
      set => _mana = value;
    }

    private int? _startingMana;
    /// <summary>
    /// How much mana the unit has when it enters the map.
    /// </summary>
    public int StartingMana
    {
      get => _startingMana ?? Parent?.StartingMana ?? 0;
      set => _startingMana = value;
    }

    private string _name;
    public string Name
    {
      get => _name ?? Parent?.Name ?? "PLACEHOLDERNAME";
      set => _name = value;
    }

    private ArtModel _model;
    public ArtModel Model
    {
      get => _model ?? Parent?.Model ?? new ArtModel();
      set => _model = value;
    }

    private string _icon;
    public string Icon
    {
      get => _icon ?? Parent?.Icon ?? @"Peasant";
      set => _icon = value;
    }

    private UnitType? _baseType;
    public UnitType BaseType
    {
      get => _baseType ?? Parent?.BaseType ?? UnitType.Peasant_hpea;
      set => _baseType = value;
    }

    private IEnumerable<Ability> _abilitiesNormal;
    public IEnumerable<Ability> AbilitiesNormal
    {
      get => _abilitiesNormal ?? Parent?.AbilitiesNormal ?? System.Array.Empty<Ability>();
      set => _abilitiesNormal = value;
    }

    private IEnumerable<Upgrade> _researchesUsed;
    public IEnumerable<Upgrade> ResearchesUsed
    {
      get => _researchesUsed ?? Parent?.ResearchesUsed ?? System.Array.Empty<Upgrade>();
      set => _researchesUsed = value;
    }

    private IEnumerable<string> _requiredAnimationNames;
    public IEnumerable<string> RequiredAnimationNames
    {
      get => _requiredAnimationNames ?? Parent?.RequiredAnimationNames ?? System.Array.Empty<string>();
      set => _requiredAnimationNames = value;
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

    private float? _movementSpeed;
    /// <summary>
    /// How fast the unit can move across the map.
    /// </summary>
    public float MovementSpeed
    {
      get => _movementSpeed ?? Parent?.MovementSpeed ?? 220;
      set => _movementSpeed = value;
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

    private IEnumerable<Unit> _trains;
    /// <summary>
    /// Which units the unit can train.
    /// </summary>
    public IEnumerable<Unit> Trains
    {
      get => _trains ?? Parent?.Trains ?? Array.Empty<Unit>();
      set => _trains = value;
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

    private Attack _attack1;
    public Attack Attack1
    {
      get => _attack1 ?? Parent?.Attack1 ?? new Attack();
      set => _attack1 = value;
    }

    private Attack _attack2;
    public Attack Attack2
    {
      get => _attack2 ?? Parent?.Attack2 ?? new Attack();
      set => _attack2 = value;
    }

    public UnitFactory Parent { get; set; }

    /// <summary>
    /// Reverse engineer a UnitFactory from a template Unit.
    /// </summary>
    public UnitFactory(Unit unit)
    {
      Model = new ArtModel()
      {
        Path = unit.ArtModelFile,
        BlendTime = unit.ArtAnimationBlendTimeSeconds,
        CastBackswing = unit.ArtAnimationCastBackswing,
        CastPoint = unit.ArtAnimationCastPoint,
        RunSpeed = unit.ArtAnimationRunSpeed,
        WalkSpeed = unit.ArtAnimationWalkSpeed,
        DeathTime = unit.ArtDeathTimeSeconds,
        ElevationSamplePoints = unit.ArtElevationSamplePoints,
        ElevationSampleRadius = unit.ArtElevationSampleRadius,
        HasWaterShadow = unit.ArtHasWaterShadow,
        MaximumPitchAngle = unit.ArtMaximumPitchAngleDegrees,
        MaximumRollAngle = unit.ArtMaximumRollAngleDegrees,
        OccluderHeight = unit.ArtOccluderHeight,
        ProjectileImpactZ = unit.ArtProjectileImpactZ,
        ProjectileImpactZSwimming = unit.ArtProjectileImpactZSwimming,
        ProjectileLaunchX = unit.ArtProjectileLaunchX,
        ProjectileLaunchY = unit.ArtProjectileLaunchY,
        ProjectileLaunchZ = unit.ArtProjectileLaunchZ,
        ProjectileLaunchZSwimming = unit.ArtProjectileLaunchZSwimming,
        PropulsionWindow = unit.ArtPropulsionWindowDegrees,
        ScaleProjectiles = unit.ArtScaleProjectiles,
        SelectionCircleHeight = unit.ArtSelectionCircleHeight,
        SelectionCircleOnWater = unit.ArtSelectionCircleOnWater,
        ShadowImage = unit.ArtShadowImageUnit,
        ShadowImageCenterX = unit.ArtShadowImageCenterX,
        ShadowImageCenterY = unit.ArtShadowImageCenterY,
        ShadowImageHeight = unit.ArtShadowImageHeight,
        ShadowImageWidth = unit.ArtShadowImageWidth,
        ShadowTextureBuilding = unit.ArtShadowTextureBuilding,
        Special = unit.ArtSpecial,
        ArmorType = unit.CombatArmorType,
        TurnRate = unit.MovementTurnRate,
        Tint = new Tint(unit.ArtTintingColor1Red, unit.ArtTintingColor2Green, unit.ArtTintingColor3Blue),
      };
      Attack1 = new Attack()
      {
        AnimationBackswingPoint = unit.CombatAttack1AnimationBackswingPoint,
        AnimationDamagePoint = unit.CombatAttack1AnimationDamagePoint,
        AreaOfEffectFullDamage = unit.CombatAttack1AreaOfEffectFullDamage,
        AreaOfEffectMediumDamage = unit.CombatAttack1AreaOfEffectMediumDamage,
        AreaOfEffectTargets = unit.CombatAttack1AreaOfEffectTargets,
        AttackType = unit.CombatAttack1AttackType,
        CooldownTime = unit.CombatAttack1CooldownTime,
        DamageBase = unit.CombatAttack1DamageBase,
        DamageFactorMedium = unit.CombatAttack1DamageFactorMedium,
        DamageFactorSmall = unit.CombatAttack1DamageFactorSmall,
        DamageLossFactor = unit.CombatAttack1DamageLossFactor,
        DamageNumberOfDice = unit.CombatAttack1DamageNumberOfDice,
        DamageSidesPerDie = unit.CombatAttack1DamageSidesPerDie,
        DamageSpillDistance = unit.CombatAttack1DamageSpillDistance,
        DamageSpillRadius = unit.CombatAttack1DamageSpillRadius,
        DamageUpgradeAmount = unit.CombatAttack1DamageUpgradeAmount,
        MaximumNumberOfTargets = unit.CombatAttack1MaximumNumberOfTargets,
        ProjectileArc = unit.CombatAttack1ProjectileArc,
        ProjectileArt = unit.CombatAttack1ProjectileArt,
        ProjectileHomingEnabled = unit.CombatAttack1ProjectileHomingEnabled,
        ProjectileSpeed = unit.CombatAttack1ProjectileSpeed,
        Range = unit.CombatAttack1Range,
        RangeMotionBuffer = unit.CombatAttack1RangeMotionBuffer,
        ShowUI = unit.CombatAttack1ShowUI,
        TargetsAllowed = unit.CombatAttack1TargetsAllowed,
        Sound = unit.CombatAttack1WeaponSound,
        ProjectileType = unit.CombatAttack1WeaponType
      };
    }

    public UnitFactory(UnitType baseType)
    {
      BaseType = baseType;
    }
  }
}