public class IncompatibleTierConfig{

  private static void OnInit( ){
    IncompatibleResearchSet researchSet = 0;


    //Stormwind Tier 1 (Champion Hall)
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R02Y))    ;//Battle Tactics
    researchSet.add(FourCC(R03D))    ;//Veteran Guard

    //Stormwind Tier 1 (Wizard)s Sanctum)
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R03T))    ;//Electric Strike Ritual
    researchSet.add(FourCC(R03U))    ;//Solar Flare Ritual

    //Stormwind Tier 2 ( Champion Hall)
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R03B))    ;//Exploit Weakness
    researchSet.add(FourCC(R02Z))    ;//Reflective Plating

    //Stormwind Tier 2 (Wizard)s Sanctum)
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R03V))    ;//Stomrgrade
    researchSet.add(FourCC(R03W))    ;//Knowledge of Honor Hold

    //Stormwind Tier 3 (Champion Hall)
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R030))    ;//Code of Chivalry
    researchSet.add(FourCC(R031))    ;//Expedition Survivors

    //Stormwind Tier 3 (Wizard)s Sanctum & Cathedral of Light)
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R03X))    ;//High Sorcerer Andromath Aid
    researchSet.add(FourCC(R03Y))    ;//Katrana Prestor Aid

    //Naga Path
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R062))   ;//Redemption path
    researchSet.add(FourCC(R063))   ;//Exile Path
    researchSet.add(FourCC(R065))   ;//Madness Path

    //Scarlet Path
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R088))   ;//Argent Dawn
    researchSet.add(FourCC(R03P))   ;//Unleash the Crusade

    //Lordaeron Path
    researchSet = IncompatibleResearchSet.create();
    researchSet.add(FourCC(R08F))   ;//Mind Control
    researchSet.add(FourCC(R08E))   ;//Join Crusade

  }

}
