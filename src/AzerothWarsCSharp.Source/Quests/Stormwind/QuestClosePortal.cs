using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestClosePortal : QuestData
  {
    private readonly List<unit> _unitsToRemove;
    
    public QuestClosePortal() : base("Seal the Dark Portal",
      "The Dark Portal has been a menace to the Kingdom of Stormwind for decades, it is time to end the menace once and for all.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      AddObjective(new ObjectiveChannelRect(Regions.ClosePortal, "The Dark Portal", LegendStormwind.LegendKhadgar, 480, 270));
      Global = true;
      _unitsToRemove = new List<unit>
      {
        //Outside the portal
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(15579, -19546)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(16549, -19145)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(17447, -19214)),
        //Inside the portal
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(4576, -24718)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(4701, -25361)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(5212, -25743)),
        //Control Nexi
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(17420, -17900)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(3703, -26045))
      };
    }

    protected override string CompletionPopup => "Khadgar has closed the Dark Portal definately";

    protected override string RewardDescription => "Close the Dark Portal from both sides";

    protected override void OnFail(Faction completingFaction)
    {
      _unitsToRemove.Clear();
    }
    
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _unitsToRemove)
      {
        RemoveUnit(unit);
      }
      _unitsToRemove.Clear();
    }
  }
}