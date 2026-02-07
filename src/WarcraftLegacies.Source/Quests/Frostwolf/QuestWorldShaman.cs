using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Powers;

namespace WarcraftLegacies.Source.Quests.Frostwolf;

/// <summary>
/// Thrall becomes the World Shaman and gets cool stuff.
/// </summary>
public sealed class QuestWorldShaman : QuestData
{
  private readonly LegendaryHero _thrall;

  /// <inheritdoc />
  public QuestWorldShaman(LegendaryHero thrall) : base("The World-Shaman",
    "The elements of Azeroth are in terrible disarray, and the situation only grows worse as rising conflicts threaten to tear our world apart. Thrall, as one of the most formidable Shamans of his time, must take up the mantle of the World-Shaman if he is to save his people - and the world.",
    @"ReplaceableTextures\CommandButtons\BTN_Lightning_Orc.blp")
  {
    _thrall = thrall;
    var controlPoints = new List<ControlPoint>
    {
      ControlPointManager.Instance.GetFromUnitType(UNIT_N028_MAELSTROM),
      ControlPointManager.Instance.GetFromUnitType(UNIT_N05Y_AZSUNA),
      ControlPointManager.Instance.GetFromUnitType(UNIT_N032_SURAMAR),
      ControlPointManager.Instance.GetFromUnitType(UNIT_N053_VAL_SHARAH),
      ControlPointManager.Instance.GetFromUnitType(UNIT_N05Z_STORMHEIM),
    };
    AddObjective(new ObjectiveLegendLevel(_thrall, 8));
    AddObjective(new ObjectiveChannelRect(Regions.MaelstromChannel, "the Maelstrom", _thrall, 120, 120, "Taming the Maelstrom"));
    AddObjective(new ObjectiveControlPoints(controlPoints, "on the Broken Isles and near the Maelstrom"));
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Thrall has stabilized the power of the Maelstrom and stored it within the Doomhammer. He is no longer merely the Warchief of the Horde; he is the World-Shaman of all Azeroth.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Thrall gains 2000 experience and 10 Agility, and you gain the Power Maelstrom Spirit";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    if (_thrall.Unit != null)
    {
      _thrall.Unit.Name = "World-Shaman";
      _thrall.Unit.AddHeroAttributes(0, 10, 0);
      AddHeroXP(_thrall.Unit, 2000, true);
    }

    completingFaction.AddPower(new MaelstromWeapon(0.12f, 100)
    {
      Effect = @"Doodads\Cinematic\Lightningbolt\Lightningbolt",
      ValidUnitTypes = new[]
      {
        UNIT_OPEO_PEON_FROSTWOLF_WARSONG_WORKER,
        UNIT_OGRU_GRUNT_FROSTWOLF,
        UNIT_OSHM_SHAMAN_FROSTWOLF,
        UNIT_O00A_FAR_SEER_FROSTWOLF_ELITE,
        UNIT_OTHR_WARCHIEF_OF_THE_HORDE_FROSTWOLF,
        UNIT_H00C_DREK_THAR_FROSTWOLF_DEMI,
        UNIT_H0CN_PACKLEADER_FROSTWOLF,
        UNIT_H0CO_MAMMOTH_WRANGLER_FROSTWOLF
      },
      IconName = "_Lightning_Orc"
    });
  }
}
