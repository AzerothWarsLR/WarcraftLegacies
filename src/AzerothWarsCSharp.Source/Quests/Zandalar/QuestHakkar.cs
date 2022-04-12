using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestHakkar : QuestData
  {
    public QuestHakkar() : base("The Binding of the Soulflayer",
      "Hakkar is the most dangerous and powerful of the Troll gods. Only by fusing the Demon Soul would the Zandalari be able to control Hakkar and bind him to their will.",
      "ReplaceableTextures\\CommandButtons\\BTNWindSerpent2blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactZinrokh));
      AddQuestItem(new QuestItemArtifactInRect(ArtifactSetup.ArtifactZinrokh, Regions.DrownedTemple.Rect,
        "The Drowned Temple"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00U"))));
      Global = true;
    }

    protected override string CompletionPopup => "Hakkar has emerged from the Drowned Temple";

    protected override string RewardDescription => "Gain the demigod hero Hakkar";

    protected override void OnComplete()
    {
      LegendTroll.LEGEND_HAKKAR.Spawn(Holder.Player, Regions.DrownedTemple.Center.X,
        Regions.DrownedTemple.Center.Y, 270);
      SetHeroLevel(LegendTroll.LEGEND_HAKKAR.Unit, 12, false);
    }
  }
}