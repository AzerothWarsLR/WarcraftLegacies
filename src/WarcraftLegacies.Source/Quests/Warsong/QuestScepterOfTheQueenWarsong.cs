using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using System.Collections.Generic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
    public sealed class QuestScepterOfTheQueenWarsong : QuestData
    {
        public QuestScepterOfTheQueenWarsong(Rectangle area) : base("Royal Plunder", "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne and plunder their artifacts.", "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
        {
            _highBourneArea = area;
            AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendWarsong.StonemaulKeep));
            AddObjective(new ObjectiveLegendDead(LegendSentinels.legendFeathermoon));
            AddObjective(new ObjectiveAnyUnitInRect(_highBourneArea, "Dire Maul", true));
           _highBourneAreaUnits = _highBourneArea.Rect.MakeUnitsInvulnerable(Player(GetPlayerNeutralPassive()));
        }

        private List<unit> _highBourneAreaUnits;
        private Rectangle _highBourneArea { get; }
   
        /// <inheritdoc/>
        protected override string CompletionPopup => "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";
        /// <inheritdoc/>
        protected override string RewardDescription => "Gain the Scepter of the Queen and turn all units in Dire Maul hostile";

        /// <inheritdoc/>
        protected override void OnComplete(Faction whichFaction)
        {
            ArtifactSetup.ArtifactScepterofthequeen?.Item.SetPosition(new Point(GetRectCenterX(_highBourneArea.Rect), GetRectCenterY(_highBourneArea.Rect)));
            if (whichFaction.Player != null)
                Player(GetPlayerNeutralAggressive()).MakeUnitsOwner(_highBourneAreaUnits);
        }
    }
}
