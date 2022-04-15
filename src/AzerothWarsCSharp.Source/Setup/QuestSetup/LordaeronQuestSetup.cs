using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Lordaeron;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class LordaeronQuestSetup
  {
    public static QuestData TheAshbringer { get; private set; }

    public static void Setup()
    {
      var lordaeron = LordaeronSetup.FactionLordaeron;
      //Early duel
      lordaeron.StartingQuest = lordaeron.AddQuest(new QuestStratholme(Regions.StratholmeUnlock));
      lordaeron.AddQuest(new QuestStrahnbrad(Regions.StrahnbradUnlock));
      lordaeron.AddQuest(new QuestCapitalCity(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nemi"))));

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