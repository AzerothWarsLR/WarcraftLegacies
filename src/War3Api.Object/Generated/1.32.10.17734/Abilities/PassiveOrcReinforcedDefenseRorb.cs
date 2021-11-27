using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PassiveOrcReinforcedDefenseRorb : Ability
    {
        public PassiveOrcReinforcedDefenseRorb(): base(1651666753)
        {
        }

        public PassiveOrcReinforcedDefenseRorb(int newId): base(1651666753, newId)
        {
        }

        public PassiveOrcReinforcedDefenseRorb(string newRawcode): base(1651666753, newRawcode)
        {
        }

        public PassiveOrcReinforcedDefenseRorb(ObjectDatabaseBase db): base(1651666753, db)
        {
        }

        public PassiveOrcReinforcedDefenseRorb(int newId, ObjectDatabaseBase db): base(1651666753, newId, db)
        {
        }

        public PassiveOrcReinforcedDefenseRorb(string newRawcode, ObjectDatabaseBase db): base(1651666753, newRawcode, db)
        {
        }
    }
}