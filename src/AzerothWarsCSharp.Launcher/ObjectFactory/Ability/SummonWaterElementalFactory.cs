using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class SummonWaterElementalFactory
  {
    private readonly ArchMageWaterElemental _ability;
    private readonly Buff _buff;
    private Unit[] _summonedUnit;
    private int[] _duration = new int[] { 35 };
    private int _levels = 1;

    private void GenerateTooltip()
    {
      for (var i = 0; i < _levels; i++)
      {
        var summonedUnit = _summonedUnit[i];
        _ability.TextTooltipNormalExtended[i + 1] = $"Summons a {summonedUnit.TextName} to " +
          $"attack the caster's enemies for {_duration[i]} seconds." +
          $"|n|n|cffecce87{_summonedUnit[i].TextName}|r" +
          $"|n{_summonedUnit[i].TextTooltipExtended}";
      }
    }

    public Ability Generate()
    {
      GenerateTooltip();
      return _ability;
    }

    /// <summary>
    /// How long the summoned unit lasts before disappearing.
    /// </summary>
    public int[] Duration
    {
      set
      {
        _duration = value;
        for (var i = 0; i < _levels; i++)
        {
          _ability.StatsDurationNormal[i + 1] = value[i];
        }
      }
    }

    /// <summary>
    /// Which unit types this ability summons, by level.
    /// </summary>
    public Unit[] SummonedUnit
    {
      set
      {
        _summonedUnit = value;
        _ability.TextName = $"Summon {value[0].TextName}";
        for (var i = 0; i < _levels; i++)
        {
          _ability.DataSummonedUnitType[i + 1] = value[i];
          _ability.TextTooltipNormal[i + 1] = $"Summon {value[i].TextName}";
          _ability.TextTooltipNormal[i + 1] = $"Summon {value[i].TextName}";
        }
        _buff.TextTooltip = value[0].TextName;
      }
    }

    /// <summary>
    /// How many summons this ability makes, by level.
    /// </summary>
    public int[] SummonCount
    {
      set
      {
        for (var i = 0; i < _levels; i++)
        {
          _ability.DataSummonedUnitCount[i + 1] = value[i];
        }
      }
    }

    /// <summary>
    /// How many levels this ability has.
    /// </summary>
    public int Levels
    {
      set { _levels = value; }
    }

    /// <summary>
    /// The icon for this ability and its associated buff.
    /// </summary>
    public string ArtIcon
    {
      set
      {
        _ability.ArtIconNormal = value;
        _ability.ArtIconResearch = value;
        _buff.ArtIcon = value;
      }
    }

    public SummonWaterElementalFactory(string newRawCode)
    {
      _ability = new ArchMageWaterElemental(newRawCode);
      _buff = new Buff(BuffType.WaterElemental);
    }
  }
}