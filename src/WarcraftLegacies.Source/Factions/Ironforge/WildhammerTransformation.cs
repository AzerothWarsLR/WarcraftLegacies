using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Turns Ironforge into the Wildhammer, keeping Aerie Peak, the Hinterlands and Thelsamar and handing its other buildings to an heir.</summary>
public sealed class WildhammerTransformation
{
  private static readonly Point _aeriePeak = new(14176, 4640);
  private const float ProtectorSearchRadius = 900;
  private const float ClearRadius = 600;
  private static readonly Point _dunholde = new(13440, 3520);
  private static readonly Point[] _dunholdeTowers = { new(13211, 3575), new(13735, 3235) };
  private static readonly Point _dunholdeMysticDen = new(13356, 3797);
  private static readonly int[] _hinterlandsControlPoints = { UNIT_N018_DURNHOLDE, UNIT_N01A_HINTERLANDS, UNIT_N0EB_JINTHA_ALOR };
  private static readonly Rectangle _thelsamar = new(14400, -6800, 16300, -5000);

  /// <summary>Turns <paramref name="ironforge"/>'s player into the Wildhammer.</summary>
  public void Execute(Faction ironforge)
  {
    var whichPlayer = ironforge.Player;
    if (whichPlayer == null)
    {
      return;
    }

    IronforgeHomeland.ClaimHeldLands(ironforge, ironforge.GetQuestByType<QuestWildhammer>());
    var heir = IronforgeHomeland.GetHeir(whichPlayer, out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Aerie_Peak, Regions.HinterlandAmbient1,
      Regions.HinterlandAmbient2, _thelsamar);
    var magniExperience = GetExperience(AllLegends.Ironforge.Magni);
    var muradinExperience = GetExperience(AllLegends.Ironforge.Muradin);
    var wildhammer = new WildhammerFaction(ironforge);
    FactionTransition.AssignNewFaction(ironforge, wildhammer);
    CarryOverResearches(wildhammer, whichPlayer);
    PathBase.RemoveHero(AllLegends.Ironforge.Magni);
    PathBase.RemoveHero(AllLegends.Ironforge.Muradin);
    PathBase.RemoveHero(AllLegends.Ironforge.Dagran);

    PathBase.ConvertStructures(whichPlayer, WildhammerFaction.UnitEquivalents);
    PathBase.ConvertArmy(whichPlayer, WildhammerFaction.UnitEquivalents);
    FortifyAeriePeak(whichPlayer);
    ClaimHinterlands(whichPlayer);
    PathBase.SummonLegend(AllLegends.Ironforge.Kurdran, whichPlayer, new Point(_aeriePeak.X, _aeriePeak.Y - 400));
    InheritExperience(AllLegends.Ironforge.Kurdran, magniExperience);
    if (muradinExperience > AllLegends.Ironforge.Talonaxe.StartingXp)
    {
      AllLegends.Ironforge.Talonaxe.StartingXp = muradinExperience;
    }

    SoarerCap.Start(whichPlayer, WildhammerFaction.SoarerLimit);
    whichPlayer.PlayMusicThematic(@"war3mapImported\DwarfTheme.mp3");
  }

  /// <summary>Gives the Wildhammer Dunholde, built up with towers and a Mystic Den, and the Hinterlands control points.</summary>
  private static void ClaimHinterlands(player whichPlayer)
  {
    ClearArea(whichPlayer, _dunholde.X, _dunholde.Y);
    foreach (var spot in _dunholdeTowers)
    {
      PathBase.CreateStructure(whichPlayer, UNIT_H0EU_GUARD_TOWER_WILDHAMMER, spot.X, spot.Y);
    }

    PathBase.CreateStructure(whichPlayer, UNIT_H0EQ_MYSTIC_DEN_WILDHAMMER, _dunholdeMysticDen.X, _dunholdeMysticDen.Y);

    foreach (var unitTypeId in _hinterlandsControlPoints)
    {
      var controlPoint = ControlPointManager.Instance.GetFromUnitType(unitTypeId).Unit;
      ClearArea(whichPlayer, controlPoint.X, controlPoint.Y);
      controlPoint.SetOwner(whichPlayer);
    }
  }

  /// <summary>Removes creeps near the point, and removes and refunds other players' structures there.</summary>
  private static void ClearArea(player whichPlayer, float x, float y)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsInRange(x, y, ClearRadius))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable() || whichUnit.Owner == whichPlayer)
      {
        continue;
      }

      var owner = whichUnit.Owner;
      var isStructure = whichUnit.IsUnitType(unittype.Structure);
      if (owner == player.NeutralAggressive && !isStructure)
      {
        whichUnit.DropAllItems();
        whichUnit.Dispose();
      }
      else if (isStructure && owner != player.NeutralPassive && owner != player.NeutralAggressive)
      {
        owner.Gold += whichUnit.GoldCost;
        whichUnit.Dispose();
      }
    }
  }

  /// <summary>Makes Aerie Peak a capital, with its improved cannon towers rebuilt as Aerie Protectors that guard it.</summary>
  private static void FortifyAeriePeak(player whichPlayer)
  {
    var aeriePeak = AllPreplacedWidgets.Units.Get(UNIT_H01U_AERIE_PEAK_IRONFORGE);
    if (aeriePeak == null || !aeriePeak.Alive || aeriePeak.Owner != whichPlayer)
    {
      return;
    }

    var capital = new Capital
    {
      Unit = aeriePeak,
      Capturable = true
    };
    CapitalManager.Register(capital);
    foreach (var tower in GlobalGroup.EnumUnitsInRange(aeriePeak.X, aeriePeak.Y, ProtectorSearchRadius))
    {
      if (!tower.Alive || tower.Owner != whichPlayer ||
          tower.UnitType != UNIT_H0EX_IMPROVED_CANNON_TOWER_WILDHAMMER)
      {
        continue;
      }

      var x = tower.X;
      var y = tower.Y;
      var facing = tower.Facing;
      tower.Dispose();
      var protector = unit.Create(whichPlayer, UNIT_H0FH_AERIE_PROTECTOR_WILDHAMMER, x, y, facing);
      if (protector != null)
      {
        capital.AddProtector(protector);
      }
    }
  }

  private static int GetExperience(LegendaryHero hero) => hero.Unit == null ? 0 : hero.Unit.Experience;

  private static void InheritExperience(LegendaryHero hero, int experience)
  {
    if (hero.Unit != null && experience > hero.Unit.Experience)
    {
      hero.Unit.SetExperience(experience, false);
    }
  }

  /// <summary>Gives the Wildhammer every level Ironforge had in a research they replace with their own.</summary>
  private static void CarryOverResearches(Faction wildhammer, player whichPlayer)
  {
    foreach (var pair in WildhammerFaction.ResearchEquivalents)
    {
      var level = whichPlayer.GetTechResearched(pair.Key, false);
      if (level > 0)
      {
        wildhammer.SetObjectLevel(pair.Value, level);
      }
    }
  }
}
