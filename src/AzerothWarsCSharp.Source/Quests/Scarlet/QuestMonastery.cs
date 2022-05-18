using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestMonastery : QuestData
  {
    private static readonly int UnleashTheCrusadeResearchId = FourCC("R03P");
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _scarletMonastery;
    private readonly QuestData _sequel;

    public QuestMonastery(Rectangle rescueRect, unit scarletMonastery, QuestData sequel) : base("The Secret Cloister",
      "The Scarlet Monastery is the perfect place for the secret base of the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
    {
      _scarletMonastery = scarletMonastery;
      AddQuestItem(new QuestItemResearch(UnleashTheCrusadeResearchId, FourCC("h00T")));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = Constants.UPGRADE_R03F_QUEST_COMPLETED_UNLEASH_THE_CRUSADE;
      Global = true;
      _sequel = sequel;

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "The Scarlet Monastery Hand is complete and ready to join the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in the Scarlet Monastery and you will unally the alliance";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      SetPlayerTechResearched(KultirasSetup.FACTION_KULTIRAS.Player, FourCC("R06V"), 1);
      SetPlayerTechResearched(LordaeronSetup.FactionLordaeron.Player, FourCC("R06V"), 1);
      SetPlayerTechResearched(ScarletSetup.FactionScarlet.Player, FourCC("R086"), 1);
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      WaygateActivateBJ(true, _scarletMonastery);
      WaygateSetDestination(_scarletMonastery, Regions.ScarletMonastery.Center.X, Regions.ScarletMonastery.Center.Y);
      Holder.Team = TeamSetup.ScarletCrusade;
      Holder.Name = "Scarlet";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNSaidan Dathrohan.blp";
      PlayThematicMusicBJ("war3mapImported\\ScarletTheme.mp3");
      SetPlayerStateBJ(Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
      Holder.AddQuest(_sequel);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(UnleashTheCrusadeResearchId, 1);
    }
  }
}