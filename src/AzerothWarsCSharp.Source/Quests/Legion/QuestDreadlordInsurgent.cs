using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;  using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestDreadlordInsurgent : QuestData
  {
    public QuestDreadlordInsurgent() : base("Dreadlord Insurgent",
      "Varimathras has branched out and tried to take control of the Plaguelands, Sylvanas will try and make him join her cause.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroDreadLord.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("R08H"), FourCC("n040")));
    }


    protected override string CompletionPopup =>
      "The Dreadlord has quickly fallen to Sylvanas and forced to join the Forsaken ";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with a small army, Varimathras and Lilian Voss near Capital City";

    protected override void OnComplete()
    {
      LegionSetup.FactionLegion.ModObjectLimit(FourCC("Utic"), -Faction.UNLIMITED); //Tichondrius
      LegionSetup.FactionLegion.ModObjectLimit(FourCC("Umal"), -Faction.UNLIMITED); //maglanis
      LegionSetup.FactionLegion.ModObjectLimit(FourCC("U00L"), -Faction.UNLIMITED); //Anatheron

      LegionSetup.FactionLegion.ModObjectLimit(FourCC("E01O"), 1); //Lilian
      LegionSetup.FactionLegion.ModObjectLimit(FourCC("Uvar"), 1); //Vari

      Holder.Team = TeamSetup.Forsaken;
      Holder.Name = "|cff8080ffInsurgents|r";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNHeroDreadLord.blp";
      SetPlayerColor(Holder.Player, PLAYER_COLOR_LIGHT_BLUE);

      LegendForsaken.LegendVarimathras.StartingXp = GetHeroXP(LegendLegion.LEGEND_TICHONDRIUS.Unit);
      LegendLegion.LEGEND_LILIAN.StartingXp = GetHeroXP(LegendLegion.LEGEND_MALGANIS.Unit);
      Holder.Obliterate();
      LegendLegion.LEGEND_LILIAN.Spawn(Holder.Player, 7254, 7833, 110);
      LegendForsaken.LegendVarimathras.Spawn(Holder.Player, 7254, 7833, 110);
      CreateUnits(Holder.Player, FourCC("n04J"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 12);
      CreateUnits(Holder.Player, FourCC("u00D"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 6);
      CreateUnits(Holder.Player, FourCC("ninc"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 12);
      CreateUnits(Holder.Player, FourCC("u007"), Regions.Vandermar_Village.Center.X,
        Regions.Vandermar_Village.Center.Y, 270, 2);
      Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
      Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 900);
      if (GetLocalPlayer() == Holder.Player)
        SetCameraPosition(Regions.Vandermar_Village.Center.X,
          Regions.Vandermar_Village.Center.Y);
    }
  }
}