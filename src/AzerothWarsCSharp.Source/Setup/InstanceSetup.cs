using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class InstanceSetup
  {
    public static void Setup()
    {
      InstanceSystem.Register(
        new Instance
        {
          Name = "Barrow Deeps",
          Rectangles = {Regions.InstanceBarrowDeeps}
        }
      );
      
      InstanceSystem.Register(
        new Instance
        {
          Name = "Twisting Nether",
          Rectangles = {Regions.TwistingNether}
        }
      );
      
      InstanceSystem.Register(
        new Instance
        {
          Name = "Dire Maul",
          Rectangles = {Regions.InstanceDireMaul}
        }
      );

      InstanceSystem.Register(
        new Instance
        {
          Name = "Scholomance",
          Rectangles = {Regions.InstanceScholomance}
        }
      );

      InstanceSystem.Register(
        new Instance
        {
          Name = "Blackrock Depths",
          Rectangles = {Regions.InstanceBlackrock}
        }
      );
      
      InstanceSystem.Register(
        new Instance
        {
          Name = "Tomb of Sargeras",
          Rectangles = {Regions.InstanceSargerasTomb}
        }
      );
      
      InstanceSystem.Register(
        new Instance
        {
          Name = "Azjol'nerub",
          Rectangles = {Regions.InstanceAzjolNerub}
        }
      );
      
      InstanceSystem.Register(
        new Instance
        {
          Name = "Outland",
          Rectangles = {Regions.InstanceOutland}
        }
      );
      
      InstanceSystem.Register(
        new Instance
        {
          Name = "Nazjatar",
          Rectangles = {Regions.InstanceNazjatar}
        }
      );
      
      InstanceSystem.Register(
        new Instance
        {
          Name = "Dalaran Dungeons",
          Rectangles =
          {
            Regions.InstanceDalaranDungeon1,
            Regions.InstanceDalaranDungeon2,
            Regions.InstanceDalaranDungeon3
          }
        }
      );
    }
  }
}