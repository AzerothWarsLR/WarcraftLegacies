using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestSkullOfGuldan : QuestData
  {
    private readonly ObjectiveAnyUnitInRect _objectiveAnyUnitInRect;

    public QuestSkullOfGuldan() : base(
      "The Skull of Gul'dan",
      "The Skull of the master warlock Gul'dan is protected by the Mages of Dalaran. It rightfully belongs to the Legion.",
      "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp")
    {
      _objectiveAnyUnitInRect = new ObjectiveAnyUnitInRect(Regions.DalaranDungeon, "Dalaran Dungeons", true);
      AddObjective(_objectiveAnyUnitInRect);

      AddObjective(new ObjectiveEitherOf(new ObjectiveLegendDead(LegendNaga.LegendIllidan),
        new ObjectiveFactionDefeated(IllidariSetup.Illidari)));
      AddObjective(new ObjectiveSelfExists());
    }

    protected override string CompletionPopup => "The Skull of Gul'dan";

    protected override string RewardDescription => "The Skull of Gul'dan has been retrieved by " +
                                                   GetHeroProperName(_objectiveAnyUnitInRect.CompletingUnit) +
                                                   ". Its nefarious energies will fuel the Legion's operations on Azeroth.";

    protected override void OnComplete(Faction completingFaction)
    {
      ArtifactSetup.ArtifactSkullofguldan.LocationType = ArtifactLocationType.Ground;
      _objectiveAnyUnitInRect.CompletingUnit.AddItemSafe(ArtifactSetup.ArtifactSkullofguldan.Item);
    }

    protected override void OnFail(Faction completingFaction)
    {
      SetItemPosition(ArtifactSetup.ArtifactSkullofguldan.Item, -11867, 222165);
      ArtifactSetup.ArtifactSkullofguldan.LocationType = ArtifactLocationType.Ground;
    }
  }
}