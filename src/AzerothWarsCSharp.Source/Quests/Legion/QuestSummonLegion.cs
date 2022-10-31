using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestSummonLegion : QuestData
  {
    private const int RITUAL_ID = Constants.ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS;
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _interiorPortal;
    private readonly ObjectiveCastSpell _objectiveCastSpell;
    private TimerWrapper _musicTimer = new();

    public QuestSummonLegion(Rectangle rescueRect, unit interiorPortal) : base("Under the Burning Sky",
      "The greater forces of the Burning Legion lie in wait in the vast expanse of the Twisting Nether. Use the Book of Medivh to tear open a hole in space-time, and visit the full might of the Legion upon Azeroth.",
      "ReplaceableTextures\\CommandButtons\\BTNArchimonde.blp")
    {
      _interiorPortal = interiorPortal;
      _objectiveCastSpell = new ObjectiveCastSpell(RITUAL_ID, false);
      AddObjective(_objectiveCastSpell);
      ResearchId = Constants.UPGRADE_R04B_QUEST_COMPLETED_UNDER_THE_BURNING_SKY;
      Global = true;

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE)) ShowUnit(unit, false);
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "Tremble, mortals, and despair. Doom has come to this world.";

    protected override string RewardDescription =>
      "The hero Archimonde, control of all units in the Twisting Nether, learn to train Greater Demons, and 1000 gold";

    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.Gold += 1000;
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        SetPlayerAbilityAvailable(player, Constants.ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false);
      if (whichFaction.Player != null)
        foreach (var unit in _rescueUnits)
          unit.Rescue(whichFaction.Player);
      _rescueUnits.Clear();

      CreatePortals(whichFaction.Player);

      var archimondeDialogue = new SoundWrapper(@"Sound\Dialogue\UndeadCampaign\Undead08\U08Archimonde19.flac",
        soundEax: SoundEax.HeroAcks);
      archimondeDialogue.Play(true);

      _musicTimer = new TimerWrapper();
      _musicTimer.Start(6, false, PlayMusic);

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        SetPlayerAbilityAvailable(player, RITUAL_ID, false);
    }

    private void PlayMusic()
    {
      PlayThematicMusic("Doom");
      _musicTimer.Dispose();
    }

    private void CreatePortals(player? whichPlayer)
    {
      Point exteriorPortalPosition = _objectiveCastSpell.Caster != null
        ? _objectiveCastSpell.Caster!.GetPosition()
        : new Point(0, 0);
      SetUnitOwner(_interiorPortal, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
      var exteriorPortal = CreateUnit(whichPlayer ?? Player(PLAYER_NEUTRAL_AGGRESSIVE),
        Constants.UNIT_N037_DEMON_PORTAL, exteriorPortalPosition.X, exteriorPortalPosition.Y, 0);
      exteriorPortal.SetWaygateDestination(_interiorPortal.GetPosition());
      _interiorPortal.SetWaygateDestination(exteriorPortal.GetPosition());
    }

    protected override void OnAdd(Faction whichFaction)
    {
      if (whichFaction.UndefeatedResearch == 0)
        throw new Exception($"{whichFaction.Name} has no presence research. QuestSummonLegion won't work.");
    }
  }
}