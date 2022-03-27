using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestFelHordeKillIronforge : QuestData
  {
    private const int UNIT_LIMIT = 4;
    private static readonly int UnittypeId = FourCC("nina");
    private static readonly int BuildingId = FourCC("o030");

    public QuestFelHordeKillIronforge() : base("Felsteel Refining",
      "The smiths of Ironforge have long been put to use crafting goods && war machinery. In the hands of the Fel Horde, they could be used to smelt && refine the ultimate metal: Felsteel.",
      "ReplaceableTextures\\CommandButtons\\BTNInfernalFlameCannon.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendIronforge.LegendGreatforge));
      ResearchId = FourCC("R011");
    }


    protected override string CompletionPopup =>
      "The Great Forge has been annihilated. The Fel HordeFourCC(s peons immediately salvage its intact refineries && put them to purpose in the creation of Felsteel.";

    protected override string CompletionDescription => "Learn to train " + I2S(UNIT_LIMIT) + " " +
                                                       GetObjectName(UnittypeId) + "s from the " +
                                                       GetObjectName(BuildingId) + " && acquire Felsteel Plating";

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(UnittypeId, UNIT_LIMIT);
    }
  }
}