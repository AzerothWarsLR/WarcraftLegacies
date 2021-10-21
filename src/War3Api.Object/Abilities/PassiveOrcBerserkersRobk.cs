using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PassiveOrcBerserkersRobk : Ability
    {
        public PassiveOrcBerserkersRobk(): base(1801613121)
        {
        }

        public PassiveOrcBerserkersRobk(int newId): base(1801613121, newId)
        {
        }

        public PassiveOrcBerserkersRobk(string newRawcode): base(1801613121, newRawcode)
        {
        }

        public PassiveOrcBerserkersRobk(ObjectDatabase db): base(1801613121, db)
        {
        }

        public PassiveOrcBerserkersRobk(int newId, ObjectDatabase db): base(1801613121, newId, db)
        {
        }

        public PassiveOrcBerserkersRobk(string newRawcode, ObjectDatabase db): base(1801613121, newRawcode, db)
        {
        }
    }
}