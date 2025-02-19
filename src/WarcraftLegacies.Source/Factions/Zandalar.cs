﻿using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Systems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Zandalar;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Zandalar : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public Zandalar(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup)
      : base("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c",
        @"ReplaceableTextures\CommandButtons\BTNHeadHunterBerserker.blp")
    {
      TraditionalTeam = TeamSetup.Horde;
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      StartingGold = 200;
      ControlPointDefenderUnitTypeId = UNIT_H0C1_CONTROL_POINT_DEFENDER_ZANDALAR;
      IntroText = @"You are playing as the mighty |cffe1946cZandalari Empire|r.

You start off at the southern coast of Tanaris, seperated from your allies. Raise an army and deal with the rogue Trolls in Zul'Farrak.

The Night Elves are mounting an assault on you and your allies from the North.

Join up with your allies and brace for a tough fight and counter-attack. ";

      GoldMines = new List<unit>
      {
        _preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-8900, -17000)), //Starting
        _preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-3500, -15000))  //Zandalar
      };
      Nicknames = new List<string>
      {
        "troll",
        "trolls"
      };
      ProcessObjectInfo(ZandalarObjectInfo.GetAllObjectLimits());
    }
        
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterQuests();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }
    
    /// <inheritdoc />
    public override void OnNotPicked()
    {
      Regions.ZandalarUnlock.CleanupNeutralPassiveUnits();
      Regions.Zandalari_Echo_Unlock.CleanupNeutralPassiveUnits();
      base.OnNotPicked();
    }

    private void RegisterQuests()
    {
      var questZulFarrak = new QuestZulfarrak(Regions.Zulfarrak, _allLegendSetup.Neutral.Zulfarrak, _allLegendSetup.Troll.Zul);
      StartingQuest = questZulFarrak;
      AddQuest(questZulFarrak);
      AddQuest(new QuestZandalar(Regions.ZandalarUnlock, _preplacedUnitSystem));
      AddQuest(new QuestGundrak(_allLegendSetup));
      AddQuest(new QuestJinthaAlor(_allLegendSetup));
      AddQuest(new QuestZulgurub(_allLegendSetup));
      AddQuest(new QuestHakkar(_artifactSetup.ZinRokh));
      AddQuest(new QuestZandalarOutpost());
      AddQuest(new QuestExtractSunwellVial(_allLegendSetup.Quelthalas.Sunwell, _artifactSetup.SunwellVial));
    }
  }
}