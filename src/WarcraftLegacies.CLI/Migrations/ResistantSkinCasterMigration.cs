using System.Linq;
using War3Api.Object;
using War3Net.Build;
using Warcraft.Cartographer.Migrations;

namespace WarcraftLegacies.CLI.Migrations;

public sealed class ResistantSkinCasterMigration : IMapMigration
{
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {
    var abilityId = ABILITY_ACRK_RESISTANT_SKIN_1_1_POSITION.ToString();

    var targetUnits = new[]
    {
      UNIT_BHN1_HERALD_NZOTH,
      UNIT_ODKT_EREDAR_OCCULTIST_FEL,
      UNIT_O06P_WORGEN_SHAMAN_GILNEAS,
      UNIT_NNSU_COILFANG_SUMMONER_ILLIDARI,
      UNIT_N02F_WARLOCK_QUELTHALAS,
      UNIT_N048_BLOOD_MAGE_QUELTHALAS,
      UNIT_N09N_BISHOP_OF_THE_LIGHT_SCARLET,
      UNIT_N0E3_WARLOCK_SUNFURY
    };

    foreach (var unit in objectDatabase.GetUnits())
    {
      if (!targetUnits.Contains(unit.OldId))
      {
        continue;
      }

      var raw = unit.AbilitiesNormalRaw;

      if (string.IsNullOrWhiteSpace(raw))
      {
        unit.AbilitiesNormalRaw = abilityId;
        continue;
      }

      var parts = raw.Split(' ');

      if (!parts.Contains(abilityId))
      {
        unit.AbilitiesNormalRaw = raw + " " + abilityId;
      }
    }

    var unitData = objectDatabase.GetAllData().UnitData;
    map.UnitObjectData = unitData;
    map.UnitSkinObjectData = unitData;
  }
}
