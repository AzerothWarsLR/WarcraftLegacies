using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestFelHordeKillStormwind : QuestData
  {
    private const int UNITTYPE_ID = Constants.UNIT_N086_FEL_DEATH_KNIGHT_FEL_HORDE_ELITE_TIER;
    private const int UNIT_LIMIT = 6;
    private const int BUILDING_ID = Constants.UNIT_O030_FORTRESS_FEL_HORDE;

    protected override string CompletionPopup =>
      "Stormwind's annihilation has left behind the corpses of thousands of elite knights. As occurred during the Second War, these corpses have been filled with the souls of slain Shadow Council members, recreating the indominatable order of Death Knights.";

    protected override string RewardDescription =>
      "Teron Gorefiend can be trained at the altar and learn to train " + I2S(UNIT_LIMIT) + " " +
      GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID);

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(UNITTYPE_ID, UNIT_LIMIT);
    }

    public QuestFelHordeKillStormwind() : base("Those Who Came Before",
      "During the Second War, the souls of slain Shadow Council members were infused into the corpses of Stormwind knights to create the Death Knights. If Stormwind were to fall again, the unholy order could return.",
      "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendStormwind.LegendStormwindkeep));
      ResearchId = Constants.UPGRADE_R05Z_QUEST_COMPLETED_THOSE_WHO_CAME_BEFORE_FEL_HORDE;
    }
  }
}