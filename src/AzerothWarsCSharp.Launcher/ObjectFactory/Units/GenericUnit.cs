using System.Collections.Generic;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class GenericUnit
  {
    protected readonly Unit _unit;

    public string TextName
    {
      set { _unit.TextName = value; }
    }

    public string ArtModelFile
    {
      set { _unit.ArtModelFile = value; }
    }

    public string ArtIconGameInterface
    {
      set { _unit.ArtIconGameInterface = value; }
    }

    public IEnumerable<Ability> AbilitiesNormal
    {
      set { _unit.AbilitiesNormal = value; }
    }

    public GenericUnit(UnitType baseType, string newRawCode)
    {
      _unit = new Unit(baseType, newRawCode);
    }
  }
}