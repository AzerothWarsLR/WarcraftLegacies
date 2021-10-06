using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public static class RaiseDead
  {
    public static RaiseDeadCreep CreateRaiseDead(
    string newRawcode, string iconName = "RaiseDead", Unit[] summonedUnit = null,
    int levels = 1)
    {
      //Buff setup
      var newBuff = new Buff(BuffType.RaiseDead)
      {
        ArtIcon = iconName,
      };

      //Ability setup
      var newAbility = new War3Api.Object.Abilities.RaiseDeadCreep(newRawcode)
      {
        ArtIconNormal = iconName,
        ArtIconResearch = iconName
      };
      for (var i = 0; i < levels; i++)
      {
        newAbility.DataUnitTypeOne[i] = summonedUnit[i];
        newAbility.StatsBuffs[i] = new Buff[] { newBuff };
        newAbility.TextTooltipNormal[i] = $"Summon {summonedUnit[i].TextName}";
      }

      return newAbility;
    }
  }
}
