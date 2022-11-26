using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Frostwolf kills the Frozen Throne to get cool stuff for Thrall.
  /// </summary>
  public sealed class QuestFreeNerzhul : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestFreeNerzhul"/> class.
    /// </summary>
    public QuestFreeNerzhul() : base("Jailor of the Damned",
      "Before he became the Lich King, Ner'zhul was the chieftain and elder shaman of the Shadowmoon Clan. Perhaps something of his former self still survives within the Frozen Throne.",
      "ReplaceableTextures\\CommandButtons\\BTNShaman.blp")
    {
      AddObjective(new ObjectiveKillUnit(LegendScourge.LegendLichking.Unit));
      ResearchId = Constants.UPGRADE_R096_QUEST_COMPLETED_JAILOR_OF_THE_DAMNED;
    }
    
    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "Ner'zhul is finally free from his tortured existence as the bearer of the Helm of Domination. With his dying breath, he passes his wisdom on to Thrall.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Thrall gains 10 Strength, 10 Agility and 10 Intelligence";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (LegendFrostwolf.LegendThrall?.Unit != null)
        LegendFrostwolf.LegendThrall.Unit.AddHeroAttributes(10, 10, 10);
    }
  }
}