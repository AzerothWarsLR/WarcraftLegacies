library IncompatibleTierConfig initializer OnInit

  private function OnInit takes nothing returns nothing
    local IncompatibleResearchSet researchSet = 0
                                
    //Fel Horde Tier 1
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R02L')    //Shattered Hand Clan
    call researchSet.add('R03L')    //Shadow Council Reformed  
        
    //Fel Horde Tier 2
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R036')    //Dragonmaw Clan
    call researchSet.add('R047')    //Shadowmoon Clan Remnants

                    
    //Stormwind Tier 1 (Champion Hall)
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R02Y')    //Battle Tactics
    call researchSet.add('R03D')    //Veteran Guard
        
    //Stormwind Tier 1 (Wizard's Sanctum)
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R03T')    //Electric Strike Ritual
    call researchSet.add('R03U')    //Solar Flare Ritual
        
    //Stormwind Tier 2 ( Champion Hall)
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R03B')    //Exploit Weakness
    call researchSet.add('R02Z')    //Reflective Plating
        
    //Stormwind Tier 2 (Wizard's Sanctum)
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R03V')    //Stomrgrade
    call researchSet.add('R03W')    //Knowledge of Honor Hold
        
    //Stormwind Tier 3 (hampion Hall)
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R030')    //Code of Chivalry
    call researchSet.add('R031')    //Expedition Survivors
        
    //Stormwind Tier 3 (Wizard's Sanctum & Cathedral of Light)
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R03P')    //Archbishop Benedictus Aid
    call researchSet.add('R03X')    //High Sorcerer Andromath Aid
    call researchSet.add('R03Y')    //Katrana Prestor Aid
    call researchSet.add('R03R')    //Reginald Windsor Aid

    //Naga Path
    set researchSet = IncompatibleResearchSet.create()
    call researchSet.add('R062')   //Redemption path
    call researchSet.add('R063')   //Exile Path
    call researchSet.add('R065')   //Madness Path
  endfunction    
    
endlibrary
