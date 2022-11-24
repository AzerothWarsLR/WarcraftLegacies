using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

using static MacroTools.Libraries.GeneralHelpers;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  public sealed class QuestLiberateLordaeron : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestLiberateLordaeron(Rectangle rescueRect) : base("Liberation of Lordaeron",
      "The lands of Lordaeron are overrun by corruption. Everything must be purged!",
      "ReplaceableTextures\\CommandButtons\\BTNDwarvenFortress.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendScarlet.LegendBrigitte, false));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01F"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n03P"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01H"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01M"))));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R07P");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }


    protected override string CompletionPopup => "The lands of Lordaeron have been purged from Undeath and Corruption, the Scarlet can now expand North";

    protected override string RewardDescription =>
      "Unlock New Hearthglen in Northrend and the Scarlet Harbor";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      KillNeutralHostileUnitsInRadius(4152, 16521, 2300);
      KillNeutralHostileUnitsInRadius(-2190, 16803, 700);
      CreateStructureForced(completingFaction.Player, FourCC("h08J"), -5133152, 1667969, 4757993 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h086"), 1280, 16064, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h087"), -640, 16576, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h081"), -256, 16832, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h080"), 416, 16416, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("hpea"), 8187402, 1686473, 6156587 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("hpea"), 6240182, 1672541, 4578159 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h085"), -960, 15872, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("hdes"), 5826755, 1551292, 43173 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("hshy"), 800, 15776, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h07Z"), -512, 15744, 4712389 * MathEx.DegToRad, 512);
      CreateStructureForced(completingFaction.Player, FourCC("h06G"), 672, 16928, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h08I"), 7711509, 1606429, 06401012 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h085"), -448, 16128, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h085"), 704, 17152, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h088"), -1088, 16576, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h083"), -928, 16736, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h08I"), -1744257, 1663117, 3987584 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h08I"), -3887579, 1687145, 4113693 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h08I"), -5615654, 1652154, 602386 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("hdes"), 2519047, 1556937, 533097 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h097"), 800, 16288, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h085"), 1472, 16384, 4712389 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("h08L"), 8933604, 1617558, 4130178 * MathEx.DegToRad, 256);
      CreateStructureForced(completingFaction.Player, FourCC("no68"), -9312155, 1655475, 5458206 * MathEx.DegToRad, 256);
    }
  }
}