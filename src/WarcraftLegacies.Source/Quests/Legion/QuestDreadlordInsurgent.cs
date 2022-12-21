using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static MacroTools.Libraries.GeneralHelpers;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestDreadlordInsurgent : QuestData
  {
    public QuestDreadlordInsurgent() : base("Dreadlord Insurgent",
      "Varimathras has branched out and tried to take control of the Plaguelands, Sylvanas will try and make him join her cause.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroDreadLord.blp")
    {
      AddObjective(new ObjectiveResearch(FourCC("R08H"), FourCC("n040")));
    }


    protected override string CompletionPopup =>
      "The Dreadlord has quickly fallen to Sylvanas and forced to join the Forsaken ";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with a small army, Varimathras and Lilian Voss near Capital City";

    protected override void OnComplete(Faction completingFaction)
    {
      LegionSetup.Legion.ModObjectLimit(FourCC("Utic"), -Faction.UNLIMITED); //Tichondrius
      LegionSetup.Legion.ModObjectLimit(FourCC("Umal"), -Faction.UNLIMITED); //maglanis
      LegionSetup.Legion.ModObjectLimit(FourCC("U00L"), -Faction.UNLIMITED); //Anatheron

      LegionSetup.Legion.ModObjectLimit(FourCC("E01O"), 1); //Lilian
      LegionSetup.Legion.ModObjectLimit(FourCC("Uvar"), 1); //Vari

      completingFaction.Player?.SetTeam(TeamSetup.Forsaken);
      completingFaction.Name = "|cff8080ffInsurgents|r";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNHeroDreadLord.blp";
      SetPlayerColor(completingFaction.Player, PLAYER_COLOR_LIGHT_BLUE);

      LegendForsaken.Varimathras.StartingXp = GetHeroXP(LegendLegion.LEGEND_TICHONDRIUS.Unit);
      LegendLegion.LEGEND_LILIAN.StartingXp = GetHeroXP(LegendLegion.LEGEND_MALGANIS.Unit);
      completingFaction.Obliterate();
      LegendLegion.LEGEND_LILIAN.ForceCreate(completingFaction.Player, new Point(7254, 7833), 110);
      LegendForsaken.Varimathras.ForceCreate(completingFaction.Player, new Point(7254, 7833), 110);
      CreateUnits(completingFaction.Player, FourCC("n04J"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 12);
      CreateUnits(completingFaction.Player, FourCC("u00D"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 6);
      CreateUnits(completingFaction.Player, FourCC("ninc"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 12);
      CreateUnits(completingFaction.Player, FourCC("u007"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 2);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 900);
      if (GetLocalPlayer() == completingFaction.Player)
        SetCameraPosition(Regions.Vandermar_Village.Center.X,
          Regions.Vandermar_Village.Center.Y);
    }
  }
}