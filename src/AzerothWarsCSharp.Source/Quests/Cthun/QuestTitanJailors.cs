using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using GeneralHelpers = AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestTitanJailors : QuestData
  {
    protected override string CompletionPopup =>
      "THe titan jailors guarding C'thuns resting place have been destroyed. Now nothing stands between the Qiraji and their master.";

    protected override string CompletionDescription =>
      "Gain control of all units in Ahn'qiraj's inner temple and unlock the awakening spell for C'thunn";

    protected override void OnFail()
    {
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_TunnelUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      WaygateActivateBJ(true, gg_unit_h03V_0591);
      WaygateSetDestinationLocBJ(gg_unit_h03V_0591, GetRectCenter(gg_rct_Silithus_Stone_Interior));
    }

    protected override void OnComplete()
    {
      WaygateActivateBJ(true, gg_unit_h03V_0591);
      WaygateSetDestinationLocBJ(gg_unit_h03V_0591, GetRectCenter(gg_rct_Silithus_Stone_Interior));
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_TunnelUnlock, Holder.Player);
    }

    public QuestTitanJailors() : base("Jailors of the Old God",
      "The Old God C'thun is imprisoned deep within the temple of Ahn'qiraj, defended by mechanical wardens left behind by the Titans.",
      "ReplaceableTextures\\CommandButtons\\BTNArmorGolem.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nsgg")))); //Golem
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02K"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n078"))));
      AddQuestItem(new QuestItemExpire(1428));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R07B");
    }
  }
}