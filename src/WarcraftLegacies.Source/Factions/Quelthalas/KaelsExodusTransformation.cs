using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.BloodElves;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;
using static WarcraftLegacies.Source.Factions.Quelthalas.SunfuryRelocation;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Blood Elves, who leave their homeland to their old allies and follow Kael'thas to Tempest Keep.</summary>
public sealed class KaelsExodusTransformation
{
  /// <summary>Turns <paramref name="quelthalas"/>'s player into the Blood Elves.</summary>
  public void Execute(Faction quelthalas)
  {
    var whichPlayer = quelthalas.Player;
    if (whichPlayer == null)
    {
      return;
    }

    var bloodElves = new BloodElvesFaction();
    FactionTransition.AssignNewFaction(quelthalas, bloodElves);
    bloodElves.ModObjectLimit(UPGRADE_R04Q_QUEST_COMPLETED_THE_BLOOD_ELVES_QUEL_THALAS, 1);
    bloodElves.SetObjectLevel(UPGRADE_R04Q_QUEST_COMPLETED_THE_BLOOD_ELVES_QUEL_THALAS, 1);

    PathBase.RemoveHero(AllLegends.Quel.Anasterian);
    PathBase.RemoveHero(AllLegends.Quel.Sylvanas);
    PathBase.RemoveHero(AllLegends.Quel.Lorthemar);
    AllLegends.Sunfury.Kael.UnitType = UNIT_H0DI_PRINCE_OF_QUEL_THALAS_BLOODELVES;
    AllLegends.Sunfury.Solarian.UnitType = UNIT_H0DJ_HIGH_ASTROMANCER_BLOODELVES;

    LeaveHomeland(whichPlayer);
    RelocateBloodElvesArmy(whichPlayer);
    BuildTownBase(whichPlayer, UNIT_H0C5_SANCTUARY_SUNFURY_T3, UNIT_H0DB_CENTURION_BLOODELVES, UNIT_H0DC_BOWMAN_BLOODELVES);
    GiveOutposts(whichPlayer);
    PathBase.SummonLegend(AllLegends.Sunfury.Kael, whichPlayer, new Point(BaseX, BaseY + 400));
  }
}
