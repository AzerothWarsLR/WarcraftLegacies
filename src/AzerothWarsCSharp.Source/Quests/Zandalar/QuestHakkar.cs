//Anyone on the Night Elves team approaches Moonglade with a unit with the Horn of Cenarius,
//Causing Malfurion to spawn.

using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestHakkar : QuestData
  {
    private Global()
    {
      return true;
    }

    public QuestHakkar() : base("The Binding of the Soulflayer",
      "Hakkar is the most dangerous && powerful of the Troll gods. Only by fusing the Demon Soul would the Zandalari be able to control Hakkar && bind him to their will.",
      "ReplaceableTextures\\CommandButtons\\BTNWindSerpent2blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ARTIFACT_ZINROKH));
      AddQuestItem(new QuestItemArtifactInRect(ARTIFACT_ZINROKH, Regions.DrownedTemple.Rect, "The Drowned Temple"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00U"))));
      ;
      ;
    }

    protected override string CompletionPopup => "Hakkar has emerged from the Drowned Temple";

    protected override string CompletionDescription => "Gain the demigod hero Hakkar";


    bool operator

    protected override void OnComplete()
    {
      LEGEND_HAKKAR.Spawn(Holder.Player, GetRectCenterX(Regions.DrownedTemple),
        GetRectCenterY(gg_rct_DrownedTemple).Rect, 270);
      SetHeroLevel(LEGEND_HAKKAR.Unit, 12, false);
    }
  }
}