using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZandalar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestZandalar(Rectangle rescueRect) : base("City of Gold", "We need to regain control of our land.",
      "ReplaceableTextures\\CommandButtons\\BTNBloodTrollMage.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("R04R"), FourCC("o03Z")));
      AddQuestItem(new QuestItemUpgrade(FourCC("o03Z"), FourCC("o03Y")));
      AddQuestItem(new QuestItemExpire(900));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R04W");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "The City of Gold is now yours to command and has joined the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in Zandalar and enables the Golden Fleet to be built";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusic("war3mapImported\\ZandalarTheme.mp3");
    }
  }
}