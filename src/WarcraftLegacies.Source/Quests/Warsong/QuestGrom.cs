using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.FactionMechanics.Warsong;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Quests.Warsong;

/// <summary>
/// Quest to eliminate the Destroyer to unlock further objectives for the Warsong.
/// </summary>
public sealed class QuestGrom : QuestData
{
  private readonly LegendaryHero _gromHellscream;
  private readonly LegendaryHero _gargok;


  public QuestGrom(LegendaryHero gromHellscreamLegend, LegendaryHero gargok)
    : base("Breaking Bad Blood",
        "Tricked by Mannoroth into drinking from the corrupted fountain, Grom Hellscream has fallen into demonic fury, locked in battle with the Sentinels. To free him from this enslaving curse, you must defeat Mannoroth the Destroyer himself.",
        @"ReplaceableTextures\CommandButtons\BTNChaosGrom.blp")
  {
    AddObjective(new ObjectiveUnitIsDead(PreplacedWidgets.Units.Get(UNIT_NMAN_MANNOROTH_THE_DESTROYER_WARSONG_BLOODPACT)));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R013_QUEST_COMPLETED_BREAKING_BAD_BLOOD;
    _gromHellscream = gromHellscreamLegend;
    _gargok = gargok; // now correctly aligned
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "With Mannoroth's death, the dark curse binding Grom Hellscream shatters like twisted iron chains. Freed from corruption and the demon's grasp, a redeemed Grom Hellscream rises once more, joining your ranks to fight for the honor of the Warsong Clan.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gain control of Grom Hellscream; Gargok is permanently removed.";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    base.OnComplete(completingFaction);

    foreach (var unit in BloodPactBattleSimulation.BattleSimulationGroup.ToList())
    {
      unit.Dispose();
    }
    BloodPactBattleSimulation.BattleSimulationGroup.Clear();

    completingFaction.ModObjectLimit(UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_WARSONG, 1);
    completingFaction.ModObjectLimit(UNIT_O005_WARSONG_BATTLEMASTER_WARSONG, -1);

    _gargok.PermanentlyKill();
    if (_gromHellscream.Unit == null)
    {
      _gromHellscream.ForceCreate(completingFaction.Player, Regions.GromSpawn.Center, 90);
      _gromHellscream.Unit?.SetLevel(2, false);
      effect.Create("war3mapImported\\Soul Beam Blue.mdx", _gromHellscream.Unit.X, _gromHellscream.Unit.Y).Dispose();
      effect.Create(@"abilities\spells\human\holybolt.mdl", _gromHellscream.Unit.X, _gromHellscream.Unit.Y).Dispose();
    }
  }
}
