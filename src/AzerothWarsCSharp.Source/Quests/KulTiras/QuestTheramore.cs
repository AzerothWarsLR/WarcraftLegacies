using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestTheramore : QuestData
  {
    private static readonly int ResearchId = FourCC("R06K");


    private static group _theramoreUnits = CreateGroup();

    public QuestTheramore() : base("Theramore",
      "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there.",
      "ReplaceableTextures\\CommandButtons\\BTNHumanArcaneTower.blp")
    {
      AddQuestItem(new QuestItemResearch(ResearchId, FourCC("h076")));
      AddQuestItem(new QuestItemSelfExists());
      ;
      ;
    }

    protected override string CompletionPopup =>
      "A sizeable isle off the coast of Dustwallow Marsh has been colonized && dubbed Theramore, marking the first human settlement to be established on Kalimdor.";

    protected override string CompletionDescription => "Control of all units at Theramore";

    private static void GrantToPlayer(player whichPlayer)
    {
      unit u;
      while (true)
      {
        u = FirstOfGroup(_theramoreUnits);
        if (u == null) break;
        UnitRescue(u, whichPlayer);
        GroupRemoveUnit(_theramoreUnits, u);
      }

      DestroyGroup(_theramoreUnits);
      u = null;
      _theramoreUnits = null;
    }

    protected override void OnFail()
    {
      thistype.GrantToPlayer(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      Holder.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    protected override void OnComplete()
    {
      thistype.GrantToPlayer(Holder.Player);
      Holder.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }

    private static void OnInit()
    {
      group tempGroup;
      unit u;
      tempGroup = CreateGroup();
      _theramoreUnits = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.Theramore.Rect, null);
      while (true)
      {
        u = FirstOfGroup(tempGroup);
        if (u == null) break;
        SetUnitInvulnerable(u, true);
        SetUnitOwner(u, Player(PLAYER_NEUTRAL_PASSIVE), true);
        GroupAddUnit(_theramoreUnits, u);
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
    }
  }
}