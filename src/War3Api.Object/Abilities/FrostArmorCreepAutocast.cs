using System;
using System.Collections.Generic;
using System.Linq;
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

        public FrostArmorCreepAutocast(ObjectDatabase db): base(845562689, db)
        {
        }

        public FrostArmorCreepAutocast(int newId, ObjectDatabase db): base(845562689, newId, db)
        {
        }

        public FrostArmorCreepAutocast(string newRawcode, ObjectDatabase db): base(845562689, newRawcode, db)
        {
        }
    }
}