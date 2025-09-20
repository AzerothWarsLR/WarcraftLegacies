using MacroTools.ShoreSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

public static class ShoreSetup
{
  public static void Setup()
  {
    ShoreManager.Register(new Shore(new Point(-19986, 12602), "Darnassus"));
    ShoreManager.Register(new Shore(new Point(-20649, 9363), "Azuremyst Isle"));
    ShoreManager.Register(new Shore(new Point(-17053, 10271), "Darkshore"));
    ShoreManager.Register(new Shore(new Point(-20476, -2136), "Ranazjar Isle"));
    ShoreManager.Register(new Shore(new Point(-20312, -4681), "Desolace"));
    ShoreManager.Register(new Shore(new Point(-20970, -8588), "Feathermoon Stronghold"));
    ShoreManager.Register(new Shore(new Point(-22103, -11113), "Isle of Dread"));
    ShoreManager.Register(new Shore(new Point(-11948, -17813), "Uldum"));
    ShoreManager.Register(new Shore(new Point(-7563, -13900), "Gadgetzan"));
    ShoreManager.Register(new Shore(new Point(-6778, -9465), "Theramore"));
    ShoreManager.Register(new Shore(new Point(-10440, -5025), "Grom shipwreck"));
    ShoreManager.Register(new Shore(new Point(-7308, -5339), "Echo Isles"));
    ShoreManager.Register(new Shore(new Point(-8139, -2722), "Durotar"));
    ShoreManager.Register(new Shore(new Point(-7733, 3702), "Azshara Coast"));
    ShoreManager.Register(new Shore(new Point(-18333, 5412), "South of Darkshore"));
    ShoreManager.Register(new Shore(new Point(-19415, -12319), "Silithus"));

    ShoreManager.Register(new Shore(new Point(-5335, -7333), "Alcaz Isle"));
    ShoreManager.Register(new Shore(new Point(307, -1955), "Maelstrom"));
    ShoreManager.Register(new Shore(new Point(-2884, 3990), "Broken Isles left"));
    ShoreManager.Register(new Shore(new Point(3425, 5504), "Broken Isles right"));
    ShoreManager.Register(new Shore(new Point(2398, 9324), "Broken Isles top right"));
    ShoreManager.Register(new Shore(new Point(-4909, -16591), "Zuldazar"));
    ShoreManager.Register(new Shore(new Point(5593, -12891), "Balor"));
    ShoreManager.Register(new Shore(new Point(-2502, -7759), "Kezan"));
    ShoreManager.Register(new Shore(new Point(5727, -8037), "Boralus"));
    ShoreManager.Register(new Shore(new Point(-4949, -11987), "Vol'dun"));
    ShoreManager.Register(new Shore(new Point(1288, -6019), "Stormsong Valley"));

    ShoreManager.Register(new Shore(new Point(-5307, 16156), "Borean Tundra"));
    ShoreManager.Register(new Shore(new Point(-1091, 15953), "Dragonblight"));
    ShoreManager.Register(new Shore(new Point(3687, 15945), "Howling Fjords"));
    ShoreManager.Register(new Shore(new Point(7538, 15325), "Grizzly Hills"));

    ShoreManager.Register(new Shore(new Point(16258, 19241), "Left Quel))thelas"));
    ShoreManager.Register(new Shore(new Point(20701, 16789), "Right Quel"));
    ShoreManager.Register(new Shore(new Point(21355, 9796), "Havenshire"));
    ShoreManager.Register(new Shore(new Point(18921, 4343), "Jintha))Alor"));
    ShoreManager.Register(new Shore(new Point(21997, -6167), "Twilight Highlands"));
    ShoreManager.Register(new Shore(new Point(19280, -11819), "Southern Badlands"));
    ShoreManager.Register(new Shore(new Point(19038, -15584), "Swamp of Sorrows"));
    ShoreManager.Register(new Shore(new Point(18872, -19430), "Blasted Lands"));
    ShoreManager.Register(new Shore(new Point(10307, -22825), "Booty Bay"));
    ShoreManager.Register(new Shore(new Point(10118, -21389), "Stranglethorn"));
    ShoreManager.Register(new Shore(new Point(9598, -19192), "Western Stranglethorn"));
    ShoreManager.Register(new Shore(new Point(6680, -17200), "Westfall"));
    ShoreManager.Register(new Shore(new Point(7892, -9781), "Stormwind"));
    ShoreManager.Register(new Shore(new Point(11843, -3206), "Menethil Harbour"));
    ShoreManager.Register(new Shore(new Point(11295, -1766), "Tol Barad"));
    ShoreManager.Register(new Shore(new Point(5209, -1888), "Duskhaven"));
    ShoreManager.Register(new Shore(new Point(5764, 923), "Keel Harbor"));
    ShoreManager.Register(new Shore(new Point(6956, -2476), "South part of Gilneas"));
    ShoreManager.Register(new Shore(new Point(5749, 3544), "Silverpine Forest"));
    ShoreManager.Register(new Shore(new Point(5539, 6961), "West of Lordaeron City"));
    ShoreManager.Register(new Shore(new Point(6472, 10593), "Tirisfal Glades"));
    ShoreManager.Register(new Shore(new Point(9505, 11727), "North of Lordaeron City"));
    ShoreManager.Register(new Shore(new Point(14204, 13242), "Stratholme"));
  }
}
