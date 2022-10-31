using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  public sealed class QuestFreeNerzhul : QuestData
  {
    public QuestFreeNerzhul() : base("Jailor of the Damned",
      "Before he became the Lich King, Ner'zhul was the chieftain and elder shaman of the Shadowmoon Clan. Perhaps something of his former self still survives within the Frozen Throne.",
      "ReplaceableTextures\\CommandButtons\\BTNShaman.blp")
    {
      AddObjective(new ObjectiveKillUnit(LegendScourge.LegendLichking.Unit));
    }


    protected override string CompletionPopup =>
      "Ner'zhul is finally free from his tortured existence as the bearer of the Helm of Domination. With his dying breath, he passes his wisdom on to Thrall.";

    protected override string RewardDescription => "Thrall gains 10 Strength, 10 Agility and 10 Intelligence";

    protected override void OnComplete(Faction completingFaction)
    {
      if (LegendFrostwolf.LegendThrall?.Unit != null)
        LegendFrostwolf.LegendThrall.Unit.AddHeroAttributes(10, 10, 10);
    }
  }
}