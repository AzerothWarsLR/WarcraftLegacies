using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  public sealed class QuestArgentDawn : QuestData
  {
    private const int REQUIRED_RESEARCH_ID = Constants.UPGRADE_R088_RAYS_OF_A_NEW_DAWN_SCARLET_CRUSADE;

    public QuestArgentDawn() : base("The Argent Dawn",
      "The Militia of Lordaeron has been solidified into the Argent Dawn, a strong military force lead by Tirion Fording.",
      "ReplaceableTextures\\CommandButtons\\BTNResurrection.blp")
    {
      AddObjective(new ObjectiveResearch(REQUIRED_RESEARCH_ID, Constants.UNIT_H00T_SCARLET_MONASTERY_SCARLET_LORDAERON));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R087_QUEST_COMPLETED_THE_ARGENT_DAWN;
      Global = true;
    }

    protected override string CompletionPopup =>
      "The Argent Dawn has been declared and ready to join the Alliance.";

    protected override string RewardDescription => "Unlock your elites, Crusader units and Tirion Fordring";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Name = "Argent";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNTirionPaladin.blp";
      SetPlayerTechResearched(ScarletSetup.ScarletCrusade.Player, Constants.UPGRADE_R086_PATH_CHOSEN, 1);
      PlayThematicMusic("war3mapImported\\ScarletTheme.mp3");
      SetPlayerColor(completingFaction.Player, PLAYER_COLOR_SNOW);

      ScarletSetup.ScarletCrusade.ModObjectLimit(Constants.UNIT_H08I_CRUSADER_SCARLET, -Faction.UNLIMITED);
      ScarletSetup.ScarletCrusade.ModObjectLimit(Constants.UNIT_H09I_HALBARDIER_ARGENT, Faction.UNLIMITED);

      ScarletSetup.ScarletCrusade.ModObjectLimit(Constants.UNIT_H08L_CAVALIER_SCARLET, -Faction.UNLIMITED);
      ScarletSetup.ScarletCrusade.ModObjectLimit(Constants.UNIT_H0A3_LANCER_ARGENT, Faction.UNLIMITED);

      ScarletSetup.ScarletCrusade.ModObjectLimit(Constants.UNIT_H08J_ARBALEST_SCARLET, -Faction.UNLIMITED);
      ScarletSetup.ScarletCrusade.ModObjectLimit(Constants.UNIT_H09J_CROSSBOWMAN_SCARLET, Faction.UNLIMITED);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(REQUIRED_RESEARCH_ID, 1);
    }
  }
}