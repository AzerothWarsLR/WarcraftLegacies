using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Powers;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Thrall becomes the World Shaman and gets cool stuff.
  /// </summary>
  public sealed class QuestWorldShaman : QuestData
  {
    /// <inheritdoc />
    public QuestWorldShaman() : base("The World-Shaman",
      "The elements of Azeroth are in terrible disarray, and the situation only grows worse as rising conflicts threaten to tear our world apart. Thrall, as one of the most formidable Shamans of his time, must take up the mantle of the World-Shaman if he is to save his people - and the world.",
      @"ReplaceableTextures\CommandButtons\BTNspell_shaman_maelstromweapon.blp")
    {
      AddObjective(new ObjectiveLegendLevel(LegendFrostwolf.LegendThrall, 12));
      AddObjective(new ObjectiveChannelRect(Regions.MaelstromAmbient, "the Maelstrom", LegendFrostwolf.LegendThrall, 120, 270));
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Thrall has stabilized the power of the Maelstrom and stored it within the Doomhammer. He is no longer merely the Warchief of the Horde; he is the World-Shaman of all Azeroth.";
    
    /// <inheritdoc />
    protected override string RewardDescription =>
      "Thrall gains 2000 experience and 10 Intelligence, and you gain the power Maelstrom Weapon";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      LegendFrostwolf.LegendThrall?.Unit?.SetName("World-Shaman")
        .AddHeroAttributes(0, 0, 10)
        .AddExperience(2000);
      completingFaction.AddPower(new MaelstromWeapon
      {
        DamageChance = 0.35f,
        DamageDealt = 100,
        Effect = @"Doodads\Cinematic\Lightningbolt\Lightningbolt",
        ValidUnitTypes = new[]
        {
          Constants.UNIT_OPEO_PEON_FROSTWOLF_WARSONG_WORKER,
          Constants.UNIT_OGRU_GRUNT_FROSTWOLF_WARSONG,
          Constants.UNIT_OSHM_SHAMAN_FROSTWOLF,
          Constants.UNIT_O00A_FAR_SEER_FROSTWOLF_ELITE,
          Constants.UNIT_OTHR_WARCHIEF_OF_THE_HORDE_FROSTWOLF,
          Constants.UNIT_H00C_DREK_THAR_FROSTWOLF_DEMI
        }
      });
    }
  }
}