using AzerothWarsCSharp.Launcher.ObjectFactory.Units;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Kultiras
  {
    public static void Setup()
    {
      new Worker(UnitType.Peasant, "ksum")
      {
        TextName = "Deckhand",
        ArtModelFile = @"MageKulTirasV1.01.mdl",
        ArtIconGameInterface = @"ReplaceableTextures\CommandButtons\BTNEmissary.blp"
      };
    }
  }
}