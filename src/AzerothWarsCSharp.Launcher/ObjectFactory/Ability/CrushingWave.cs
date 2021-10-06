using System.Collections.Generic;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public static class CrushingWave
  {
    public static War3Api.Object.Abilities.CrushingWave CreateCrushingWave(
    string newRawcode, char hotkey, float[] damage, float[] maxDamage, float[] distance, int levels, float[] startArea,
    float[] finalArea, float[] castRange, IEnumerable<Target>[] targetsAllowed, float[] cooldown, int[] manaCost,
    int missileSpeed = 1100, IEnumerable<string> artSpecial = null, IEnumerable<string> missileArt = null)
    {
      var newAbility = new War3Api.Object.Abilities.CrushingWave(newRawcode)
      {
        TextHotkeyNormal = hotkey,
        StatsLevels = levels,
        ArtMissileSpeed = missileSpeed,
        ArtSpecial = artSpecial,
        ArtMissileArt = missileArt
      };
      for (var i = 0; i < levels; i++)
      {
        newAbility.DataDamage[i] = damage[i];
        newAbility.DataMaxDamage[i] = damage[i];
        newAbility.DataDistance[i] = distance[i];
        newAbility.StatsAreaOfEffect[i] = startArea[i];
        newAbility.DataFinalArea[i] = finalArea[i];
        newAbility.StatsCastRange[i] = castRange[i];
        newAbility.StatsTargetsAllowed[i] = targetsAllowed[i];
        newAbility.StatsCooldown[i] = cooldown[i];
        newAbility.StatsManaCost[i] = manaCost[i];
        newAbility.TextTooltipNormal[i] = $"Deals {damage[i]} damage to each enemy land unit in a line, up to {maxDamage[i]} max damage.";
      }
      return newAbility;
    }
  }
}