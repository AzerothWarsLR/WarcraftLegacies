using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestCataclysm : QuestData
  {
    private static readonly int CataclysmResearch = FourCC("R05E");
    private readonly unit _robogoblin; //Todo: label what this actually is
    
    public QuestCataclysm() : base("The Cataclysm",
      "The Old God's will is finnicky, you are not privy to when their plan will be set in motion, but when it is, your cult will be ready to welcome it.",
      "ReplaceableTextures\\CommandButtons\\BTNDeathwing.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendTwilight.LEGEND_DEATHWING, false));
      _robogoblin = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h02U"));
      Global = true;
    }

    protected override string CompletionPopup => "Deathwing is here, Doomsday is at hand, the Cataclysm as begun!";

    protected override string RewardDescription =>
      "Cultists all over the world join your cause actively, Deathwing as a super demihero && the 2 elemental ascendant heroes.";
    
    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, CataclysmResearch, 1);
      PlayThematicMusicBJ("war3mapImported\\TwilightTheme.mp3");
      SetPlayerTechResearched(CthunSetup.FactionCthun.Player, FourCC("R07D"), 1);
      IssueImmediateOrderBJ(_robogoblin, "unrobogoblin");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(CataclysmResearch, Faction.UNLIMITED);
    }
  }
}