using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestVaultoftheWardens : QuestData
  {
    private static readonly int WardenId = FourCC("h045");

    public QuestVaultoftheWardens() : base("Vault of the Wardens",
      "In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari. The Broken Isles, now raised from the sea floor, would be a strategic location for a newer edition of such a prison.",
      "ReplaceableTextures\\CommandButtons\\BTNReincarnationWarden.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n05Y"))));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R06H");
    }

    protected override string CompletionPopup =>
      "With the Broken Isles and the Tomb of Sargeras secured, work has begun on a maximum security prison named the Vault of the Wardens.";

    protected override string RewardDescription =>
      "The Vault of the Wardens and 4 free Wardens appear at the Broken Isles, and you learn to train Wardens";

    protected override void OnComplete(Faction completingFaction)
    {
      CreateUnit(completingFaction.Player, FourCC("n04G"), Regions.VaultoftheWardens.Center.X,
        Regions.VaultoftheWardens.Center.Y, 220);
      CreateUnits(completingFaction.Player, WardenId, Regions.VaultoftheWardens.Center.X,
        Regions.VaultoftheWardens.Center.Y, 270, 4);
      completingFaction.Player.DisplayUnitTypeAcquired(WardenId,
        "You can now train Wardens from the Vault of the Wardens, Sentinel Enclaves, and your capitals.");
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(WardenId, 8);
    }
  }
}