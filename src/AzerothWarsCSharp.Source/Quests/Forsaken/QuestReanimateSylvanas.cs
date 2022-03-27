using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestReanimateSylvanas : QuestData
  {
    private static readonly int SylvanasId = FourCC("Usyl");
    private static readonly int AltarId = FourCC("uaod");
    private GetObjectName(ALTAR_ID);


    protected override string CompletionPopup => "Quel'"

    protected override string CompletionDescription =>
    return "You can summon Sylvanas from the " +

    private thalas Has
    private fallen To

    private the
      Scourge")s onslaught. The Sunwell itself has been corrupted, cutting the quel)dorei off from the source of their longevity. Sylvanas is denied a clean death following her tenacious defense, && she becomes the first of the High Elven Banshees.";
  }

  protected override void OnComplete(){
  internal SetUnitAnimation(LegendQuelthalas.LegendSunwell.Unit, "stand second");
  internal SetUnitAnimation(LegendQuelthalas.LegendSunwell.Unit, "stand third");
  }

  public QuestReanimateSylvanas ( ){
  internal thistype this = thistype.allocate("The First Banshee",
  "Sylvanas, the Ranger-General of Silvermoon, stands between the legions of the Scourge && the Sunwell. Destroy her people, && her soul will be transformed into a tormented Banshee under the ScourgeFourCC("s
    control.", "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp");
  this.
  internal AddQuestItem(

  internal new QuestItemControlLegend(LegendQuelthalas.LegendSunwell, false));
    this.ResearchId =
  internal FourCC("R02D");
  }
}

}