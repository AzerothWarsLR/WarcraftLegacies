using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Quests;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class SharedQuestSetup
  {
    public static void Setup()
    {
      var tombOfSargerasQuest =
        new QuestTombOfSargeras(
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N032_TOMB_OF_SARGERAS, Regions.Broken_Isles.Center),
          Regions.Sargeras_Exit, PreplacedUnitSystem.GetUnit(Constants.UNIT_O01U_GUL_DAN_S_REMAINS));
      
      foreach (var faction in FactionManager.GetAllFactions())
      {
        faction.AddQuest(tombOfSargerasQuest);
      }
    }
  }
}