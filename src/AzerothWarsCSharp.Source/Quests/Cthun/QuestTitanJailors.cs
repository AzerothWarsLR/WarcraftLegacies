using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestTitanJailors : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _waygate;

    public QuestTitanJailors(Rectangle rescueRect, unit waygate) : base("Jailors of the Old God",
      "The Old God C'thun is imprisoned deep within the temple of Ahn'qiraj, defended by mechanical wardens left behind by the Titans.",
      "ReplaceableTextures\\CommandButtons\\BTNArmorGolem.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnit(FourCC("nsgg")))); //Golem
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02K"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n078"))));
      AddQuestItem(new QuestItemExpire(1428));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R07B");
      _waygate = waygate;

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "THe titan jailors guarding C'thuns resting place have been destroyed. Now nothing stands between the Qiraji and their master.";

    protected override string RewardDescription =>
      "Gain control of all units in Ahn'qiraj's inner temple and unlock the awakening spell for C'thunn";

    private void ActivateWaygate()
    {
      WaygateActivate(_waygate, true);
      WaygateSetDestination(_waygate, Regions.Silithus_Stone_Interior.Center.X,
        Regions.Silithus_Stone_Interior.Center.Y);
    }

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) GeneralHelpers.UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      ActivateWaygate();
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) GeneralHelpers.UnitRescue(unit, Holder.Player);
      ActivateWaygate();
    }
  }
}