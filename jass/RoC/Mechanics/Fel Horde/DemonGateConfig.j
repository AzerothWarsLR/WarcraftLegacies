library DemonGateConfig initializer OnInit requires DemonGate

  //DemonGateType parameters are: gate unit type, demon unit type, time between spawns
  //You must create DemonGateTypes before specifying which units are DemonGates

  private function OnInit takes nothing returns nothing
    call DemonGateType.create('n000', 'n059', 80,  2)  //T1 Hounds
    call DemonGateType.create('n04I', 'ndqn', 90,  1)  //T1 succ
    call DemonGateType.create('n05F', 'nvdl', 60,  1)  //T1 void

    call DemonGateType.create('n05I', 'n059', 80,  6)  //T2 Hounds
    call DemonGateType.create('n05R', 'n05B', 85,  2)  //T2 felguard
    call DemonGateType.create('n06H', 'o015', 90,  1)  //T2 Pitfiend
 
    call DemonGateType.create('n05S', 'ndqn', 80,  3)  //T2 Succ
    call DemonGateType.create('n07B', 'ndqs', 120, 1)  //T2 Queen
    call DemonGateType.create('n07D', 'ndqp', 100, 1)  //T2 Maiden

    call DemonGateType.create('n06G', 'n08C', 80,  1)  //T2 Void
    call DemonGateType.create('n07M', 'n088', 130, 1)  //T2 Voidlord
    call DemonGateType.create('n07O', 'o014', 240, 1)  //T2 Void Hunter
  endfunction

endlibrary