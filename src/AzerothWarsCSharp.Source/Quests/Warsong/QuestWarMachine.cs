using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestWarMachine : QuestData
  {
    protected override string CompletionPopup =>
      "The massive exploitation of Ashenvale has bolstered the entire Horde's weapons, armour and defenses.";

    protected override string CompletionDescription => "You and all of your allies gain the researches " +
                                                       GetObjectName(FourCC("Rhme")) + ", " +
                                                       GetObjectName(FourCC("Rhar")) + ", " +
                                                       GetObjectName(FourCC("Rorb")) + ", and " +
                                                       GetObjectName(FourCC("Rosp"));

    private void BlessPlayer(player whichPlayer)
    {
      SetPlayerTechResearched(whichPlayer, FourCC("Rhme"), GetPlayerTechCount(whichPlayer, FourCC("Rhme"), true) + 1);
      SetPlayerTechResearched(whichPlayer, FourCC("Rhar"), GetPlayerTechCount(whichPlayer, FourCC("Rhar"), true) + 1);
      SetPlayerTechResearched(whichPlayer, FourCC("Rorb"), 3);
      SetPlayerTechResearched(whichPlayer, FourCC("Rosp"), 3);
    }

    protected override void OnComplete()
    {
      foreach (var faction in Holder.Team.GetAllFactions())
      {
        BlessPlayer(faction.Player);
      }
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(FourCC("R021"), Faction.UNLIMITED);
    }

    public QuestWarMachine() : base("The War Machine",
      "The bountiful woodlands of Ashenvale are now accessible to the Horde. It is time to begin harvesting and armament operations.",
      "ReplaceableTextures\\CommandButtons\\BTNBundleOfLumber.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("R021"), FourCC("o01I")));
    }
  }
}