using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestArgentDawn : QuestData
  {
    private const int RESEARCH_ID = FourCC("R088"); //This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC("R087"); //This research is given when the quest is completed

    private Global()
    {
      return true;
    }

    public QuestArgentDawn() : base("The Argent Dawn",
      "The Militia of Lordaeron has been solidified into the Argent Dawn, a strong military force lead by Tirion Fording.",
      "ReplaceableTextures\\CommandButtons\\BTNResurrection.blp")
    {
      AddQuestItem(new QuestItemResearch(RESEARCH_ID, FourCC("h00T")));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
      ;
      ;
    }

    protected override string CompletionPopup =>
      "The Argent Dawn has been declared && ready to join the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Unlock your elites, Crusader units && Tirion Fordring";


    bool operator

    protected override void OnComplete()
    {
      Holder.Name = "Argent";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNTirionPaladin.blp";
      SetPlayerTechResearched(FACTION_SCARLET.Player, FourCC("R086"), 1);
      PlayThematicMusicBJ("war3mapImported\\ScarletTheme.mp3");
      SetPlayerColor(Holder.Player, PLAYER_COLOR_SNOW);

      FACTION_SCARLET.ModObjectLimit(FourCC("h08I"), -UNLIMITED); //Crusader
      FACTION_SCARLET.ModObjectLimit(FourCC("h09I"), UNLIMITED); //Argent Crusader

      FACTION_SCARLET.ModObjectLimit(FourCC("h08L"), -UNLIMITED); //Cavalier
      FACTION_SCARLET.ModObjectLimit(FourCC("h0A3"), UNLIMITED); //Lilian

      FACTION_SCARLET.ModObjectLimit(FourCC("h08J"), -UNLIMITED); //Arbalest
      FACTION_SCARLET.ModObjectLimit(FourCC("h09J"), UNLIMITED); //Lilian
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(RESEARCH_ID, 1);
    }
  }
}