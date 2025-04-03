using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.Systems;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  /// <summary>
  /// Quest to eliminate the Destroyer to unlock further objectives for the Warsong.
  /// </summary>
  public sealed class QuestGrom : QuestData
  {
    private readonly LegendaryHero _gromHellscream;
    private readonly LegendaryHero _gargok; 

    public QuestGrom(PreplacedUnitSystem preplacedUnitSystem, LegendaryHero gromHellscreamLegend, LegendaryHero gargok) 
      : base("Breaking Bad Blood",
          "Tricked by Mannoroth into drinking the corrupted blood, Grom Hellscream has fallen into demonic fury, locked in battle with the Sentinels. To free him from this enslaving curse, you must defeat Mannoroth the Destroyer himself.",
          @"ReplaceableTextures\CommandButtons\BTNChaosGrom.blp")
    {
      AddObjective(new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(UNIT_NMAN_MANNOROTH_THE_DESTROYER_WARSONG_BLOODPACT)));
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

      // Clear all units in BloodPactBattle region upon completion
      var unitsToRemove = CreateGroup();
      GroupEnumUnitsInRect(unitsToRemove, Regions.BloodPactBattle.Rect, null);

      foreach (var unit in unitsToRemove.ToList())
      {
        RemoveUnit(unit);
      }

      DestroyGroup(unitsToRemove);

      // ModObject limits updates
      completingFaction.ModObjectLimit(Constants.UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_WARSONG, 1);
      completingFaction.ModObjectLimit(Constants.UNIT_O005_WARSONG_BATTLEMASTER_WARSONG, -1);
      
      _gargok.PermanentlyKill();
      
      if (_gromHellscream.Unit == null)
      {
        _gromHellscream.ForceCreate(completingFaction.Player, Regions.GromSpawn.Center, 90);
        _gromHellscream.Unit?.SetLevel(2, false);
      }
    }
  }
}