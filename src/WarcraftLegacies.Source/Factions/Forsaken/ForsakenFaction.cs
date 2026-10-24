using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Forsaken.Researches;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>Sylvanas and the undead who broke free of the Lich King, reached through the Rise of the Forsaken path.</summary>
public sealed class ForsakenFaction : Faction
{
  private const int DarkRangersCost = 200;

  /// <inheritdoc />
  public ForsakenFaction() : base("Forsaken", playercolor.Cyan,
    @"ReplaceableTextures\CommandButtons\BTNBansheeRanger.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    NameTakesArticle = true;
    ControlPointDefenderUnitTypeId = UNIT_U028_CONTROL_POINT_DEFENDER_SCOURGE;
    StartingGold = new StartingGold
    {
      Instant = 0,
      Income = 0,
      Turns = 0
    };
    Nicknames = new List<string>
    {
      "forsaken",
      "fsk"
    };
    ProcessObjectInfo(ForsakenObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    ForsakenSpells.Setup();
    ResearchManager.Register(new DarkRangers(UPGRADE_R108_DARK_RANGERS_FORSAKEN, DarkRangersCost));
    RegisterFactionDependentInitializer<GilneasFaction>(RegisterGilneasQuest);
  }

  private void RegisterGilneasQuest(GilneasFaction gilneas)
  {
    if (!gilneas.FormedMidGame)
    {
      return;
    }

    var plagueOfGilneas = AddQuest(new QuestPlagueOfGilneas(AllLegends.Gilneas.GilneasCastle));
    this.DisplayDiscovered(plagueOfGilneas, false);
  }
}
