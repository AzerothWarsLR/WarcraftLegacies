// using System.Collections.Generic;
// using AzerothWarsCSharp.MacroTools.FactionSystem;
// using AzerothWarsCSharp.MacroTools.QuestSystem;
// using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
// using AzerothWarsCSharp.MacroTools.Wrappers;
// using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;
//
// using static War3Api.Common;  using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
// {
//   public sealed class QuestThirdObelisk : QuestData
//   {
//     private static readonly int QuestResearchId = FourCC("R07K");
//     private readonly List<unit> _rescueUnits = new();
//
//     public QuestThirdObelisk(List<rect> rescueRects) : base("Merging of Realities",
//       "Reality frays at the seams as madness threatents to overtake it. Once an Obelisk has been established in the Twilight Highlands, the mirror worlds of Azeroth and Ny'alotha will finally be one, and the Black empire will be unleashed.",
//       "ReplaceableTextures\\CommandButtons\\BTNHorrorSoul.blp")
//     {
//       AddQuestItem(new QuestItemObelisk(ControlPointManager.GetFromUnitType(FourCC("n02S"))));
//       AddQuestItem(new QuestItemObelisk(ControlPointManager.GetFromUnitType(FourCC("n04V"))));
//       AddQuestItem(new QuestItemObelisk(ControlPointManager.GetFromUnitType(FourCC("n0BD"))));
//       AddQuestItem(new QuestItemExpire(1800));
//       Global = true;
//
//       AddQuestItem(new QuestItemObelisk(ControlPointManager.GetFromUnitType(FourCC("n0BD"))));
//       foreach (var rescueRect in rescueRects)
//       foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
//       {
//         SetUnitInvulnerable(unit, true);
//         _rescueUnits.Add(unit);
//       }
//     }
//
//     protected override string CompletionPopup =>
//       "The Merging of Realities has come to pass. The NyaFourCC(lothan portals to Storm Peaks, Northern Highlands, and Tanaris have been permanently opened.";
//
//     protected override string RewardDescription =>
//       "The NyaFourCC(lothan portals to Storm Peaks, Northern Highlands, and Tanaris will be permanently opened";
//
//     //Opens the central portals in Nyalotha permanently.
//     private void OpenPortals()
//     {
//       Holder.ModObjectLimit(FourCC("u02E"), -Faction.UNLIMITED); //Herald
//       Holder.SetObjectLevel(QuestResearchId, 1);
//       BlackEmpirePortalSetup.BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS.PortalState = BlackEmpirePortalState.Open;
//       BlackEmpirePortalSetup.BLACKEMPIREPORTAL_TANARIS.PortalState = BlackEmpirePortalState.Open;
//       BlackEmpirePortalSetup.BLACKEMPIREPORTAL_NORTHREND.PortalState = BlackEmpirePortalState.Open;
//
//
//       RemoveUnit(Herald.Instance.Unit);
//       BlackEmpirePortal.GoToNext();
//       if (GetLocalPlayer() == Holder.Player) SetCameraPosition(-25528, -1979);
//     }
//
//     protected override void OnComplete()
//     {
//       foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
//
//       PlayThematicMusic("war3mapImported\\BlackEmpireTheme.mp3");
//       OpenPortals();
//     }
//
//     protected override void OnFail()
//     {
//       OpenPortals();
//     }
//   }
// }