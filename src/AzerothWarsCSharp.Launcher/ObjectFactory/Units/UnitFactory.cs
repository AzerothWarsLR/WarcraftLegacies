using System.Collections.Generic;
using System.Drawing;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class UnitFactory : IObjectFactory<Unit>
  {
    private void GenerateTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.Append($"{Flavour}|n|n");
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
    public Unit Generate(string newRawCode)
    {
      var newUnit = new Unit(BaseType, newRawCode)
      {
        TechtreeStructuresBuilt = StructuresBuilt,
        StatsBuildTime = BuildTime,
        ArtScalingValue = ScalingValue,
        PathingCollisionSize = CollisionSize,
        ArtButtonPositionX = ButtonPosition.X,
        ArtButtonPositionY = ButtonPosition.Y,
        CombatAttack1DamageBase = DamageBase,
        CombatAttack1DamageNumberOfDice = DamageNumberOfDice,
        CombatAttack1DamageSidesPerDie = DamageSidesPerDie,
        StatsHitPointsMaximumBase = HitPoints,
        TextName = TextName,
        ArtModelFile = ArtModelFile,
        ArtIconGameInterface = ArtIconGameInterface,
        AbilitiesNormal = AbilitiesNormal,
        ArtRequiredAnimationNames = RequiredAnimationNames
      };
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

    private string _flavour;
    public string Flavour
    {
      get
      {
        return _flavour ?? Parent?.Flavour ?? "PLACEHOLDERFLAVOR";
      }
      set
      {
        _flavour = value;
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

    private int? _damageNumberOfDice;
    public int DamageNumberOfDice
    {
      get
      {
        return _damageNumberOfDice ?? Parent?.DamageNumberOfDice ?? 0;
      }
      set
      {
        _damageNumberOfDice = value;
      }
    }

    private int? _damageSidesPerDie;
    public int DamageSidesPerDie
    {
      get
      {
        return _damageSidesPerDie ?? Parent?.DamageSidesPerDie ?? 0;
      }
      set
      {
        _damageSidesPerDie = value;
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

    private string _textName;
    public string TextName
    {
      get
      {
        return _textName ?? Parent?.TextName ?? "PLACEHOLDERNAME";
      }
      set
      {
        _textName = value;
      }
    }

    private string _artModelFile;
    public string ArtModelFile
    {
      get
      {
        return _artModelFile ?? Parent?.ArtModelFile ?? @"units\human\Peasant\Peasant";
      }
      set
      {
        _artModelFile = value;
      }
    }

    private string _artIconGameInterface;
    public string ArtIconGameInterface
    {
      get
      {
        return _artIconGameInterface ?? Parent?.ArtIconGameInterface ?? @"ReplaceableTextures\CommandButtons\BTNPeasant.blp";
      }
      set
      {
        _artIconGameInterface = value;
      }
    }

    private UnitType? _baseType;
    public UnitType BaseType
    {
      get
      {
        return _baseType ?? Parent?.BaseType ?? UnitType.Peasant;
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

    public UnitFactory Parent { get; set; }

    public UnitFactory(UnitType baseType)
    {
      BaseType = baseType;
      Flavour = "";
    }
  }
}