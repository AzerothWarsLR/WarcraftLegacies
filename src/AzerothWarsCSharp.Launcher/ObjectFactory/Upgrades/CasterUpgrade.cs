using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Upgrades
{
  class CasterUpgrade
  {
    private static readonly string CASTER_UPGRADE_ART = "Sorceress";
    private static readonly Dictionary<int, string> _casterNamesByLevel = new()
    {
      { 0, "Adept" },
      { 1, "Master" },
      { 2, "Grandmaster" },
    };

    public static Upgrade CreateCasterUpgrade(string newRawCode, Unit casterUnit, Ability[] casterAbilities)
    {
      //Creating the research
      var casterUpgrade = new Upgrade(UpgradeType.OrcPillage, newRawCode)
      {
        StatsRace = casterUnit.StatsRace,
        ArtButtonPositionX = 0,
        ArtButtonPositionY = casterUnit.ArtButtonPositionY,
        StatsLevels = casterAbilities.Length - 1,
        StatsGoldBase = 100,
        StatsLumberBase = 50,
        StatsLumberIncrement = 100,
        StatsTimeBase = 60,
        StatsTimeIncrement = 15,
        DataEffect1 = UpgradeEffect.Rman, //Mana point
        DataBase1 = 100,
        DataMod1 = 100,
        DataEffect2 = UpgradeEffect.Rmnr, //Mana regeneration
        DataBase2 = 0.33f,
        DataMod2 = 0.33f,
        DataEffect3 = UpgradeEffect.Rhpx, //Hit point
        DataBase3 = 40,
        DataMod3 = 40,
      };
      //Level-based research data
      for (var i = 0; i < casterUpgrade.StatsLevels; i++)
      {
        casterUpgrade.TextName[i] = casterUpgrade.TextTooltip[i];
        casterUpgrade.TextTooltip[i] = $"{casterUnit.TextName} {_casterNamesByLevel[i]} Training";
        casterUpgrade.TextHotkey[i] = Utils.GetHotkeyByButtonPosition(new Point(0, casterUnit.ArtButtonPositionY));
        casterUpgrade.ArtIcon[i] = casterAbilities[i + 1].ArtIconNormal; //Research has the same icon as the ability it will unlock
        casterUpgrade.TextTooltipExtended[i] = $"Increases {casterUnit.TextName}' mana capacity, mana regeneration rate, hit points," +
          $" and gives them the ability to cast {casterAbilities[i + 1]}.";
      }
      //Caster ability modifications
      var j = 0;
      foreach (var ability in casterAbilities)
      {
        j++;
        ability.TechtreeRequirements = new List<Tech>() { new Tech(casterUpgrade) };
        ability.TechtreeRequirementsLevels = new int[] { j };
      }
      //Unit modifications
      casterUnit.ArtCasterUpgradeArt = CASTER_UPGRADE_ART;
      casterUnit.TextCasterUpgradeNames = new string[] {
        $" - {casterAbilities[0].TextName}",
        $" - {casterAbilities[0].TextName}, {casterAbilities[1].TextName}",
        $" - {casterAbilities[0].TextName}, {casterAbilities[1].TextName}, {casterAbilities[2].TextName}",
      };
      var newUpgradesUsed = casterUnit.TechtreeUpgradesUsed.ToList();
      newUpgradesUsed.Add(casterUpgrade);
      casterUnit.TechtreeUpgradesUsed = newUpgradesUsed;
      return casterUpgrade;
    }
  }
}
