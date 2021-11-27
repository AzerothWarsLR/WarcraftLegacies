library InstanceSetup requires Instance

  public function OnInit takes nothing returns nothing
    local Instance tempInstance = 0

    set tempInstance = Instance.create()
    set tempInstance.Name = "Barrow Deeps"
    call tempInstance.addRect(gg_rct_InstanceBarrowDeeps)

    set tempInstance = Instance.create()
    set tempInstance.Name = "Twisting Nether"
    call tempInstance.addRect(gg_rct_TwistingNether)    

    set tempInstance = Instance.create()
    set tempInstance.Name = "Dire Maul"
    call tempInstance.addRect(gg_rct_InstanceDireMaul)      

    set tempInstance = Instance.create()
    set tempInstance.Name = "Scholomance"
    call tempInstance.addRect(gg_rct_InstanceScholomance)         

    set tempInstance = Instance.create()
    set tempInstance.Name = "Blackrock Depths"
    call tempInstance.addRect(gg_rct_InstanceBlackrock)  

    set tempInstance = Instance.create()
    set tempInstance.Name = "Tomb of Sargeras"
    call tempInstance.addRect(gg_rct_InstanceSargerasTomb)          

    set tempInstance = Instance.create()
    set tempInstance.Name = "Azjol'nerub"
    call tempInstance.addRect(gg_rct_InstanceAzjolNerub)

    set tempInstance = Instance.create()
    set tempInstance.Name = "Outland"
    call tempInstance.addRect(gg_rct_InstanceOutland)      

    set tempInstance = Instance.create()
    set tempInstance.Name = "Outland"
    call tempInstance.addRect(gg_rct_InstanceNazjatar)      

    set tempInstance = Instance.create()
    set tempInstance.Name = "Dalaran Dungeons"
    call tempInstance.addRect(gg_rct_InstanceDalaranDungeon1)     
    call tempInstance.addRect(gg_rct_InstanceDalaranDungeon2)   
    call tempInstance.addRect(gg_rct_InstanceDalaranDungeon3)                                                                                       
  endfunction

endlibrary