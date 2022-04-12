using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestTitanJailors : QuestData
  {
    private readonly unit _waygate;
    
    protected override string CompletionPopup =>
      "THe titan jailors guarding C'thuns resting place have been destroyed. Now nothing stands between the Qiraji and their master.";

    protected override string RewardDescription =>
      "Gain control of all units in Ahn'qiraj's inner temple and unlock the awakening spell for C'thunn";

    private void ActivateWaygate()
    {
      WaygateActivate(_waygate, true);
      WaygateSetDestination(_waygate, Regions.Silithus_Stone_Interior.Center.X, Regions.Silithus_Stone_Interior.Center.Y);
    }
    
    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.TunnelUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      ActivateWaygate();
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.TunnelUnlock.Rect, Holder.Player);
      ActivateWaygate();
    }

    public QuestTitanJailors(unit waygate) : base("Jailors of the Old God",
      "The Old God C'thun is imprisoned deep within the temple of Ahn'qiraj, defended by mechanical wardens left behind by the Titans.",
      "ReplaceableTextures\\CommandButtons\\BTNArmorGolem.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nsgg")))); //Golem
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02K"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n078"))));
      AddQuestItem(new QuestItemExpire(1428));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R07B");
      _waygate = waygate;
    }
  }
}