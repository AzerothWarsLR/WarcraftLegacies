namespace AzerothWarsCSharp.Source.RoC.Mechanics.Fel_Horde
{
  public class DemonGateConfig{

    //DemonGateType parameters are: gate unit type, demon unit type, time between spawns
    //You must create DemonGateTypes before specifying which units are DemonGates

    public static void Setup( ){
      DemonGateType.create(FourCC(n000), )n059), 80,  2)  ;//T1 Hounds
      DemonGateType.create(FourCC(n04I), )ndqn), 90,  1)  ;//T1 succ
      DemonGateType.create(FourCC(n05F), )nvdl), 60,  1)  ;//T1 void

      DemonGateType.create(FourCC(n05I), )n059), 80,  6)  ;//T2 Hounds
      DemonGateType.create(FourCC(n05R), )n05B), 85,  2)  ;//T2 felguard
      DemonGateType.create(FourCC(n06H), )o015), 90,  1)  ;//T2 Pitfiend

      DemonGateType.create(FourCC(n05S), )ndqn), 80,  3)  ;//T2 Succ
      DemonGateType.create(FourCC(n07B), )ndqs), 120, 1)  ;//T2 Queen
      DemonGateType.create(FourCC(n07D), )ndqp), 100, 1)  ;//T2 Maiden

      DemonGateType.create(FourCC(n06G), )n08C), 80,  1)  ;//T2 Void
      DemonGateType.create(FourCC(n07M), )n088), 130, 1)  ;//T2 Voidlord
      DemonGateType.create(FourCC(n07O), )o014), 240, 1)  ;//T2 Void Hunter
    }

  }
}
