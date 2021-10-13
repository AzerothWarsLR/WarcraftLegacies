using System.Collections.Generic;

namespace AzerothWarsCSharp.Common
{
  public class MassAnySpellEffectDefinition
  {
    public static List<MassAnySpellEffectDefinition> All = new();

    public int RawCode { get; set; }
    public float AreaOfEffect { get; set; } = 0;

    public MassAnySpellEffectDefinition(int rawCode)
    {
      RawCode = rawCode;
    }

    public static void Register(MassAnySpellEffectDefinition instance)
    {
      All.Add(instance);
    }
  }
}