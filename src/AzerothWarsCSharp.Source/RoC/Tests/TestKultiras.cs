public class TestKultiras{


    void Run( ){
      Person.ById(0).Faction = FACTION_KULTIRAS;
      CreateUnits(Player(0), FourCC(h01E), 10683, -28680, 270, 5);
    }

    private static void onInit( ){
      thistype.create("kulFourCC(tiras");
    }


}
