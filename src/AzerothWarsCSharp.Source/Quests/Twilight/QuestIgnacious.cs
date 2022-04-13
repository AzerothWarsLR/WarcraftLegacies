using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestIgnacious : QuestData
  {
    public QuestIgnacious() : base("Gift of the Firelord",
      "Destroying the Dwarf great forge will please the Great Elemental Lord, Ragnaros.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroAvatarOfFlame.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendIronforge.LegendGreatforge));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0AA"))));
      base.ResearchId = FourCC("R07Q");
    }
    
    protected override string CompletionPopup => "The great Ragnaros has ascended one of our shamans.";
    
    //Todo: specify altar name
    protected override string RewardDescription => "You can summon Ignacious from the Altar";
  }
}