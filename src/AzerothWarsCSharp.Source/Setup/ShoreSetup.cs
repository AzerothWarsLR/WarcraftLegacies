using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ShoreSystem;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class ShoreSetup
  {
    public static void Setup()
    {
      ShoreSystem.Register(new Shore(-19986, 12602)); //Darnassus
      ShoreSystem.Register(new Shore(-20649, 9363)); //Azuremyst Isle
      ShoreSystem.Register(new Shore(-17053, 10271)); //Darkshore
      ShoreSystem.Register(new Shore(-20550, -1933)); //Ranazjar Isle
      ShoreSystem.Register(new Shore(-20312, -4681)); //Desolace
      ShoreSystem.Register(new Shore(-20970, -8588)); //Feathermoon Stronghold
      ShoreSystem.Register(new Shore(-20307, -12244)); //Isle of Dread
      ShoreSystem.Register(new Shore(-14197, -17303)); //Weird little Stormreaver cove on the bottom of Kalimdor
      ShoreSystem.Register(new Shore(-835, -17536)); //Weird little pirate cove on the bottom of Kalimdor
      ShoreSystem.Register(new Shore(-7563, -13900)); //Gadgetzan
      ShoreSystem.Register(new Shore(-6778, -9465)); //Theramore
      ShoreSystem.Register(new Shore(-10440, -5025)); //Grom shipwreck
      ShoreSystem.Register(new Shore(-7308, -5339)); //Echo Isles
      ShoreSystem.Register(new Shore(-8139, -2722)); //Durotar
      ShoreSystem.Register(new Shore(-7687, 2871)); //Azshara Coast

      ShoreSystem.Register(new Shore(-5498, -6755)); //Alcaz Isle
      ShoreSystem.Register(new Shore(-2967, -2288)); //Darkspear Isles
      ShoreSystem.Register(new Shore(376, 1702)); //Maelstrom
      ShoreSystem.Register(new Shore(-376, 7121)); //Broken Isles
      ShoreSystem.Register(new Shore(-248, -15881)); //Zandalar
      ShoreSystem.Register(new Shore(5593, -12891)); //Balor
      ShoreSystem.Register(new Shore(3629, -6392)); //Boralus

      ShoreSystem.Register(new Shore(-4835, 15958)); //Borean Tundra
      ShoreSystem.Register(new Shore(-598, 16970)); //Dragonblight
      ShoreSystem.Register(new Shore(4646, 15760)); //Howling Fjords
      ShoreSystem.Register(new Shore(5822, 1841)); //Grizzly Hills
      ShoreSystem.Register(new Shore(-4605, 22493)); //Icecrown

      ShoreSystem.Register(new Shore(16258, 19241)); //Left Quel))thelas
      ShoreSystem.Register(new Shore(20701, 16789)); //Right Quel
      ShoreSystem.Register(new Shore(22472, 12947)); //Zul))aman
      ShoreSystem.Register(new Shore(21355, 9796)); //Havenshire
      ShoreSystem.Register(new Shore(18921, 4343)); //Jintha))Alor
      ShoreSystem.Register(new Shore(19640, -3945)); //Twilight Highlands
      ShoreSystem.Register(new Shore(19280, -11819)); //Southern Badlands
      ShoreSystem.Register(new Shore(18151, -15818)); //Swamp of Sorrows
      ShoreSystem.Register(new Shore(17446, -18699)); //Blasted Lands
      ShoreSystem.Register(new Shore(10307, -22825)); //Booty Bay
      ShoreSystem.Register(new Shore(10118, -21389)); //Stranglethorn
      ShoreSystem.Register(new Shore(9598, -19192)); //Western Stranglethorn
      ShoreSystem.Register(new Shore(6680, -17200)); //Westfall
      ShoreSystem.Register(new Shore(7892, -9781)); //Stormwind
      ShoreSystem.Register(new Shore(11843, -3206)); //Menethil Harbour
      ShoreSystem.Register(new Shore(11295, -1766)); //Tol Barad
      ShoreSystem.Register(new Shore(5209, -1888)); //Duskhaven
      ShoreSystem.Register(new Shore(5764, 923)); //Keel Harbor
      ShoreSystem.Register(new Shore(6956, -2476)); //South part of Gilneas
      ShoreSystem.Register(new Shore(5749, 3544)); //Silverpine Forest
      ShoreSystem.Register(new Shore(5539, 6961)); //West of Lordaeron City
      ShoreSystem.Register(new Shore(6472, 10593)); //Tirisfal Glades
      ShoreSystem.Register(new Shore(9505, 11727)); //North of Lordaeron City
      ShoreSystem.Register(new Shore(14204, 13242)); //Stratholme
    }
  }
}