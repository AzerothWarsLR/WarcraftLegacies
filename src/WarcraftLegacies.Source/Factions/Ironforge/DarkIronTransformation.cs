using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Turns Ironforge into the Dark Iron, holding Shadowforge City and Grim Batol and leaving Khaz Modan to the Alliance.</summary>
public sealed class DarkIronTransformation
{
  private const float GrimBatolGroundsRadius = 2500;

  private static readonly Rectangle _shadowforge = new(11264, -10112, 13312, -8320);

  private static readonly HashSet<int> _grimBatolBuildings = new()
  {
    UNIT_H01Z_GRIM_BATOL_CREEP_TWILIGHT,
    UNIT_O067_DUNGEON_CREEP_BARRACKS,
    UNIT_O068_QUARRY_CREEP_RESEARCH,
    UNIT_O069_DARK_CONCLAVE_CREEP_MAGIC
  };

  /// <summary>Turns <paramref name="ironforge"/>'s player into the Dark Iron.</summary>
  public void Execute(Faction ironforge)
  {
    var whichPlayer = ironforge.Player;
    if (whichPlayer == null)
    {
      return;
    }

    IronforgeHomeland.ClaimHeldLands(ironforge, ironforge.GetQuestByType<QuestDarkIron>());
    var darkIron = new DarkIronFaction(ironforge);
    FactionTransition.AssignNewFaction(ironforge, darkIron);
    PathBase.RemoveHero(AllLegends.Ironforge.Magni);
    PathBase.RemoveHero(AllLegends.Ironforge.Muradin);
    PathBase.RemoveHero(AllLegends.Ironforge.Falstad);

    var heir = IronforgeHomeland.GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, _shadowforge, Regions.Grim_Batol);
    ClaimGrimBatol(whichPlayer);
    PathBase.ConvertStructures(whichPlayer, DarkIronFaction.UnitEquivalents, _shadowforge);
    PathBase.ConvertStructures(whichPlayer, DarkIronFaction.UnitEquivalents, Regions.Grim_Batol);

    var shadowforgeCity = new Point(11648, -9232);
    PathBase.RelocateArmy(whichPlayer, DarkIronFaction.UnitEquivalents, shadowforgeCity.X + 600, shadowforgeCity.Y - 600);
    PathBase.SummonLegend(AllLegends.Ironforge.Dagran, whichPlayer, new Point(shadowforgeCity.X + 400, shadowforgeCity.Y - 400));
    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\Tension.mp3");
  }

  /// <summary>Takes Grim Batol and the buildings around it from whichever creeps hold them, unless a faction already does.</summary>
  private static void ClaimGrimBatol(player whichPlayer)
  {
    var grimBatol = AllLegends.Neutral.GrimBatol.Unit;
    if (grimBatol == null)
    {
      return;
    }

    foreach (var whichUnit in GlobalGroup.EnumUnitsInRange(grimBatol.X, grimBatol.Y, GrimBatolGroundsRadius))
    {
      if (whichUnit.Alive && _grimBatolBuildings.Contains(whichUnit.UnitType) && whichUnit.Owner.GetPlayerData().Faction == null)
      {
        whichUnit.SetOwner(whichPlayer);
      }
    }

    PathBase.ClaimArea(Regions.Grim_Batol, whichPlayer);
  }
}
