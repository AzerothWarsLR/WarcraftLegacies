using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Legends;
using WCSharp.Shared.Data;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static AzerothWarsCSharp.MacroTools.Libraries.Display; namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestTheBloodElves : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R04Q");
    private static readonly int UnittypeId = FourCC("n048");
    private static readonly int BuildingId = FourCC("n0A2");
    private static readonly int HeroId = FourCC("Hkal");
    
    private readonly List<unit> _secondChanceUnits = new();
    
    protected override string FailurePopup => "The Sunwell has fallen. The survivors escape to Dalaran and name themselves the Blood Elves in remembrance of their fallen people.";

    protected override string CompletionPopup => "The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demons' magic, becoming the first Blood Mages.";

    protected override string RewardDescription => "Learn to train " + GetObjectName(UnittypeId) + "s from the Consortium, and you can summon Prince Kael'thas from the Altar of Prowess";
    
    protected override string PenaltyDescription => "You lose everything you control, but you gain Prince Kael'thas at the Dalaran Dungeons, and you can train " + GetObjectName(UnittypeId) + "s from the Consortium";

    public QuestTheBloodElves(Rectangle secondChanceRect) : base("The Blood Elves", "The Elves of Quel'thalas have a deep reliance on the Sunwell's magic. Without it, they would have to turn to darker magicks to sate themselves.", "ReplaceableTextures\\CommandButtons\\BTNHeroBloodElfPrince.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendDraktharonkeep, false));
      AddQuestItem(new QuestItemControlLegend(LegendQuelthalas.LegendAnasterian, true));
      AddQuestItem(new QuestItemControlLegend(LegendQuelthalas.LegendSunwell, true));
      
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(secondChanceRect).EmptyToList())
      {
        ShowUnit(unit, false);
        SetUnitInvulnerable(unit, true);
        _secondChanceUnits.Add(unit);
      };
    }

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, QuestResearchId, 1);
      DisplayUnitTypeAcquired(Holder.Player, UnittypeId, "You can now train " + GetObjectName(UnittypeId) + "s from the " + GetObjectName(BuildingId) + ".");
    }

    protected override void OnFail()
    {
      LegendQuelthalas.LegendKael.StartingXp = GetHeroXP(LegendQuelthalas.LegendAnasterian.Unit);
      Holder.Obliterate();
      if (Holder.ScoreStatus != ScoreStatus.Defeated)
      {
        foreach (var unit in _secondChanceUnits)
        {
          UnitRescue(unit, Holder.Player);
        }
        
        SetPlayerTechResearched(Holder.Player, QuestResearchId, 1);
        LegendQuelthalas.LegendKael.Spawn(Holder.Player, -11410, 21975, 110);
        UnitAddItem(LegendQuelthalas.LegendKael.Unit,
          CreateItem(FourCC("I00M"), GetUnitX(LegendQuelthalas.LegendKael.Unit), GetUnitY(LegendQuelthalas.LegendKael.Unit)));
        if (GetLocalPlayer() == Holder.Player)
          SetCameraPosition(Regions.BloodElfSecondChanceSpawn.Center.X, Regions.BloodElfSecondChanceSpawn.Center.Y);
      }
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, Faction.UNLIMITED);
      Holder.ModObjectLimit(UnittypeId, 6);
      Holder.ModObjectLimit(HeroId, 1);
    }
  }
}