// using System.Collections.Generic;
// using AzerothWarsCSharp.MacroTools.FactionSystem;
// using AzerothWarsCSharp.MacroTools.QuestSystem;
// using AzerothWarsCSharp.MacroTools.Wrappers;
// using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;
//
// using static War3Api.Common;  using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
// {
//   public sealed class QuestSecondObelisk : QuestData
//   {
//     private readonly List<unit> _rescueUnits = new();
//
//     public QuestSecondObelisk(List<rect> rescueRects) : base("Second Obelisk",
//       "The convergence of floatities grows ever closer. An Obelisk must be established in Uldum.",
//       "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp")
//     {
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
//       "The second Obelisk has been set. Ny'alotha's connection to Azeroth grows stronger.";
//
//     protected override string RewardDescription =>
//       "Unlock the southern zone of NyaFourCC(lotha, and the next Herald you train will open a temporary portal to the Twilight Highlands.";
//
//     protected override void OnComplete(Faction completingFaction)
//     {
//       foreach (var unit in _rescueUnits) UnitRescue(unit, completingFaction.Player);
//       RemoveUnit(Herald.Instance.Unit);
//       BlackEmpirePortal.GoToNext();
//     }
//   }
// }