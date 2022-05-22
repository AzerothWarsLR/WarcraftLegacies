using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestSummonLegion : QuestData
  {
    private static readonly int RitualId = FourCC("A00J");
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _exitPortal;
    private readonly QuestItemCastSpell _questItemCastSpell;

    public QuestSummonLegion(Rectangle rescueRect, unit exitPortal) : base("Under the Burning Sky",
      "The greater forces of the Burning Legion lie in wait in the vast expanse of the Twisting Nether. Use the Book of Medivh to tear open a hole in space-time, and visit the full might of the Legion upon Azeroth.",
      "ReplaceableTextures\\CommandButtons\\BTNArchimonde.blp")
    {
      _exitPortal = exitPortal;
      _questItemCastSpell = new QuestItemCastSpell(RitualId, false);
      AddQuestItem(_questItemCastSpell);
      ResearchId = Constants.UPGRADE_R04B_QUEST_COMPLETED_UNDER_THE_BURNING_SKY;
      Global = true;

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE))
          {
            ShowUnit(unit, false);
          }
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      }
    }

    protected override string CompletionPopup => "Tremble, mortals, and despair. Doom has come to this world.";

    protected override string RewardDescription =>
      "The hero Archimonde, control of all units in the Twisting Nether, and learn to train Greater Demons";

    protected override void OnComplete()
    {
      Holder.Gold += 1000;
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        SetPlayerAbilityAvailable(player, Constants.ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false);
      }
      if (Holder.Player != null)
      {
        foreach (var unit in _rescueUnits)
        {
          unit.Rescue(Holder.Player);
        }
      }
      _rescueUnits.Clear();

      CreatePortals();
      //Play U08Archimonde19
      //Play Doom music
    }

    private void CreatePortals()
    {
      SetUnitOwner(_exitPortal, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
      var position = _questItemCastSpell.Caster!.GetPosition();
      var entrancePortal = CreateUnit(Holder.Player, Constants.UNIT_N037_DEMON_PORTAL, position.X, position.Y, 0);
      entrancePortal.SetWaygateDestination(_exitPortal.GetPosition());
      _exitPortal.SetWaygateDestination(entrancePortal.GetPosition());
    }
    
    protected override void OnAdd()
    {
      if (Holder.UndefeatedResearch == 0)
        throw new Exception($"{Holder.Name} has no presence research. QuestSummonLegion won't work.");
    }
  }
}