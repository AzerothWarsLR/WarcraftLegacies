using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using AzerothWarsCSharp.Source.Mechanics.TwilightHammer;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup
{
  public static class BlackEmpireSetup
  {
    public static Faction BlackEmpire { get; private set; }

    public static void Setup()
    {
      BlackEmpire = new Faction("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080",
        "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        Team = TeamSetup.TeamAlliance
      };
      BlackEmpire.ModObjectLimit(FourCC("hfoo"), 5);

      var power = new DummyPower("Waygates",
        "Allows you to construct 2 Waygates, which enable teleportation between them.",
        "Waygate");
      BlackEmpire.AddPower(power);

      var visionPower = new VisionPower("All-Seeing",
        "Grants permanent vision over Northrend.",
        "Charm", new[]
        {
          new Rectangle(100, 100, 0, 0),
          new Rectangle(-100, -100, 0, 0),
          new Rectangle(-813, -183, -460, 183)
        });
      BlackEmpire.AddPower(visionPower);

      var corruptWorkerPower = new PowerCorruptWorker(new[]
      {
        new Continent("Northern Eastern Kingdoms", Rectangle.WorldBounds)
      }, 1);
      BlackEmpire.AddPower(corruptWorkerPower);

      FactionManager.Register(BlackEmpire);
    }
  }
}