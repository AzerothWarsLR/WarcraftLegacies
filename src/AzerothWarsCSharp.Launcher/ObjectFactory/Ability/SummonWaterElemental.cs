using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public static class SummonWaterElemental
  {
    public static ArchMageWaterElemental CreateSummonWaterElemental(string newRawcode, string iconName, Unit[] summonedUnit, int[] summonCount, int levels = 1)
    {
      //Buff setup
      var newBuff = new Buff(BuffType.WaterElemental)
      {
        ArtIcon = iconName,
      };

      //Ability setup
      var newAbility = new ArchMageWaterElemental(newRawcode)
      {
        ArtIconNormal = iconName,
        ArtIconResearch = iconName
      };
      for (var i = 0; i < levels; i++)
      {
        newAbility.DataSummonedUnitCount[i] = summonCount[i];
        newAbility.DataSummonedUnitType[i] = summonedUnit[i];
        newAbility.StatsBuffs[i] = new Buff[] { newBuff };
        newAbility.TextTooltipNormal[i] = $"Summon {summonedUnit[i].TextName}";
      }

      return newAbility;
    }
  }
}