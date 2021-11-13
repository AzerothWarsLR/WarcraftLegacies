using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using War3Api.Object;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  /// <summary>
  /// A factory that can instantiate Units based on its properties.
  /// </summary>
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
      //Abilities
      unit.AbilitiesDefaultActiveAbility = DefaultActiveAbility;
      unit.AbilitiesHeroSkin = null;
      unit.AbilitiesNormal = AbilitiesNormal;
      unit.AbilitiesNormalSkin = null;
      //Art
      unit.ArtAllowCustomTeamColor = AllowCustomTeamColor;
      unit.ArtAnimationBlendTimeSeconds = Model.BlendTime;
      unit.ArtAnimationCastBackswing = Model.CastBackswing;
      unit.ArtAnimationCastPoint = Model.CastPoint;
      unit.ArtAnimationRunSpeed = Model.RunSpeed;
      unit.ArtAnimationWalkSpeed = Model.WalkSpeed;
      unit.ArtButtonPositionX = ButtonPosition.X;
      unit.ArtButtonPositionY = ButtonPosition.Y;
      unit.ArtCasterUpgradeArt = CasterUpgradeArt;
      unit.ArtDeathTimeSeconds = Model.DeathTime;
      unit.ArtElevationSamplePoints = Model.ElevationSamplePoints;
      unit.ArtElevationSampleRadius = Model.ElevationSampleRadius;
      unit.ArtFogOfWarSampleRadius = Model.FogOfWarSampleRadius;
      unit.ArtHasWaterShadow = Model.Shadow.ShowOnWater;
      unit.ArtIconGameInterface = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
      unit.ArtIconScoreScreen = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
      unit.ArtMaximumPitchAngleDegrees = Model.MaximumPitchAngle;
      unit.ArtMaximumRollAngleDegrees = Model.MaximumRollAngle;
      unit.ArtModelFile = Model.Path;
      unit.ArtModelFileExtraVersions = VersionFlags.TheFrozenThrone;
      unit.ArtOccluderHeight = Model.OccluderHeight;
      unit.ArtOrientationInterpolation = Model.OrientationInterpolation;
      unit.ArtProjectileImpactZ = Model.ProjectileImpactZ;
      unit.ArtProjectileImpactZSwimming = Model.ProjectileImpactZSwimming;
      unit.ArtProjectileLaunchX = Model.ProjectileLaunchX;
      unit.ArtProjectileLaunchY = Model.ProjectileLaunchY;
      unit.ArtProjectileLaunchZ = Model.ProjectileLaunchZ;
      unit.ArtProjectileLaunchZSwimming = Model.ProjectileLaunchZSwimming;
      unit.ArtPropulsionWindowDegrees = Model.PropulsionWindow;
      unit.ArtRequiredAnimationNames = Model.RequiredAnimationNames;
      unit.ArtRequiredAnimationNamesAttachments = Model.RequiredAnimationNamesAttachments;
      unit.ArtRequiredAttachmentLinkNames = Model.RequiredAttachmentLinkNames;
      unit.ArtRequiredBoneNames = Model.RequiredBoneNames;
      unit.ArtScaleProjectiles = Model.ScaleProjectiles;
      unit.ArtScalingValue = Model.Scale;
      unit.ArtSelectionCircleHeight = Model.SelectionCircleHeight;
      unit.ArtSelectionCircleOnWater = Model.SelectionCircleOnWater;
      unit.ArtSelectionScale = Model.SelectionScale;
      unit.ArtShadowImageUnit = Model.Shadow.ShadowImage;
      unit.ArtShadowImageCenterX = Model.Shadow.CenterX;
      unit.ArtShadowImageCenterY = Model.Shadow.CenterY;
      unit.ArtShadowImageHeight = Model.Shadow.Height;
      unit.ArtShadowImageWidth = Model.Shadow.Width;
      unit.ArtShadowTextureBuilding = Model.Shadow.TextureBuilding;
      unit.ArtSpecial = Model.Special;
      unit.ArtTarget = null;
      unit.ArtTeamColor = Model.TeamColor;
      unit.ArtTintingColor1Red = Model.Tint.Red;
      unit.ArtTintingColor2Green = Model.Tint.Green;
      unit.ArtTintingColor3Blue = Model.Tint.Blue;
      unit.ArtUseExtendedLineOfSight = Model.UseExtendedLineOfSight;
      //Combat
      unit.CombatAcquisitionRange = AcquisitionRange;
      unit.CombatArmorType = ArmorType;
      unit.CombatAttacksEnabled = AttackBits.None; //Calculate this
      unit.CombatDeathType = DeathType;
      unit.CombatDefenseBase = Armor;
      unit.CombatDefenseType = ArmorType;
      unit.CombatDefenseUpgradeBonus = ArmorUpgradeBonus;
      unit.CombatMinimumAttackRange = MinimumAttackRange;
      unit.CombatTargetedAs = TargetedAs; //Calculate this
      //Attack 1
      unit.CombatAttack1AnimationBackswingPoint = Attack1.AnimationBackswingPoint;
      unit.CombatAttack1AnimationDamagePoint = Attack1.AnimationDamagePoint;
      unit.CombatAttack1AreaOfEffectFullDamage = Attack1.AreaOfEffectFullDamage;
      unit.CombatAttack1AreaOfEffectMediumDamage = Attack1.AreaOfEffectMediumDamage;
      unit.CombatAttack1AreaOfEffectSmallDamage = Attack1.AreaOfEffectSmallDamage;
      unit.CombatAttack1AreaOfEffectTargets = Attack1.AreaOfEffectTargets;
      unit.CombatAttack1AttackType = Attack1.AttackType;
      unit.CombatAttack1CooldownTime = Attack1.CooldownTime;
      unit.CombatAttack1DamageBase = Attack1.DamageBase;
      unit.CombatAttack1DamageFactorMedium = Attack1.DamageFactorMedium;
      unit.CombatAttack1DamageFactorSmall = Attack1.DamageFactorSmall;
      unit.CombatAttack1DamageLossFactor = Attack1.DamageLossFactor;
      unit.CombatAttack1DamageNumberOfDice = Attack1.DamageNumberOfDice;
      unit.CombatAttack1DamageSidesPerDie = Attack1.DamageSidesPerDie;
      unit.CombatAttack1DamageSpillDistance = Attack1.DamageSpillDistance;
      unit.CombatAttack1DamageSpillRadius = Attack1.DamageSpillRadius;
      unit.CombatAttack1DamageUpgradeAmount = Attack1.DamageUpgradeAmount;
      unit.CombatAttack1MaximumNumberOfTargets = Attack1.MaximumNumberOfTargets;
      unit.CombatAttack1ProjectileArc = Attack1.ProjectileArc;
      unit.CombatAttack1ProjectileArt = Attack1.ProjectileArt;
      unit.CombatAttack1ProjectileHomingEnabled = Attack1.ProjectileHomingEnabled;
      unit.CombatAttack1ProjectileSpeed = Attack1.ProjectileSpeed;
      unit.CombatAttack1Range = Attack1.Range;
      unit.CombatAttack1RangeMotionBuffer = Attack1.RangeMotionBuffer; //Calculate this maybe
      unit.CombatAttack1ShowUI = Attack1.ShowUI; //Calculate this
      unit.CombatAttack1TargetsAllowed = Attack1.TargetsAllowed;
      unit.CombatAttack1WeaponSound = Attack1.Sound;
      unit.CombatAttack1WeaponType = Attack1.ProjectileType; //Calculate this probably
      //Attack 2
      unit.CombatAttack2AnimationBackswingPoint = Attack2.AnimationBackswingPoint;
      unit.CombatAttack2AnimationDamagePoint = Attack2.AnimationDamagePoint;
      unit.CombatAttack2AreaOfEffectFullDamage = Attack2.AreaOfEffectFullDamage;
      unit.CombatAttack2AreaOfEffectMediumDamage = Attack2.AreaOfEffectMediumDamage;
      unit.CombatAttack2AreaOfEffectSmallDamage = Attack2.AreaOfEffectSmallDamage;
      unit.CombatAttack2AreaOfEffectTargets = Attack2.AreaOfEffectTargets;
      unit.CombatAttack2AttackType = Attack2.AttackType;
      unit.CombatAttack2CooldownTime = Attack2.CooldownTime;
      unit.CombatAttack2DamageBase = Attack2.DamageBase;
      unit.CombatAttack2DamageFactorMedium = Attack2.DamageFactorMedium;
      unit.CombatAttack2DamageFactorSmall = Attack2.DamageFactorSmall;
      unit.CombatAttack2DamageLossFactor = Attack2.DamageLossFactor;
      unit.CombatAttack2DamageNumberOfDice = Attack2.DamageNumberOfDice;
      unit.CombatAttack2DamageSidesPerDie = Attack2.DamageSidesPerDie;
      unit.CombatAttack2DamageSpillDistance = Attack2.DamageSpillDistance;
      unit.CombatAttack2DamageSpillRadius = Attack2.DamageSpillRadius;
      unit.CombatAttack2DamageUpgradeAmount = Attack2.DamageUpgradeAmount;
      unit.CombatAttack2MaximumNumberOfTargets = Attack2.MaximumNumberOfTargets;
      unit.CombatAttack2ProjectileArc = Attack2.ProjectileArc;
      unit.CombatAttack2ProjectileArt = Attack2.ProjectileArt;
      unit.CombatAttack2ProjectileHomingEnabled = Attack2.ProjectileHomingEnabled;
      unit.CombatAttack2ProjectileSpeed = Attack2.ProjectileSpeed;
      unit.CombatAttack2Range = Attack2.Range;
      unit.CombatAttack2RangeMotionBuffer = Attack2.RangeMotionBuffer; //Calculate this maybe
      unit.CombatAttack2ShowUI = Attack2.ShowUI; //Calculate this
      unit.CombatAttack2TargetsAllowed = Attack2.TargetsAllowed;
      unit.CombatAttack2WeaponSound = Attack2.Sound;
      unit.CombatAttack2WeaponType = Attack2.ProjectileType; //Calculate this probably
      //Editor
      unit.EditorDisplayAsNeutralHostile = false;
      unit.EditorCategorizationCampaign = false;
      unit.EditorCategorizationSpecial = false;
      unit.EditorDisplayAsNeutralHostile = false;
      unit.EditorHasTilesetSpecificData = false;
      unit.EditorPlaceableInEditor = true;
      unit.EditorTilesets = new[] { Tileset.All };
      unit.EditorUseClickHelper = false;
      //Movement
      unit.MovementGroupSeparationEnabled = false;
      unit.MovementGroupSeparationGroupNumber = 0;
      unit.MovementGroupSeparationParameter = 0;
      unit.MovementGroupSeparationPriority = 0;
      unit.MovementHeight = 0;
      unit.MovementHeightMinimum = 0;
      unit.MovementSpeedBase = MovementSpeed;
      unit.MovementSpeedMaximum = 0;
      unit.MovementSpeedMinimum = 0;
      unit.MovementTurnRate = 0.6f;
      unit.MovementType = Model.MovementType;
      //Pathing
      unit.PathingAIPlacementRadius = 0;
      unit.PathingAIPlacementType = AiBuffer._;
      //Sound
      unit.SoundLoopingFadeInRate = LoopingFadeInRate;
      unit.SoundLoopingFadeOutRate = LoopingFadeOutRate;
      unit.SoundMovement = SoundMovement;
      unit.SoundRandom = SoundRandom;
      unit.SoundUnitSoundSet = SoundSet;
      //Stats
      unit.StatsAgilityPerLevel = AgilityPerLevel;
      unit.StatsBuildTime = BuildTime;
      unit.StatsCanFlee = CanFlee; //Calculate this
      unit.StatsFoodCost = FoodCost; //Calculate this
      unit.StatsFoodProduced = 0;
      unit.StatsFormationRank = 0; //Calculate this
      unit.StatsGoldBountyAwardedBase = 0; //Calculate this
      unit.StatsGoldBountyAwardedNumberOfDice = 0; //Calculate this
      unit.StatsGoldBountyAwardedSidesPerDie = 0; //Calculate this
      unit.StatsGoldCost = GoldCost;
      unit.StatsHeroHideHeroDeathMessage = false;
      unit.StatsHeroHideHeroInterfaceIcon = false;
      unit.StatsHideMinimapDisplay = false;
      unit.StatsHitPointsMaximumBase = HitPoints;
      unit.StatsHitPointsRegenerationRate = HitPointRegeneration;
      unit.StatsHitPointsRegenerationType = HitPointRegenerationType;
      unit.StatsIntelligencePerLevel = IntelligencePerLevel;
      unit.StatsIsABuilding = IsABuilding;
      unit.StatsLevel = Level;
      unit.StatsLumberBountyAwardedBase = 0;
      unit.StatsLumberBountyAwardedNumberOfDice = 0;
      unit.StatsLumberBountyAwardedSidesPerDie = 0;
      unit.StatsLumberCost = LumberCost;
      unit.StatsManaInitialAmount = ManaInitialAmount;
      unit.StatsManaMaximum = Mana;
      unit.StatsPointValue = 0;
      unit.StatsPrimaryAttribute = PrimaryAttribute; //Only set if hero
      unit.StatsPriority = 0; //Calculate this
      unit.StatsRace = UnitRace.Human; //Calculate this
      unit.StatsRepairGoldCost = GoldCost;
      unit.StatsRepairLumberCost = LumberCost;
      unit.StatsRepairTime = BuildTime;
      unit.StatsSightRadiusDay = SightRadiusDay;
      unit.StatsSightRadiusNight = SightRadiusNight;
      unit.StatsSleeps = false;
      unit.StatsStartingAgility = Agility;
      unit.StatsStartingIntelligence = Intelligence;
      unit.StatsStartingStrength = Strength;
      unit.StatsStockInitialAfterStartDelay = 0; //Calculate this
      unit.StatsStockMaximum = 0; //Calculate this
      unit.StatsStockStartDelay = 0; //Calculate this
      unit.StatsStrengthPerLevel = StrengthPerLevel;
      unit.StatsTransportedSize = TransportedSize;
      unit.StatsUnitClassification = default; //Calculate this
      //Techtree
      unit.TechtreeDependencyEquivalents = DependencyEquivalents;
      unit.TechtreeItemsSold = ItemsSold;
      unit.TechtreeRequirements = Requirements;
      unit.TechtreeRequirementsLevels = RequirementsLevels;
      unit.TechtreeStructuresBuilt = StructuresBuilt;
      unit.TechtreeUnitsSold = UnitsSold;
      unit.TechtreeUpgradesUsed = UpgradesUsed;
      //Text
      unit.TextCasterUpgradeNames = CasterUpgradeNames;
      unit.TextCasterUpgradeTips = CasterUpgradeTips;
      unit.TextDescription = "PLACEHOLDER";
      unit.TextHotkey = 'A';
      unit.TextName = Name;
      unit.TextNameEditorSuffix = "";
      unit.TextProperNames = new[] { "" };
      unit.TextProperNamesUsed = 1;
      unit.TextTooltipAwaken = "";
      unit.TextTooltipBasic = "";
      unit.TextTooltipExtended = "";
      unit.TextTooltipRevive = "";
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
        Shadow = new Shadow()
        {
          ShadowImage = unit.ArtShadowImageUnit,
          CenterX = unit.ArtShadowImageCenterX,
          CenterY = unit.ArtShadowImageCenterY,
          Height = unit.ArtShadowImageHeight,
          Width = unit.ArtShadowImageWidth,
          TextureBuilding = unit.ArtShadowTextureBuilding,
          ShowOnWater = unit.ArtHasWaterShadow
        },
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