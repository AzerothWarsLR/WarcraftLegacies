using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestVaultoftheWardens : QuestData
  {
    private static readonly int ResearchId = FourCC("R06H");
    private static readonly int WardenId = FourCC("h045");

    public QuestVaultoftheWardens() : base("Vault of the Wardens",
      "In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari. The Broken Isles, now raised from the sea floor, would be a strategic location for a newer edition of such a prison.",
      "ReplaceableTextures\\CommandButtons\\BTNReincarnationWarden.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n05Y"))));
      AddQuestItem(new QuestItemSelfExists());
      ;
      ;
    }


    protected override string CompletionPopup =>
      "With the Broken Isles && the Tomb of Sargeras secured, work has begun on a maximum security prison named the Vault of the Wardens.";

    protected override string CompletionDescription =>
      "The Vault of the Wardens && 4 free Wardens appear at the Broken Isles, && you learn to train Wardens";

    protected override void OnComplete()
    {
      CreateUnit(Holder.Player, FourCC("n04G"), GetRectCenterX(Regions.VaultoftheWardens),
        GetRectCenterY(gg_rct_VaultoftheWardens).Rect, 220);
      CreateUnits(Holder.Player, WardenId, GetRectCenterX(Regions.VaultoftheWardens),
        GetRectCenterY(gg_rct_VaultoftheWardens), 270.Rect, 4);
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      DisplayUnitTypeAcquired(Holder.Player, WardenId,
        "You can now train Wardens from the Vault of the Wardens, Sentinel Enclaves, && your capitals.");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(WardenId, 8);
      Holder.ModObjectLimit(ResearchId, 1);
    }
  }
}