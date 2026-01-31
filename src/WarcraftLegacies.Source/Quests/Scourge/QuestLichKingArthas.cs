using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.FactionMechanics.Scourge;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Powers;

namespace WarcraftLegacies.Source.Quests.Scourge;

/// <summary>
/// Arthas ascends to become the Lich King.
/// </summary>
public sealed class QuestLichKingArthas : QuestData
{
  private readonly unit _utgardeKeep;
  private readonly Artifact _helmOfDomination;
  private readonly LegendaryHero _arthas;
  private readonly Capital _theFrozenThrone;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestLichKingArthas"/> class.
  /// </summary>
  public QuestLichKingArthas(unit utgardeKeep, Artifact helmOfDomination, LegendaryHero arthas, Capital theFrozenThrone) : base("The Ascension",
    "From within the depths of the Frozen Throne, the Lich King Ner'zhul cries out for his champion. Release the Helm of Domination from its confines and merge its power with that of the Scourge's greatest Death Knight.",
    @"ReplaceableTextures\CommandButtons\BTNRevenant.blp")
  {
    _utgardeKeep = utgardeKeep;
    _helmOfDomination = helmOfDomination;
    _arthas = arthas;
    _theFrozenThrone = theFrozenThrone;
    AddObjective(new ObjectiveLegendLevel(arthas, 12)
    {
      ResearchId = UPGRADE_ZB85_ARTHAS_MENETHIL_IS_LEVEL_12
    });
    AddObjective(new ObjectiveLegendCastSpellOnUnit(arthas, ABILITY_A0LR_ASCEND_ARTHAS, theFrozenThrone.Unit!));
    Global = true;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Arthas has ascended the Frozen Throne itself and shattered Ner'zhul's frozen prison. Ner'zhul and Arthas are now joined, body and soul, into one being: the god-like Lich King.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Arthas becomes the Lich King, the Frozen Throne loses its abilities, and you regain the Domination power if you don't have it";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    PlayThematicMusic(@"Sound\Music\mp3Music\LichKingTheme.mp3");

    TheFrozenThrone.Vacate(false);
    if (_theFrozenThrone.Unit != null)
    {
      _theFrozenThrone.Unit.SetOwner(completingFaction.Player!);
    }

    _arthas.UnitType = UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE;
    _arthas.PermaDies = true;
    _arthas.DeathMessage = "The day he was born, the very forests of Lordaeron whispered the name Arthas - but no King rules forever.";

    _arthas.Unit?.SetLifePercent(100);
    _arthas.Unit?.SetManaPercent(100);
    _arthas.Unit?.AddItemSafe(_helmOfDomination.Item);

    _utgardeKeep.Rescue(completingFaction.Player!);

    var domination = completingFaction.GetPowerByType<Domination>();
    if (domination == null)
    {
      domination = new Domination
      {
        ResearchId = UPGRADE_R008_DOMINATION_POWER,
        MindlessUndeadUnitTypes = new List<int>
        {
          UNIT_UGHO_GHOUL_SCOURGE,
          UNIT_U012_HALF_GHOUL_SCOURGE,
          UNIT_UABO_ABOMINATION_SCOURGE,
          UNIT_UFRO_FROST_WYRM_SCOURGE,
          UNIT_UCRM_BURROWED_CRYPT_FIEND_SCOURGE,
          UNIT_UCRY_CRYPT_FIEND_SCOURGE
        },
        IconName = "Revenant"
      };

      completingFaction.AddPower(domination);
    }
  }
}
