using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestArgentDawn : QuestData
  {
    private static readonly int RequiredResearchId = FourCC("R088");

    public QuestArgentDawn() : base("The Argent Dawn",
      "The Militia of Lordaeron has been solidified into the Argent Dawn, a strong military force lead by Tirion Fording.",
      "ReplaceableTextures\\CommandButtons\\BTNResurrection.blp")
    {
      AddQuestItem(new QuestItemResearch(RequiredResearchId, FourCC("h00T")));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R087");
      Global = true;
    }

    protected override string CompletionPopup =>
      "The Argent Dawn has been declared and ready to join the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Unlock your elites, Crusader units && Tirion Fordring";
    
    protected override void OnComplete()
    {
      Holder.Name = "Argent";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNTirionPaladin.blp";
      SetPlayerTechResearched(ScarletSetup.FactionScarlet.Player, FourCC("R086"), 1);
      PlayThematicMusicBJ("war3mapImported\\ScarletTheme.mp3");
      SetPlayerColor(Holder.Player, PLAYER_COLOR_SNOW);

      ScarletSetup.FactionScarlet.ModObjectLimit(FourCC("h08I"), -Faction.UNLIMITED); //Crusader
      ScarletSetup.FactionScarlet.ModObjectLimit(FourCC("h09I"), Faction.UNLIMITED); //Argent Crusader

      ScarletSetup.FactionScarlet.ModObjectLimit(FourCC("h08L"), -Faction.UNLIMITED); //Cavalier
      ScarletSetup.FactionScarlet.ModObjectLimit(FourCC("h0A3"), Faction.UNLIMITED); //Lilian

      ScarletSetup.FactionScarlet.ModObjectLimit(FourCC("h08J"), -Faction.UNLIMITED); //Arbalest
      ScarletSetup.FactionScarlet.ModObjectLimit(FourCC("h09J"), Faction.UNLIMITED); //Lilian
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(RequiredResearchId, 1);
    }
  }
}