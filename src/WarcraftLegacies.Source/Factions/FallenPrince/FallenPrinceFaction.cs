using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.FallenPrince.Quests;
using WarcraftLegacies.Source.Factions.FallenPrince.Researches;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.FallenPrince;

/// <summary>Arthas and the dead of Lordaeron, reached through the Fallen Prince path.</summary>
public sealed class FallenPrinceFaction : Faction
{
  private const int FalricStartingXp = 2800;
  private const int RisenVeteransCost = 220;

  /// <inheritdoc />
  public FallenPrinceFaction() : base("Fallen Prince", playercolor.Navy,
    @"ReplaceableTextures\CommandButtons\BTNHeroDeathKnight.blp")
  {
    TraditionalTeam = TeamSetup.Legion;
    NameTakesArticle = true;
    ControlPointDefenderUnitTypeId = UNIT_U028_CONTROL_POINT_DEFENDER_SCOURGE;
    StartingGold = new StartingGold
    {
      Instant = 1000,
      Income = 0,
      Turns = 0
    };
    Nicknames = new List<string>
    {
      "fp",
      "fallen",
      "fallenprince"
    };
    ProcessObjectInfo(FallenPrinceObjectInfo.GetAllObjectLimits());
    SetObjectLevel(UPGRADE_ZB24_DEATH_KNIGHTS_SCOURGE, 1);
  }

  /// <summary>Captain Falric, who joins once the Fallen Prince holds the Capital Palace.</summary>
  public LegendaryHero Falric { get; } = new("Captain Falric")
  {
    UnitType = UNIT_U020_DEATHGUARD_SCOURGE,
    StartingXp = FalricStartingXp
  };

  /// <summary>Captain Marwyn, trainable once the Fallen Prince holds Stratholme.</summary>
  public LegendaryHero Marwyn { get; } = new("Captain Marwyn")
  {
    UnitType = UNIT_U03A_DEATHBRINGER_FALLENPRINCE
  };

  /// <inheritdoc />
  public override void OnRegistered()
  {
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    LegendaryHeroManager.Register(Falric);
    LegendaryHeroManager.Register(Marwyn);
    ResearchManager.Register(new RisenVeterans(UPGRADE_R102_RISEN_VETERANS_FALLENPRINCE, RisenVeteransCost));
    var throneOfLordaeron = AddQuest(new QuestThroneOfLordaeron(AllLegends.Lordaeron.CapitalPalace, Falric));
    var stratholmeRisen = AddQuest(new QuestStratholmeRisen());
    AddQuest(new QuestKeyOfTheThreeMoons(AllLegends.Quel.Sunwell, AllLegends.Scourge.Arthas));
    TakeAscensionFromScourge();
    AddHeraldOfArchimonde();
    ArthasDialogue.SetupFallenPrince(this, throneOfLordaeron, stratholmeRisen);
    FallenPrinceSpells.Setup();
  }

  /// <summary>Arthas marches with the Fallen Prince, so the Scourge's Ascension quest becomes theirs.</summary>
  private void TakeAscensionFromScourge()
  {
    if (FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      var scourgeAscension = scourge.GetAllQuests().OfType<QuestLichKingArthas>().FirstOrDefault();
      if (scourgeAscension != null)
      {
        scourge.RemoveQuest(scourgeAscension);
      }
    }

    AddQuest(new QuestLichKingArthas(AllPreplacedWidgets.Units.Get(UNIT_H00O_UTGARDE_KEEP_SCOURGE_OTHER),
      Artifacts.HelmOfDomination, AllLegends.Scourge.Arthas, AllLegends.Scourge.TheFrozenThrone));
  }

  private void AddHeraldOfArchimonde()
  {
    if (!FactionManager.TryGetFactionByType<LegionFaction>(out var legion))
    {
      return;
    }

    var summonLegion = legion.GetAllQuests().OfType<QuestSummonLegion>().FirstOrDefault();
    if (summonLegion != null && summonLegion.Progress != QuestProgress.Complete)
    {
      AddQuest(new QuestHeraldOfArchimonde(summonLegion, legion));
    }
  }
}
