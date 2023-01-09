using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public class QuestReanimateSylvanas : QuestData
  {
    public QuestReanimateSylvanas() : base("The First Banshee",
      "Sylvanas, the Ranger-General of Silvermoon, stands between the legions of the Scourge and the Sunwell. Destroy her people, and her soul will be transformed into a tormented Banshee under the Scourge's control.",
      "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendQuelthalas.LegendSunwell, false));
      ResearchId = FourCC("R02D");
    }

    protected override void OnComplete(Faction completingFaction)
    {
      SetUnitAnimation(LegendQuelthalas.LegendSunwell.Unit, "stand second");
      SetUnitAnimation(LegendQuelthalas.LegendSunwell.Unit, "stand third");
    }

    protected override string RewardDescription => "You can summon Sylvanas from the " +
                                                   GetObjectName(Constants.UNIT_U010_ALTAR_OF_THE_QUEEN_FORSAKEN_ALTAR);

    protected override string CompletionPopup =>
      "Quel'thalas has fallen to the Scourge's onslaught. The Sunwell itself has been corrupted, cutting the quel'dorei off from the source of their longevity. Sylvanas is denied a clean death following her tenacious defense, and she becomes the first of the High Elven Banshees.";
  }
}