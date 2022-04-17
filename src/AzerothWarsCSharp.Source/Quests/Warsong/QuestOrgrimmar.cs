using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestOrgrimmar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private readonly int _researchId = FourCC("R05O"); //This research is required to complete the quest

    public QuestOrgrimmar(Rectangle rescueRect) : base("To Tame a Land",
      "This new continent is ripe for opportunity, if (the Horde is going to survive, a new city needs to be built.",
      "ReplaceableTextures\\CommandButtons\\BTNFortress.blp")
    {
      AddQuestItem(new QuestItemResearch(_researchId, FourCC("o02S")));
      AddQuestItem(new QuestItemExpire(1500));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R05R");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "Control of all units in Orgrimmar, able to train Varok";

    protected override string RewardDescription => "Control of all units in Orgrimmar, able to train Varok";

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\OrgrimmarTheme.mp3");
    }

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(_researchId, 1);
    }
  }
}