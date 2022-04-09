using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  /// <summary>
  /// Chen Stormstout joins the Warsong when a Warsong <see cref="unit"/> approaches him.
  /// </summary>
  public sealed class QuestChenStormstout : QuestData
  {
    private readonly int _chenId = FourCC("Nsjs");
    private readonly int _chenResearch = FourCC("R037");
    private readonly unit _chen;
    
    public QuestChenStormstout(unit chen) : base("The Wandering Brewmaster",
      "Rumours tell of a strange white-furred creature from a foreign land. Perhaps it could be convinced to join the Horde.",
      "ReplaceableTextures\\CommandButtons\\BTNPandarenBrewmaster.blp")
    {
      AddQuestItem(new QuestItemAnyUnitInRect(Regions.Chen.Rect, "Chen Stormstout", false));
      AddQuestItem(new QuestItemSelfExists());
      _chen = chen;
    }

    protected override string CompletionPopup => "Chen Stormstout has joined the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "The hero Chen Stormstout";

    protected override void OnFail()
    {
      RemoveUnit(_chen);
    }

    protected override void OnComplete()
    {
      RemoveUnit(_chen);
      SetPlayerTechResearched(Holder.Player, _chenResearch, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(_chenResearch, Faction.UNLIMITED);
      Holder.ModObjectLimit(_chenId, 1);
      SetUnitInvulnerable(_chen, true);
    }
  }
}