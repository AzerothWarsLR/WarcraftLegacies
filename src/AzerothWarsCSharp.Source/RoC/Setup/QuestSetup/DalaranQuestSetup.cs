public class DalaranQuestSetup{

  public static void OnInit( ){
    QuestNewGuardian newGuardian = QuestNewGuardian.create();
    QuestTheNexus theNexus = QuestTheNexus.create();
    QuestCrystalGolem crystalGolem = QuestCrystalGolem.create();
    QuestFallenGuardian fallenGuardian = QuestFallenGuardian.create();
    QuestSouthshore questSouthshore = QuestSouthshore.create();

    newGuardian.AddQuestItem(QuestItemDontCompleteQuest.create(theNexus));
    crystalGolem.AddQuestItem(QuestItemDontCompleteQuest.create(theNexus));
    fallenGuardian.AddQuestItem(QuestItemDontCompleteQuest.create(theNexus));
    theNexus.AddQuestItem(QuestItemDontCompleteQuest.create(newGuardian));

    //Early duel
    FACTION_DALARAN.AddQuest(questSouthshore);
    FACTION_DALARAN.StartingQuest = questSouthshore;
    FACTION_DALARAN.AddQuest(QuestShadowfang.create());
    FACTION_DALARAN.AddQuest(QuestDalaran.create());
    FACTION_DALARAN.AddQuest(QuestJainaSoulGem.create());
    FACTION_DALARAN.AddQuest(QuestBlueDragons.create());
    //Misc
    FACTION_DALARAN.AddQuest(QuestKarazhan.create());
    FACTION_DALARAN.AddQuest(QuestTheramore.create());

    FACTION_DALARAN.AddQuest(crystalGolem);
    FACTION_DALARAN.AddQuest(fallenGuardian);
    FACTION_DALARAN.AddQuest(newGuardian);
    FACTION_DALARAN.AddQuest(theNexus);
  }

}
