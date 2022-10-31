using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Lordaeron;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class LordaeronQuestSetup
  {
    public static QuestData TheAshbringer { get; private set; }

    public static void Setup()
    {
      var lordaeron = LordaeronSetup.Lordaeron;

      var questStrahnbrad = new QuestStrahnbrad(Regions.StrahnbradUnlock);
      var questStratholme = new QuestStratholme(Regions.StratholmeUnlock);

      lordaeron.AddQuest(questStratholme);
      lordaeron.StartingQuest = questStratholme;
      lordaeron.AddQuest(questStrahnbrad);
      lordaeron.AddQuest(new QuestCapitalCity(Regions.Terenas, PreplacedUnitSystem.GetUnit(FourCC("nemi")),
        new QuestData[]
        {
          questStrahnbrad,
          questStratholme
        }));

      lordaeron.AddQuest(new QuestShoresOfNorthrend());
      lordaeron.AddQuest(new QuestThunderEagle());
      lordaeron.AddQuest(new QuestKingArthas(PreplacedUnitSystem.GetUnit(FourCC("nemi"))));
      lordaeron.AddQuest(new QuestLivingShadow());
      lordaeron.AddQuest(new QuestKingdomOfManLordaeron());
      lordaeron.AddQuest(new QuestGarithosCrusade());
      lordaeron.AddQuest(new QuestGarithosMindControl());

      TheAshbringer = new QuestAshbringer();
    }
  }
}