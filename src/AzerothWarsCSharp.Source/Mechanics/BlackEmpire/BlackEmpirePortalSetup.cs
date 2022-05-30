namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public static class BlackEmpirePortalSetup
  {
    public static BlackEmpirePortal TwilightHighlandsPortal;
    public static BlackEmpirePortal NorthrendPortal;
    public static BlackEmpirePortal TanarisPortal;
    public static BlackEmpirePortal IllidanPortal;

    public static void Setup()
    {
      TwilightHighlandsPortal = new BlackEmpirePortal();
      NorthrendPortal = new BlackEmpirePortal();
      TanarisPortal = new BlackEmpirePortal();
      IllidanPortal = new BlackEmpirePortal();
    }
  }
}