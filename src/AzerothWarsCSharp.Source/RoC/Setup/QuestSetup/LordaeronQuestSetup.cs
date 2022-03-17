public class LordaeronQuestSetup{

  public static void OnInit( ){
    //Early duel
    FACTION_LORDAERON.StartingQuest = FACTION_LORDAERON.AddQuest(QuestStratholme.create());
    FACTION_LORDAERON.AddQuest(QuestStrahnbrad.create());
    FACTION_LORDAERON.AddQuest(QuestCapitalCity.create());

    FACTION_LORDAERON.AddQuest(QuestShoresOfNorthrend.create());
    FACTION_LORDAERON.AddQuest(QuestThunderEagle.create());
    FACTION_LORDAERON.AddQuest(QuestKingArthas.create());
    FACTION_LORDAERON.AddQuest(QuestLivingShadow.create());
    FACTION_LORDAERON.AddQuest(QuestKingdomOfManLordaeron.create());
    FACTION_LORDAERON.AddQuest(QuestGarithosCrusade.create());
    FACTION_LORDAERON.AddQuest(QuestGarithosMindControl.create());

    THE_ASHBRINGER = QuestAshbringer.create();

  }

}
