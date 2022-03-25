using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestCapitalCity : QuestData
  {
    private readonly unit _unitToMakeInvulnerable;

    public QuestCapitalCity(unit unitToMakeInvulnreable) : base("Hearthlands",
      "The territories of Lordaeron are fragmented. Regain control of the old Alliance's hold to secure the kingdom.",
      "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.legendCaerdarrow, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01M"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01C"))));
      AddQuestItem(new QuestItemExpire(1472));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R04Y");
      _unitToMakeInvulnerable = unitToMakeInvulnreable;
    }

    protected override string CompletionPopup =>
      "Capital City has been liberated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Capital City";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.Terenas.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.Terenas.Rect, Holder.Player);
      SetUnitInvulnerable(_unitToMakeInvulnerable, true);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\CapitalCity.mp3");
    }
  }
}