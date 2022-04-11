using AzerothWarsCSharp.MacroTools.Factions;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
using static AzerothWarsCSharp.MacroTools.Display;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestVaultoftheWardens : QuestData
  {
    private static readonly int WardenId = FourCC("h045");

    public QuestVaultoftheWardens() : base("Vault of the Wardens",
      "In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari. The Broken Isles, now raised from the sea floor, would be a strategic location for a newer edition of such a prison.",
      "ReplaceableTextures\\CommandButtons\\BTNReincarnationWarden.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n05Y"))));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R06H");
    }
    
    protected override string CompletionPopup =>
      "With the Broken Isles and the Tomb of Sargeras secured, work has begun on a maximum security prison named the Vault of the Wardens.";

    protected override string RewardDescription =>
      "The Vault of the Wardens and 4 free Wardens appear at the Broken Isles, and you learn to train Wardens";

    protected override void OnComplete()
    {
      CreateUnit(Holder.Player, FourCC("n04G"),Regions.VaultoftheWardens.Center.X,
        Regions.VaultoftheWardens.Center.Y, 220);
      CreateUnits(Holder.Player, WardenId, Regions.VaultoftheWardens.Center.X,
        Regions.VaultoftheWardens.Center.Y, 270, 4);
      DisplayUnitTypeAcquired(Holder.Player, WardenId,
        "You can now train Wardens from the Vault of the Wardens, Sentinel Enclaves, and your capitals.");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(WardenId, 8);
    }
  }
}