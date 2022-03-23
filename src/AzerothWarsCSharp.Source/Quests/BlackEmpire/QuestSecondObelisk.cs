using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestSecondObelisk : QuestData
  {
    public QuestSecondObelisk() : base("Second Obelisk",
      "The convergence of floatities grows ever closer. An Obelisk must be established in Uldum.",
      "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp")
    {
      AddQuestItem(new QuestItemObelisk(ControlPoint.GetFromUnitType(FourCC("n0BD"))));
      ;
      ;
    }


    protected override string CompletionPopup => "The second Obelisk has been set. NyFourCC("

    protected override string CompletionDescription =>
      "Unlock the southern zone of NyaFourCC(lotha, && the next Herald you train will open a temporary portal to the Twilight Highlands.";

    alotha")s connection to Azeroth grows stronger.";

    protected override void OnComplete()
    {
      RescueUnitsInGroup(udg_NyalothaGroup2, Holder.Player);
      RescueUnitsInGroup(udg_NyalothaGroup3, Holder.Player);


      RemoveUnit(Herald.Instance.unit);
      BlackEmpirePortal.GoToNext();
    }
  }
}