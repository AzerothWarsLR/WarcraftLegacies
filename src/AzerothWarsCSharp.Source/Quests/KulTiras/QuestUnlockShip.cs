using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestUnlockShip : QuestData
  {
    private readonly unit _proudmooreCapitalShip;
    
    protected override string FailurePopup =>
      "Boralus has fallen, Katherine has escaped on the Proudmoore Capital Ship with a handful of Survivors.";

    protected override string PenaltyDescription =>
      "You lose everything you control, but you gain Katherine at the capital ship.";

    public QuestUnlockShip(unit proudmooreCapitalShip) : base("The Zandalar Menace",
      "The Troll Empire of Zandalar is a danger to the safety of Kul'tiras and the Alliance. Before setting sail, we must eliminate them.",
      "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendDazaralor, false));
      AddQuestItem(new QuestItemControlLegend(LegendKultiras.LegendBoralus, true));
      _proudmooreCapitalShip = proudmooreCapitalShip;
    }

    protected override string CompletionPopup => "The Proudmoore capital ship is now ready to sails!";

    protected override string RewardDescription =>
      "Unpause the Proudmoore capital ship and unlocks the buildings inside.";

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.ShipAmbient.Rect, Holder.Player);
      PauseUnit(_proudmooreCapitalShip, false);
    }

    protected override void OnFail()
    {
      LegendKultiras.LegendKatherine.StartingXp = GetHeroXP(LegendKultiras.LegendKatherine.Unit);
      Holder.Obliterate();
      LegendKultiras.LegendKatherine.Spawn(Holder.Player, -15223, -22856, 110);
      UnitAddItem(LegendKultiras.LegendKatherine.Unit,
        CreateItem(FourCC("I00M"), GetUnitX(LegendKultiras.LegendKatherine.Unit),
          GetUnitY(LegendKultiras.LegendKatherine.Unit)));
      if (GetLocalPlayer() == Holder.Player)
        SetCameraPosition(Regions.ShipAmbient.Center.X, Regions.ShipAmbient.Center.Y);
      RescueNeutralUnitsInRect(Regions.ShipAmbient.Rect, Holder.Player);
      PauseUnit(_proudmooreCapitalShip, true);
      SetUnitOwner(_proudmooreCapitalShip, Holder.Player, true);
    }
  }
}