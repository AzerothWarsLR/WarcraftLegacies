using AzerothWarsCSharp.Source.Main.Libraries;

namespace AzerothWarsCSharp.Source.RoC.Setup
{
  public class InstanceSetup{

    public static void Setup( ){
      Instance tempInstance = 0;

      tempInstance = Instance.create();
      tempInstance.Name = "Barrow Deeps";
      tempInstance.addRect(gg_rct_InstanceBarrowDeeps);

      tempInstance = Instance.create();
      tempInstance.Name = "Twisting Nether";
      tempInstance.addRect(gg_rct_TwistingNether);

      tempInstance = Instance.create();
      tempInstance.Name = "Dire Maul";
      tempInstance.addRect(gg_rct_InstanceDireMaul);

      tempInstance = Instance.create();
      tempInstance.Name = "Scholomance";
      tempInstance.addRect(gg_rct_InstanceScholomance);

      tempInstance = Instance.create();
      tempInstance.Name = "Blackrock Depths";
      tempInstance.addRect(gg_rct_InstanceBlackrock);

      tempInstance = Instance.create();
      tempInstance.Name = "Tomb of Sargeras";
      tempInstance.addRect(gg_rct_InstanceSargerasTomb);

      tempInstance = Instance.create();
      tempInstance.Name = "AzjolFourCC(nerub";
      tempInstance.addRect(gg_rct_InstanceAzjolNerub);

      tempInstance = Instance.create();
      tempInstance.Name = "Outland";
      tempInstance.addRect(gg_rct_InstanceOutland);

      tempInstance = Instance.create();
      tempInstance.Name = "Outland";
      tempInstance.addRect(gg_rct_InstanceNazjatar);

      tempInstance = Instance.create();
      tempInstance.Name = "Dalaran Dungeons";
      tempInstance.addRect(gg_rct_InstanceDalaranDungeon1);
      tempInstance.addRect(gg_rct_InstanceDalaranDungeon2);
      tempInstance.addRect(gg_rct_InstanceDalaranDungeon3);
    }

  }
}
