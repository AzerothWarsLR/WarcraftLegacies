using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Lordaeron;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class LordaeronQuestSetup
  {
    public static QuestData TheAshbringer { get; private set; }

    public static void Setup()
    {
      var lordaeron = LordaeronSetup.FactionLordaeron;

      var questStrahnbrad = new QuestStrahnbrad(Regions.StrahnbradUnlock);
      var questStratholme = new QuestStratholme(Regions.StratholmeUnlock);

      lordaeron.AddQuest(questStratholme);
      lordaeron.StartingQuest = questStratholme;
      lordaeron.AddQuest(questStrahnbrad);
      lordaeron.AddQuest(new QuestCapitalCity(Regions.Terenas, PreplacedUnitSystem.GetUnitByUnitType(FourCC("nemi")),
        new QuestData[]
        {
          questStrahnbrad,
          questStratholme
        }));

      lordaeron.AddQuest(new QuestShoresOfNorthrend());
      lordaeron.AddQuest(new QuestThunderEagle());
      lordaeron.AddQuest(new QuestKingArthas(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nemi"))));
      lordaeron.AddQuest(new QuestLivingShadow());
      lordaeron.AddQuest(new QuestKingdomOfManLordaeron());
      lordaeron.AddQuest(new QuestGarithosCrusade());
      lordaeron.AddQuest(new QuestGarithosMindControl());

      TheAshbringer = new QuestAshbringer();
    }
  }
}