using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.Warsong;

public sealed class QuestBloodpact : QuestData
{
  private readonly LegendaryHero _mannoroth;
  private readonly LegendaryHero _grom;

  /// <summary>
  /// Initializes a new instance of the class <see cref="QuestBloodpact"/>.
  /// </summary>
  public QuestBloodpact(LegendaryHero mannoroth, LegendaryHero grom)
    : base("The Bloodpact",
      "The Warsong is still vulnerable to the tentation of Mannoroth's Blood. If they drink it from the Fountain, they would have a surge of power. Although, Thrall would certainly hurry to save his friend Grom from the corruption.",
      @"ReplaceableTextures\CommandButtons\BTNBloodFury.blp")
  {
    AddObjective(new ObjectiveResearch(UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH,
      UNIT_NBFL_FOUNTAIN_OF_BLOOD_WARSONG));
    Global = true;
    _mannoroth = mannoroth;
    _grom = grom;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Warsong has drunk the blood of Mannoroth. It will take Thrall 4 minutes to save Grom and purify the Warsong Clan orcs.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "You will gain Mannoroth as a temporary unit, all your orcs except your Kor'kron Elites will gain 200 hit points and chaos damage. After 4 min, your units will revert to normal and Mannoroth will become hostile.";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var timerBloodpact = timer.Create();
    _mannoroth.ForceCreate(completingFaction.Player, Regions.FountainUnlock.Center, 270);
    _grom.UnitType = UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT;
    timerBloodpact.Start(180, false, () =>
    {
      completingFaction.SetObjectLimit(UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH, -1);
      completingFaction.SetObjectLevel(UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH, -1);
      completingFaction.SetObjectLevel(UPGRADE_R09P_REVERT_BLOODPACT, 1);

      _mannoroth.ForceCreate(player.NeutralAggressive, Regions.FountainUnlock.Center, 270);
      _grom.UnitType = UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_WARSONG;
    });
  }
}
