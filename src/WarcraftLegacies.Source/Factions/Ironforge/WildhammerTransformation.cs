using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Turns Ironforge into the Wildhammer, holding Aerie Peak and the Hinterlands and leaving Khaz Modan to the Alliance.</summary>
public sealed class WildhammerTransformation
{
  private static readonly Point _aeriePeak = new(14176, 4640);

  private static readonly Dictionary<int, int> _noEquivalents = new();

  /// <summary>Turns <paramref name="ironforge"/>'s player into the Wildhammer.</summary>
  public void Execute(Faction ironforge)
  {
    var whichPlayer = ironforge.Player;
    if (whichPlayer == null)
    {
      return;
    }

    IronforgeHomeland.ClaimHeldLands(ironforge, ironforge.GetQuestByType<QuestWildhammer>());
    FactionTransition.AssignNewFaction(ironforge, new WildhammerFaction(ironforge));
    PathBase.RemoveHero(AllLegends.Ironforge.Magni);
    PathBase.RemoveHero(AllLegends.Ironforge.Muradin);

    var heir = IronforgeHomeland.GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.HinterlandAmbient1, Regions.HinterlandAmbient2);

    PathBase.RelocateArmy(whichPlayer, _noEquivalents, _aeriePeak.X, _aeriePeak.Y - 600);
    PathBase.SummonLegend(AllLegends.Ironforge.Kurdran, whichPlayer, new Point(_aeriePeak.X, _aeriePeak.Y - 400));
    whichPlayer.PlayMusicThematic(@"war3mapImported\DwarfTheme.mp3");
  }
}
