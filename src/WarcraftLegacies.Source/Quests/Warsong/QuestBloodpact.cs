using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestBloodpact : QuestData
  {


    /// <summary>
    /// Initializes a new instance of the class <see cref="QuestBloodpact"/>.
    /// </summary>
    public QuestBloodpact()
      : base("The Dark Portal",
        "Following the Second War, the archmage Khadgar and his fellow magi sealed the Dark Portal so that it would never again be used to threaten Azeroth. Little did they know that their magicks were only temporary, and that the portal would open again in time.",
        "ReplaceableTextures\\CommandButtons\\BTNBloodFury.blp")
    {
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R09O, Constants.UNIT_NBFL_FOUNTAIN_OF_BLOOD_BLOODPACT));
      Global = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "The Warsong has accepted drunk the blood of Mannoroth. It will take Thrall 4 minutes to save Grom and purify the Warsong Clan orcs.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "You will gain Mannoroth as a temporary unit, all your orcs except your Kor'kron Elites will gain 200 hit points and chaos damage.";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      TimerStart(CreateTimer(), 240, false, () =>
      {
        
      });
    }
  }
}