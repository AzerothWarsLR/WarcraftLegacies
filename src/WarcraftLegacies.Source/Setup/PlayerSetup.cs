using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Factions;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  public sealed class PlayerSetup
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    public PlayerSetup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup)
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
    }
    
    public void Setup()
    {
      Player(1).SetFaction(StormwindSetup.Stormwind);
      Player(1).SetTeam(TeamSetup.SouthAlliance);
      
      SetupFrostwolf(Player(0));
      SetupQuelthalas(Player(2));
      SetupScourge(Player(3));

      Player(4).SetFaction(IronforgeSetup.Ironforge);
      Player(4).SetTeam(TeamSetup.SouthAlliance);

      Player(5).SetFaction(WarsongSetup.WarsongClan);
      Player(5).SetTeam(TeamSetup.Horde);

      Player(6).SetFaction(FelHordeSetup.FelHorde);
      Player(6).SetTeam(TeamSetup.Outland);

      Player(7).SetTeam(TeamSetup.NorthAlliance);
      
      Player(8).SetTeam(TeamSetup.Horde);

      SetupLordaeron(Player(9));
      
      Player(11).SetFaction(DruidsSetup.Druids);
      Player(11).SetTeam(TeamSetup.NightElves);

      Player(13).SetFaction(DraeneiSetup.Draenei);
      Player(13).SetTeam(TeamSetup.NightElves);

      Player(18).SetFaction(SentinelsSetup.Sentinels);
      Player(18).SetTeam(TeamSetup.NightElves);
      
      Player(15).SetTeam(TeamSetup.Outland);

      SetupKultiras(Player(22));
      SetupLegion(Player(23));
    }

    private void SetupFrostwolf(player whichPlayer)
    {
      var frostwolf = FactionManager.Register(new Frostwolf(_preplacedUnitSystem, _allLegendSetup, _artifactSetup));
      whichPlayer.SetFaction(frostwolf);
      whichPlayer.SetTeam(TeamSetup.Horde);
    }
    
    private void SetupQuelthalas(player whichPlayer)
    {
      var quelthalas = FactionManager.Register(new Quelthalas(_preplacedUnitSystem, _allLegendSetup));
      whichPlayer.SetFaction(quelthalas);
      whichPlayer.SetTeam(TeamSetup.NorthAlliance);
    }
    
    private void SetupScourge(player whichPlayer)
    {
      var scourge = FactionManager.Register(new Scourge(_preplacedUnitSystem, _allLegendSetup, _artifactSetup));
      whichPlayer.SetFaction(scourge);
      whichPlayer.SetTeam(TeamSetup.Legion);
    }
    
    private void SetupLordaeron(player whichPlayer)
    {
      var lordaeron = FactionManager.Register(new Lordaeron(_preplacedUnitSystem, _allLegendSetup, _artifactSetup));
      whichPlayer.SetFaction(lordaeron);
      whichPlayer.SetTeam(TeamSetup.NorthAlliance);
    }
    
    private void SetupKultiras(player whichPlayer)
    {
      var kultiras = FactionManager.Register(new Kultiras(_preplacedUnitSystem, _allLegendSetup));
      whichPlayer.SetFaction(kultiras);
      whichPlayer.SetTeam(TeamSetup.SouthAlliance);
    }
    
    private void SetupLegion(player whichPlayer)
    {
      var legion = FactionManager.Register(new Legion(_preplacedUnitSystem, _allLegendSetup));
      whichPlayer.SetFaction(legion);
      whichPlayer.SetTeam(TeamSetup.Legion);
    }
  }
}