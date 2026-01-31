using MacroTools.Artifacts;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Quests.Quelthalas;

namespace WarcraftLegacies.Source.Quests.Scourge;

public sealed class QuestKelthuzadLich : QuestData
{
  private readonly Capital _sunwell;
  private readonly LegendaryHero _kelthuzad;
  private readonly Faction _quelthalas;
  private readonly Artifact _sunwellVial;
  private const int UnittypeKelthuzadLich = UNIT_UKTL_ARCHLICH_OF_THE_SCOURGE_SCOURGE_LICH;

  public QuestKelthuzadLich(Capital sunwell, LegendaryHero kelthuzad, Faction quelthalas, Artifact sunwellVial) : base(
    "Into the Realm Eternal",
    "Kel'thuzad is the leader of the Cult of the Damned and an extraordinarily powerful necromancer. If he were to be brought to the Sunwell and submerged in its waters, he would be reanimated as an immortal Lich.",
    @"ReplaceableTextures\CommandButtons\BTNLichVersion2.blp")
  {
    _sunwell = sunwell;
    _kelthuzad = kelthuzad;
    _quelthalas = quelthalas;
    _sunwellVial = sunwellVial;
    AddObjective(new ObjectiveControlCapital(sunwell, false));
    AddObjective(new ObjectiveLegendInRect(kelthuzad, Regions.Sunwell, "The Sunwell"));
    ResearchId = UPGRADE_R065_QUEST_COMPLETED_INTO_THE_REALM_ETERNAL;
    Global = true;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Necromancer Kel'thuzad has been immersed in the Sunwell and reborn as a Lich. The well, formerly a beacon of eternal light and power, has been twisted into a font of dark magic, spreading malevolence across the land.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Permanently corrupt the Sunwell and turn Kel'thuzad into a Lich, causing his Dark Ritual ability to also summon a Revenant";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    _kelthuzad.UnitType = UnittypeKelthuzadLich;
    _kelthuzad.PermaDies = false;
    _kelthuzad.Unit.Life = _kelthuzad.Unit.MaxLife;
    _kelthuzad.Unit.Mana = _kelthuzad.Unit.MaxMana;
    effect.Create("war3mapImported\\Soul Beam Blue.mdx", _kelthuzad.Unit.X, _kelthuzad.Unit.Y).Dispose();
    effect.Create(@"Abilities\Spells\Undead\FrostNova\FrostNovaTarget.mdl", _kelthuzad.Unit.X, _kelthuzad.Unit.Y).Dispose();

    CorruptSunwell();
  }

  private void CorruptSunwell()
  {
    if (_sunwell.Unit != null)
    {
      _sunwell.Unit.RemoveAbility(ABILITY_A0OC_EXTRACT_VIAL_ALL);
      _sunwell.Unit.RemoveAbility(ABILITY_A0EP_SUMMON_GRANITE_GOLEMS_QUEL_THALAS_SUNWELL);
      _sunwell.Unit.AddAbility(ABILITY_A00D_DESTROY_THE_CORRUPTED_SUNWELL_QUEL_THALAS_SUNWELL);
      _sunwell.Unit.MaxMana = 0;
      _sunwell.Unit.Skin = UNIT_N079_THE_SUNWELL_CORRUPTED_QUELTHALAS_OTHER;
      _sunwell.Unit.Name = "Corrupted Sunwell";
    }

    _sunwell.Essential = false;

    var corruptedSunwellPower = new CorruptedSunwell(0.2f);
    _quelthalas.AddPower(corruptedSunwellPower);

    var destroySunwellQuest = new QuestDestroyCorruptedSunwell(_sunwell, corruptedSunwellPower, _quelthalas.GetPowerByType<FontOfPower>()!);
    _quelthalas.AddQuest(destroySunwellQuest);
    _quelthalas.DisplayDiscovered(destroySunwellQuest, false);

    if (_sunwellVial.OwningUnit == _sunwell.Unit)
    {
      ArtifactManager.Destroy(_sunwellVial);
    }
  }
}
