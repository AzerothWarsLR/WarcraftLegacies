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
    public sealed class FrostArmorCreepAutocast : Ability
    {
        public FrostArmorCreepAutocast(): base(845562689)
        {
        }

        public FrostArmorCreepAutocast(int newId): base(845562689, newId)
        {
        }

        public FrostArmorCreepAutocast(string newRawcode): base(845562689, newRawcode)
        {
        }

        public FrostArmorCreepAutocast(ObjectDatabaseBase db): base(845562689, db)
        {
        }

        public FrostArmorCreepAutocast(int newId, ObjectDatabaseBase db): base(845562689, newId, db)
        {
        }

        public FrostArmorCreepAutocast(string newRawcode, ObjectDatabaseBase db): base(845562689, newRawcode, db)
        {
        }
    }
}