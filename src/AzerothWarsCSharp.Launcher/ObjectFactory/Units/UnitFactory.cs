using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
    /// <summary>
    /// Apply non-tooltip information from the factory to a unit being generated.
    /// </summary>
    /// <param name="unit"></param>
    protected void Assign(Unit unit)
    {
      //Abilities
      unit.AbilitiesDefaultActiveAbility = DefaultActiveAbility;
      unit.AbilitiesHeroSkin = null;
      unit.AbilitiesNormal = AbilitiesNormal;
      unit.AbilitiesNormalSkin = null;
      //Art
      unit.ArtAllowCustomTeamColor = Model.AllowCustomTeamColor;
      unit.ArtAnimationBlendTimeseconds = Model.BlendTime;
      unit.ArtAnimationCastBackswing = Model.CastBackswing;
      unit.ArtAnimationCastPoint = Model.CastPoint;
      unit.ArtAnimationRunSpeed = Model.RunSpeed;
      unit.ArtAnimationWalkSpeed = Model.WalkSpeed;
      unit.ArtButtonPositionX = ButtonPosition.X;
      unit.ArtButtonPositionY = ButtonPosition.Y;
      unit.ArtCasterUpgradeArt = CasterUpgradeArt;
      unit.ArtDeathTimeseconds = Model.DeathTime;
      unit.ArtElevationSamplePoints = Model.ElevationSamplePoints;
      unit.ArtElevationSampleRadius = Model.ElevationSampleRadius;
      unit.ArtFogOfWarSampleRadius = 0;
      unit.ArtHasWaterShadow = Model.Shadow.ShowOnWater;
      unit.ArtIconGameInterface = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
      unit.ArtIconScoreScreen = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
      unit.ArtMaximumPitchAngledegrees = Model.MaximumPitchAngle;
      unit.ArtMaximumRollAngledegrees = Model.MaximumRollAngle;
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
      unit.ArtPropulsionWindowdegrees = Model.PropulsionWindow;
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
      unit.ArtUseExtendedLineOfSight = false;
      //Combat
      AssignAttacksEnabled(unit);
      AssignAttacks(unit);
      AssignTargetedAs(unit);
      unit.CombatAcquisitionRange = Math.Min(600, Attack1.Range);
      unit.CombatArmorType = ArmorType;
      unit.CombatDeathType = DeathType;
      unit.CombatDefenseBase = Armor;
      unit.CombatDefenseType = DefenseType;
      unit.CombatDefenseUpgradeBonus = ArmorUpgradeBonus;
      unit.CombatMinimumAttackRange = MinimumAttackRange;
      //Editor
      unit.EditorDisplayAsNeutralHostile = false;
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
      unit.MovementSpeedBase = MovementSpeed ?? 220;
      unit.MovementSpeedMaximum = 0;
      unit.MovementSpeedMinimum = 0;
      unit.MovementTurnRate = 0.6f;
      unit.MovementType = MovementType;
      //Pathing
      unit.PathingAIPlacementRadius = 0;
      unit.PathingAIPlacementType = AiBuffer._;
      //Sound
      unit.SoundLoopingFadeInRate = MovementSoundDetails.LoopingFadeInRate;
      unit.SoundLoopingFadeOutRate = MovementSoundDetails.LoopingFadeOutRate;
      unit.SoundMovement = MovementSoundDetails.Path;
      unit.SoundRandom = SoundRandom;
      unit.SoundUnitSoundSet = SoundSet;
      //Stats
      AssignSightRadius(unit);
      AssignFoodCost(unit);
      AssignFormationRank(unit);
      AssignGoldBounty(unit);
      AssignHeroStats(unit);
      AssignPriority(unit);
      AssignFaction(unit);
      unit.StatsBuildTime = BuildTime;
      unit.StatsCanFlee = true;
      unit.StatsFoodProduced = 0;
      unit.StatsGoldCost = GoldCost;
      unit.StatsHideMinimapDisplay = false;
      unit.StatsHitPointsMaximumBase = HitPoints;
      unit.StatsHitPointsRegenerationRate = HitPointRegeneration;
      unit.StatsHitPointsRegenerationType = HitPointRegenerationType;
      unit.StatsIsABuilding = IsABuilding;
      unit.StatsLevel = Level;
      unit.StatsLumberBountyAwardedBase = 0;
      unit.StatsLumberBountyAwardedNumberOfDice = 0;
      unit.StatsLumberBountyAwardedSidesPerDie = 0;
      unit.StatsLumberCost = LumberCost;
      unit.StatsManaInitialAmount = Mana / 2;
      unit.StatsManaMaximum = Mana;
      unit.StatsPointValue = 0;
      unit.StatsRepairGoldCost = GoldCost;
      unit.StatsRepairLumberCost = LumberCost;
      unit.StatsRepairTime = BuildTime;
      unit.StatsSleeps = false;
      unit.StatsStockInitialAfterStartDelay = StockInitial;
      unit.StatsStockMaximum = StockMaximum;
      unit.StatsStockStartDelay = StockStartDelay;
      unit.StatsTransportedSize = TransportedSize ?? 1;
      unit.StatsUnitClassification = Classification;
      //Techtree
      unit.TechtreeDependencyEquivalents = DependencyEquivalents;
      unit.TechtreeItemsSold = ItemsSold;
      unit.TechtreeRequirements = Requirements;
      unit.TechtreeRequirementsLevels = RequirementsLevels;
      unit.TechtreeStructuresBuilt = StructuresBuilt;
      unit.TechtreeUnitsSold = UnitsSold;
      unit.TechtreeUpgradesUsed = UpgradesUsed;
      //Text
      AssignTooltip(unit);
      unit.TextDescription = "PLACEHOLDER";
      unit.TextHotkey = 'A';
      unit.TextName = Name;
      unit.TextProperNames = new[] { "" };
      unit.TextProperNamesUsed = 1;
      unit.TextTooltipAwaken = "";
      unit.TextTooltipBasic = "";
      unit.TextTooltipExtended = "";
      unit.TextTooltipRevive = "";
      //Misc
      AssignCasterDetails(unit);
    }

    /// <summary>
    /// Assigns formation rank based on unit classification and range.
    /// </summary>
    /// <param name="unit"></param>
    private void AssignFormationRank(Unit unit)
    {
      if (Classification.Contains(UnitClassification.Peon))
      {
        unit.StatsFormationRank = 4;
        return;
      }
      var range = unit.CombatAttack1Range;
      if (range < 100)
      {
        unit.StatsFormationRank = 0;
        return;
      }
      if (range < 400)
      {
        unit.StatsFormationRank = 1;
        return;
      }
      if (range < 700)
      {
        unit.StatsFormationRank = 2;
        return;
      }
      unit.StatsFormationRank = 3;
      return;
    }

    private void AssignTargetedAs(Unit unit)
    {
      var targets = new List<Target>();
      if (IsABuilding){
        targets.Add(Target.Ground);
      } else
      {
        if (MovementType != MoveType.Fly)
        {
          targets.Add(Target.Air);
        }
        else
        {
          targets.Add(Target.Ground);
        }
      }
      if (IsKeyTarget)
      {
        targets.Add(Target.Ancient);
      }
      unit.CombatTargetedAs = targets;
    }

    private void AssignFaction(Unit unit)
    {
      unit.StatsRace = Faction.Race;
      unit.TextNameEditorSuffix = Faction.Name;
      unit.EditorCategorizationCampaign = Faction.IsCampaign;
    }

    private void AssignHeroStats(Unit unit)
    {
      if (IsHero)
      {
        unit.StatsPrimaryAttribute = PrimaryAttribute;
        unit.StatsStartingAgility = Agility;
        unit.StatsStartingIntelligence = Intelligence;
        unit.StatsStartingStrength = Strength;
        unit.StatsStrengthPerLevel = StrengthPerLevel;
        unit.StatsAgilityPerLevel = AgilityPerLevel;
        unit.StatsIntelligencePerLevel = IntelligencePerLevel;
        unit.StatsHeroHideHeroDeathMessage = false;
        unit.StatsHeroHideHeroInterfaceIcon = false;
      }
    }

    private void AssignPriority(Unit unit)
    {
      if (IsHero)
      {
        unit.StatsPriority = 100;
        return;
      }
      unit.StatsPriority = Level;
    }

    private void AssignGoldBounty(Unit unit)
    {
      unit.StatsGoldBountyAwardedBase = Level*4;
      unit.StatsGoldBountyAwardedNumberOfDice = Level*2;
      unit.StatsGoldBountyAwardedSidesPerDie = Level*2;
    }

    private void AssignAttacksEnabled(Unit unit)
    {
      if (Attack1 != null && Attack2 != null)
      {
        unit.CombatAttacksEnabled = AttackBits.Both;
        return;
      }
      if (Attack1 != null)
      {
        unit.CombatAttacksEnabled = AttackBits.Attack1Only;
      }
      if (Attack2 != null)
      {
        unit.CombatAttacksEnabled = AttackBits.Attack2Only;
      }
      unit.CombatAttacksEnabled = AttackBits.None;
    }

    private void AssignAttacks(Unit unit)
    {
      if (Attack1 != null)
      {
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
        unit.CombatAttack1RangeMotionBuffer = 250;
        unit.CombatAttack1ShowUI = true;
        unit.CombatAttack1TargetsAllowed = Attack1.TargetsAllowed;
        unit.CombatAttack1WeaponSound = Attack1.Sound;
        unit.CombatAttack1WeaponType = Attack1.ProjectileType; //Calculate this probably
      }
      if (Attack2 != null)
      {
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
        unit.CombatAttack2RangeMotionBuffer = 250;
        unit.CombatAttack2ShowUI = true;
        unit.CombatAttack2TargetsAllowed = Attack2.TargetsAllowed;
        unit.CombatAttack2WeaponSound = Attack2.Sound;
        unit.CombatAttack2WeaponType = Attack2.ProjectileType;
      }
    }

    private void AssignCasterDetails(Unit unit)
    {
      if (IsCaster)
      {
        var abilitiesList = AbilitiesNormal.ToList();
        unit.TextCasterUpgradeNames = new[]{ "Apprentice", "Adept", "Master" };
        unit.ArtCasterUpgradeArt = CasterUpgradeArt;
        unit.TextCasterUpgradeNames = new[] { abilitiesList[0].ArtIconNormal, abilitiesList[1].ArtIconNormal, abilitiesList[2].ArtIconNormal };
      }
    }

    private void AssignFoodCost(Unit unit)
    {
      if (IsABuilding)
      {
        unit.StatsFoodCost = 0;
        return;
      }
      unit.StatsFoodCost = 1;
    }

    private void AssignSightRadius(Unit unit)
    {
      var classificationList = Classification.ToList();
      if (classificationList.Contains(UnitClassification.Peon))
      {
        unit.StatsSightRadiusDay = 800;
        unit.StatsSightRadiusNight = 600;
        return;
      }
      if (MovementType == MoveType.Fly)
      {
        unit.StatsSightRadiusDay = 1800;
        unit.StatsSightRadiusNight = 800;
        return;
      }
      if (IsHero)
      {
        unit.StatsSightRadiusDay = 1800;
        unit.StatsSightRadiusNight = 800;
        return;
      }
      unit.StatsSightRadiusDay = 1400;
      unit.StatsSightRadiusNight = 800;
    }

    private void AssignTooltip(Unit unit)
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
    /// Generate a unit instance.
    /// </summary>
    public Unit Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newUnit = new Unit(BaseType, newRawCode, objectDatabase);
      Assign(newUnit);
      return newUnit;
    }

    public Unit Generate(int id, ObjectDatabase objectDatabase)
    {
      var newUnit = new Unit(BaseType, id, objectDatabase);
      Assign(newUnit);
      return newUnit;
    }

    public Ability DefaultActiveAbility { get; set; }
    public IEnumerable<Unit> StructuresBuilt { get; set; }
    public int BuildTime { get; set; }
    /// <summary>
    /// How large the unit is in terms of pathing.
    /// </summary>
    public float CollisionSize { get; set; }
    public Point ButtonPosition { get; set; }
    public string Flavor { get; set; }
    public int HitPoints { get; set; }
    public int Mana { get; set; }
    public string Name { get; set; }
    public ArtModel Model { get; set; }
    public string Icon { get; set; }
    public UnitType BaseType { get; set; }
    public IEnumerable<Ability> AbilitiesNormal { get; set; }
    public IEnumerable<Upgrade> ResearchesUsed { get; set; }
    public IEnumerable<string> RequiredAnimationNames { get; set; }
    public int Armor { get; set; }
    public int FoodProduced { get; set; }
    public int GoldCost { get; set; } = 0;
    public int LumberCost { get; set; } = 0;
    public string PathTexture { get; set; }
    public int Level { get; set; }
    /// <summary>
    /// Which unit classications the unit has; e.g. Ancient, Tauren.
    /// </summary>
    public IEnumerable<UnitClassification> Classification { get; set; }
    /// <summary>
    /// How much space the unit takes when it gets into a unit that can transport other units.
    /// </summary>
    public int CargoSize { get; set; } = 1;
    public IEnumerable<PathingType> PlacementRequires { get; set; }
    public IEnumerable<PathingType> PlacementPreventedBy { get; set; }
    /// <summary>
    /// Whether the unit can revive dead heroes.
    /// </summary>
    public bool RevivesDeadHeroes { get; set; }
    /// <summary>
    /// In which circumstances the unit regenerates hit points.
    /// </summary>
    public RegenType RegenType { get; set; }
    public AttackType AttackType1 { get; set; }
    public AttackType AttackType2 { get; set; }
    public DefenseType DefenseType { get; set; } = DefenseType.Normal;
    /// <summary>
    /// The amount of mana the unit regenerates per second.
    /// </summary>
    public float ManaRegeneration { get; set; } = 0;
    /// <summary>
    /// The amount of hit points the unit regenerates per second.
    /// </summary>
    public float HitPointRegeneration { get; set; } = 0;
    /// <summary>
    /// How fast the unit can move across the map.
    /// </summary>
    public int? MovementSpeed { get; set; }
    /// <summary>
    /// Which researches the unit can research.
    /// </summary>
    public IEnumerable<Upgrade> Researches { get; set; }
    /// <summary>
    /// Which units the unit can train.
    /// </summary>
    public IEnumerable<Unit> Trains { get; set; }
    /// <summary>
    /// The maximum number of stock the unit can have when being sold as a mercenary at a shop.
    /// </summary>
    public int StockMaximum { get; set; }
    /// <summary>
    /// The time between when this unit restocks when sold at a shop.
    /// </summary>
    public int StockReplenishInterval { get; set; }
    public ArmorType ArmorType { get; set; }
    public Attack Attack1 { get; set; }
    public Attack Attack2 { get; set; }
    public DeathType DeathType { get; set; }
    public int ArmorUpgradeBonus { get; set; }
    public int Agility { get; set; }
    public int AgilityPerLevel { get; set; }
    public AttributeType PrimaryAttribute { get; set; }
    public IEnumerable<Tech> Requirements { get; set; }
    public IEnumerable<int> RequirementsLevels { get; set; }
    public MoveType MovementType { get; set; }
    public int Strength { get; set; }
    public int StrengthPerLevel { get; set; }
    public int Intelligence { get; set; }
    public int IntelligencePerLevel { get; set; }
    public IEnumerable<Unit> UnitsSold { get; set; }
    public IEnumerable<Upgrade> UpgradesUsed { get; set; }
    public string SoundSet { get; set; }
    public RegenType HitPointRegenerationType { get; set; }
    public IEnumerable<Item> ItemsSold { get; set; }
    public int? TransportedSize { get; set; }
    public IEnumerable<Unit> DependencyEquivalents { get; set; }
    public int MinimumAttackRange { get; set; }
    public MovementSoundDetails MovementSoundDetails { get; set; }
    public string SoundRandom { get; set; }
    public string CasterUpgradeArt { get; set; }
    public bool IsHero { get; set; }
    public bool IsABuilding { get; set; }
    public bool IsCaster { get; set; }
    /// <summary>
    /// Key targets are things like Control Points and capitals. They can't be targeted by air units and ships.
    /// </summary>
    public bool IsKeyTarget { get; set; }
    public int StockInitial { get; set; }
    public int StockStartDelay { get; set; }
    public Faction Faction { get; set; }

    /// <summary>
    /// Reverse engineer a UnitFactory from a template Unit.
    /// </summary>
    public UnitFactory(Unit unit)
    {
      Model = new ArtModel()
      {
        Path = unit.ArtModelFile,
        BlendTime = unit.ArtAnimationBlendTimeseconds,
        CastBackswing = unit.ArtAnimationCastBackswing,
        CastPoint = unit.ArtAnimationCastPoint,
        RunSpeed = unit.ArtAnimationRunSpeed,
        WalkSpeed = unit.ArtAnimationWalkSpeed,
        DeathTime = unit.ArtDeathTimeseconds,
        ElevationSamplePoints = unit.ArtElevationSamplePoints,
        ElevationSampleRadius = unit.ArtElevationSampleRadius,
        MaximumPitchAngle = unit.ArtMaximumPitchAngledegrees,
        MaximumRollAngle = unit.ArtMaximumRollAngledegrees,
        OccluderHeight = unit.ArtOccluderHeight,
        ProjectileImpactZ = unit.ArtProjectileImpactZ,
        ProjectileImpactZSwimming = unit.ArtProjectileImpactZSwimming,
        ProjectileLaunchX = unit.ArtProjectileLaunchX,
        ProjectileLaunchY = unit.ArtProjectileLaunchY,
        ProjectileLaunchZ = unit.ArtProjectileLaunchZ,
        ProjectileLaunchZSwimming = unit.ArtProjectileLaunchZSwimming,
        PropulsionWindow = unit.ArtPropulsionWindowdegrees,
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
        AllowCustomTeamColor = unit.ArtAllowCustomTeamColor,
        OrientationInterpolation = unit.ArtOrientationInterpolation,
        RequiredAnimationNames = unit.ArtRequiredAnimationNames,
        RequiredAnimationNamesAttachments = unit.ArtRequiredAnimationNamesAttachments
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