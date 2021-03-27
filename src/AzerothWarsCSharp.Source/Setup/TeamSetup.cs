using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class TeamSetup
  {
    public static Team SCOURGE { get; private set; }
    public static Team NORTHALLIANCE { get; private set; }
    public static Team HORDE { get; private set; }
    public static Team NIGHTELVES { get; private set; }
    public static Team SOUTHALLIANCE { get; private set; }
    public static Team FELHORDE { get; private set; }

    public static void Initialize()
    {
      SCOURGE = new Team("Scourge");
      NORTHALLIANCE = new Team("North Alliance");
      HORDE = new Team("Horde");
      NIGHTELVES = new Team("Night Elves");
      SOUTHALLIANCE = new Team("South Alliance");
      FELHORDE = new Team("Fel Horde");
    }
  }
}
